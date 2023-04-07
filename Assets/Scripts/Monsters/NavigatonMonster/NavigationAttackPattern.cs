using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class NavigationAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;
    public List<FunctionPointer> noteBarList_4;
    public List<FunctionPointer> noteBarList_5;
    public List<FunctionPointer> noteBarList_6;
    public List<FunctionPointer> noteBarList_7;
    public List<FunctionPointer> noteBarList_8;
    

    private void Awake()
    {
        Init();
    }
    
    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Defalut1_2, Rest , Defalut1_1, Rest, Defalut1_2, Rest, Defalut1_1, Rest };
        noteBarList_2 = new List<FunctionPointer>() { Defalut1_2, Rest, SpecialAttack_LLRR, Rest, Defalut1_1, Rest, SpecialAttack_LRL,Rest };
        noteBarList_3 = new List<FunctionPointer>() { Column2, Rest, Row2, Rest, Column3, Rest, Row3, Rest };
        noteBarList_4 = new List<FunctionPointer>() { Defalut1_2, Rest, SpecialAttack_LRRL, Rest, Defalut1_1, Rest, SpecialAttack_RLRL, Rest };
        noteBarList_5 = new List<FunctionPointer>() { SpecialAttack_LLLLRR, Rest, SpecialAttack_RRRRLL, Rest, SpecialAttack_LLLLRR, Rest, SpecialAttack_RRRRLL, Rest };
        //noteBarList_6 = new List<FunctionPointer>() { };

    }
    private void Rest()
    {
        //does nothing
    }

    // field의 애니메이션은 몬스터마다 알맞은 애니메이션 이름으로 바꿔주어야 함. (지금은 이미 만들어진 카메라 몬스터 촉수 One으로 통일)
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

    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();
        
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);
        callOrderList.Add(noteBarList_3);
        callOrderList.Add(noteBarList_4);
        callOrderList.Add(noteBarList_3);
        callOrderList.Add(noteBarList_5);


        return callOrderList;
    }

   
    // attack pattern 집어넣기
    #region navigationattackpattern

    public void One()
    {

        int x = UnityEngine.Random.Range(0, 3);
        int y = UnityEngine.Random.Range(0, 3);

        Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
        //grid 색까을 바꾸는 애니메이션을 호출하고 그 끝에 Destination_Attack 함수를 event로 호출

    }

    List<String> destinationArray = new List<string>() { "Destination_0","Destination_1","Destination_2","Destination_3" };
    //int destinationNum = 0;
    public void Destination_Attack()
    {
        int destinationNum = UnityEngine.Random.Range(0, destinationArray.Count);
        Debug.Log("destinationNUM:  " + destinationNum);

        //GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/CameraMonster/Effects/{tantacleArray[tantacleNum]}");
        Managers.Sound.Play("NavigationMonster/Destination", Define.Sound.Effect, 1.0f, 0.1f);
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/NavigationMonster/Effects/{destinationArray[destinationNum]}");//destination prefab을 로드하여 생성
        if (go == null) 
            Debug.Log("go is null");
        GameObject destination = Instantiate<GameObject>(go);
        GameObject grid = Managers.Field.GetGrid(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
        Vector2 girdPosition = grid.transform.position;
        girdPosition.y += 2.7f;
        destination.transform.localPosition = girdPosition;

        /*Debug.Log("field의 그리드가 호출하는:  "+ destinationNum);
        destinationNum++;
        if (destinationNum > 3)
            destinationNum = 0;*/
        //destination prefab은 몇초후 사라지게 하는 스크립트와 생성시 자동재생되는 애니메이션을 가지고 있어야한다
    }

    public void StraightArrow_Attack()
    {
        Managers.Resource.Instantiate("  "); //straight_arrow prefab을 로드하여 생성
        //straight_arrow prefab은 몇초후 사라지게 하는 스크립트와 생성시 자동재생되는 애니메이션을 가지고 있어야한다
    }
    public void Row2()
    {
        //int row_index = UnityEngine.Random.Range(0, Managers.Field.GetHeight());
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(1, i).GetComponent<Animator>().SetTrigger("Row");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
        }
        Invoke("Row2_Init", 0.3f);
    }
    public void Row2_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowRR");
        GameObject arrowRR = Instantiate<GameObject>(go);
        Transform field = Managers.Field.GetGrid(1, 1).transform;
        arrowRR.transform.position = field.position;
    }

    public void Row3()
    {
        //int row_index = UnityEngine.Random.Range(0, Managers.Field.GetHeight());
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(2, i).GetComponent<Animator>().SetTrigger("Row");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
        }
        Invoke("Row3_Init", 0.3f);
    }
    
    public void Row3_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowRR");
        GameObject arrowRR = Instantiate<GameObject>(go);
        Transform field = Managers.Field.GetGrid(2, 1).transform;
        arrowRR.transform.position = field.position;
    }
    
    public void Column2()
    {
        //int column_index = UnityEngine.Random.Range(0, Managers.Field.GetWidth());
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 1).GetComponent<Animator>().SetTrigger("Column");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
            //여러개의 grid가 색깔이 변하도록 하고 특정 grid에서 straight_arrow prefab 을 instantiate 한다
        }
        Invoke("Column2_Init", 0.3f);
    }

    public void Column2_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLL");
        GameObject arrowLL = Instantiate<GameObject>(go);
        Transform field = Managers.Field.GetGrid(1, 1).transform;
        arrowLL.transform.position = field.position;
    }


    public void Column3()
    {
        //int column_index = UnityEngine.Random.Range(0, Managers.Field.GetWidth());
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 2).GetComponent<Animator>().SetTrigger("Column");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
            //여러개의 grid가 색깔이 변하도록 하고 특정 grid에서 straight_arrow prefab 을 instantiate 한다
        }
        Invoke("Column3_Init", 0.3f);
    }

    public void Column3_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLL");
        GameObject arrowLL = Instantiate<GameObject>(go);
        Transform field = Managers.Field.GetGrid(1,2).transform;
        arrowLL.transform.position = field.position;
    }

    //======================================================

    public void special()
    {
        int rand_num = UnityEngine.Random.Range(0, 3);

        if (rand_num == 0)
        {
            //지정된 grid들이 애니메이션을 실행한다
            //해당 애니매이션이 끝나면 이미 지정된 영역의 SpecialAttack_1()을 Instantiate 한다
        }
        else if (rand_num == 1)
        {
           
        }
        else if (rand_num == 2)
        {
            
        }
      
    }

    public void SpecialAttack_LLRR()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_LLRR_Init", 0.3f);

    }

    public void SpecialAttack_LLRR_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLLRR");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }

    public void SpecialAttack_LRL()
    {
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_LRL_Init", 0.3f);
    }

    public void SpecialAttack_LRL_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLRL");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }

    public void SpecialAttack_LRRL()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_LRRL_Init", 0.3f);

    }

    public void SpecialAttack_LRRL_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLRRL");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }


    public void SpecialAttack_RLRL()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_RLRL_Init", 0.3f);
    }

    public void SpecialAttack_RLRL_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowRLRL");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }

    
    public void SpecialAttack_LLLLRR()
    {
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_LLLLRR_Init", 0.3f);
    }

    public void SpecialAttack_LLLLRR_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowLLLLRR");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }

    public void SpecialAttack_RRRRLL()
    {
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("Row");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("Row");

        Invoke("SpecialAttack_RRRRLL_Init", 0.3f);
    }

    public void SpecialAttack_RRRRLL_Init()
    {
        Managers.Sound.Play("NavigationMonster/Arrow", Define.Sound.Effect, 1.0f, 0.5f);
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Monsters/NavigationMonster/Effects/ArrowRRRRLL");
        GameObject arrowLL = Instantiate<GameObject>(go);
    }

    public void SpecialAttack_RLL()
    {
        Managers.Resource.Instantiate("  ");
    }

    

    public void SpecialAttack_2()
    {
        Managers.Resource.Instantiate("  ");
    }
        
    public void SpecialAttack_3()
    {
        Managers.Resource.Instantiate("  ");
    }


    #endregion
}
