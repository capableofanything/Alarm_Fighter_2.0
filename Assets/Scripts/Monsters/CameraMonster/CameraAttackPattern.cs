using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraAttackPattern :MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;
    public List<FunctionPointer> noteBarList_4;
    public List<FunctionPointer> noteBarList_5;
    
    private void Awake()
    {
        Init();
    }
    
    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Defalut1_1, Rest, Defalut1_2, Rest, Defalut1_1, Rest, Defalut1_2 };
        noteBarList_2 = new List<FunctionPointer>() { Row1, Row2, Row3, Special };
        noteBarList_3 = new List<FunctionPointer>() { Column1, Column2, Column3, Special };
    }
    
    private void Row()   
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(i, Managers.Player.GetCurrentIndY()).GetComponent<Animator>().SetTrigger("Row");
        }
    }

    private void Row1()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(0, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row2()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(1, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row3()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(2, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }

    private void Column() 
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(Managers.Player.GetCurrentIndX(), i).GetComponent<Animator>().SetTrigger("Column");
        }
    }

    private void Column1()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 0).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column2()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 1).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column3()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 2).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void One()    
    {
       Managers.Field.GetGrid(Managers.Player.GetCurrentIndX(), Managers.Player.GetCurrentIndY()).GetComponent<Animator>().SetTrigger("One");
    }
    
    private void Special()
    {
        FlashAttack();
    }
    private void Rest()
    {
      //does nothing
    }

    private void Defalut1_1()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }
    private void Defalut1_2()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("One");
    }
    private void Defalut2_1()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("One");
    }
    private void Defalut2_2()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }


    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();
        /*
                for (int i = 0; i < noteBarList_1.Count; i++)
                {
                    callOrderList.Add(noteBarList_1[i]);
                }
        */
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_3);

        return callOrderList;
    }

    //-----------------------------------------------------------------------------------------------------------------
    #region CameraAttackPatterns

    public void LazerAttack()//Lazer attack where is in grid(x,y), start  = monster eye, where = (x,y)
    {
        //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("GridRed");
        //await Task.Delay(300);
        GameObject cameraLens = Util.FindChild(Managers.Monster.BossMonster, "카메라 부분_7", true);
        LazerInit(cameraLens.transform, Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));//n second after use
        Managers.Sound.Play("Effects/Laser04",Define.Sound.Effect,1.0f,0.05f);
    }
    #region LazerAttack_Private
    private void LazerInit(Transform transform, int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/CameraMonster/Effects/Lazer");
        //GameObject effect = Managers.Resource.Load<GameObject>("Prefabs/Monsters/CameraMonster/Effects/Lazer_Boom");

        go.transform.position = transform.position;
        SetBasicScale(go);
        Transform transform_my = go.transform;
        Transform transform_target = SetTarget(x, y);
        //effect.transform.position = SetEffect(x, y);
        SetRotation(go, transform_my, transform_target);
        go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer");
        //effect = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer_Boom");

        go.AddComponent<Lazer>();
        //effect.AddComponent<Lazer_Boom>();
        StartCoroutine(LazerBoomInit(x, y));

    }
    
    private IEnumerator LazerBoomInit(int x,int y)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject effect = Managers.Resource.Load<GameObject>("Prefabs/Monsters/CameraMonster/Effects/Lazer_Boom");
        effect.transform.position = SetEffect(x, y);    
        effect = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer_Boom");
        effect.AddComponent<Lazer_Boom>();
    }
    public void SetBasicScale(GameObject go)        //Change private to public
    {
        float x = 10.0f;
        float y = go.transform.localScale.y;
        float z = go.transform.localScale.z;
        go.transform.localScale = new Vector3(x, y, z);
    }
    public Transform SetTarget(int x, int y)        //Change private to public
    {
        return Managers.Field.GetGrid(x, y).transform;
    }
    private  void UpdateScale(GameObject go, Vector3 vector)
    {
        float vectorX = go.transform.localScale.x;
        float vectorY = -vector.magnitude;
        float vectorZ = vector.z;
        go.transform.localScale = new Vector3(vectorX, vectorY, vectorZ);
    }
    public  void SetRotation(GameObject go, Transform transform_my, Transform transform_target)    //Change private to public
    {
        Vector3 myPos = transform_my.position;
        Vector3 targetPos = transform_target.position;
        targetPos.z = myPos.z;

        Vector3 vectorToTarget = targetPos - myPos;
        UpdateScale(go, vectorToTarget);

        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: vectorToTarget);
        transform_my.rotation = targetRotation;


        //transform_my.rotation = Quaternion.RotateTowards(transform_my.rotation, targetRotation, 100 * Time.deltaTime);
    }
    private  Vector3 SetEffect(int x, int y)
    {
        Vector3 vec = Managers.Field.GetGrid(x, y).transform.position;
        //vec.z = 0;
        return vec;
    }
    #endregion
    //
    public void LazerMoveAttack(Transform transform, int where = 0, int speed = 500)//Lazer move attack where is row, start = monster eye, where = row
    {
        LazerMoveInit(transform, where, speed);
    }
    #region LazerMoveAttack_Private
    private void LazerMoveInit(Transform transform, int where, int speed)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Lazer");
        GameObject effect = Managers.Resource.Instantiate("Monsters//CameraMonster/Effects/Lazer_Boom");

        /*GameObject lazerMoveAttack = new GameObject("LazerMoveAttack");
        go.transform.SetParent(lazerMoveAttack.transform);
        effect.transform.SetParent(lazerMoveAttack.transform);*/

        go.transform.SetParent(Managers.Monster.BossMonster.transform);
        effect.transform.SetParent(Managers.Monster.BossMonster.transform);
        
        go.AddComponent<LazerMove>();
        //effect.AddComponent<HorizontalAttack1>(); 
    }

    #endregion
    int tantacleNum = 0;
    List<String> tantacleArray = new List<string>() {"Tantacle0","Tantacle1","Tantacle2" };
    public void TantacleAttack()
    {
        TantacleInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
        Managers.Sound.Play("Effects/Tantacle01", Define.Sound.Effect, 1.0f, 0.01f);
    }
    
    private void TantacleInit(int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/CameraMonster/Effects/{tantacleArray[tantacleNum]}");
        GameObject tantacle = Instantiate<GameObject>(go);
        Managers.Field.ScaleByRatio(tantacle,x,y);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);
        tantacle.transform.localScale = new Vector3(1.5f, 0.8f, 1f) * fieldInfo.ratio;
        //tantacle.transform.localScale.y = new Vector3(1f, 0.5f, 1f);
        tantacle.transform.position = fieldInfo.grid.transform.position;

        tantacleNum++;
        if (tantacleNum > 2)
            tantacleNum = 0;
    }
    #region TantacleAttack_Private

    #endregion
    public void FlashAttack() { FlashInit(); }
    #region FlashAttack_Private
    private void FlashInit()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/Effects/Flash");
    }
    #endregion

    #endregion
}
