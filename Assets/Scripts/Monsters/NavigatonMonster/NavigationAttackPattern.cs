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
        noteBarList_1 = new List<FunctionPointer>() { Default1_2, Rest , Default1_1, Rest, Default1_2, Rest, Default1_1, Rest };
        noteBarList_2 = new List<FunctionPointer>() { Default1_2, Rest, SpecialAttack_LLRR, Rest, Default1_1, Rest, SpecialAttack_LRL,Rest };
        noteBarList_3 = new List<FunctionPointer>() { Column2, Rest, Row2, Rest, Column3, Rest, Row3, Rest };
        noteBarList_4 = new List<FunctionPointer>() { Default1_2, Rest, SpecialAttack_LRRL, Rest, Default1_1, Rest, SpecialAttack_RLRL, Rest };
        noteBarList_5 = new List<FunctionPointer>() { SpecialAttack_LLLLRR, Rest, SpecialAttack_RRRRLL, Rest, SpecialAttack_LLLLRR, Rest, SpecialAttack_RRRRLL, Rest };
        
        noteBarList_6 = new List<FunctionPointer>() { Default2_1, Rest, Default2_2, Rest, Default2_3, Rest ,SpecialAttack_LLLLRR , SpecialAttack_RRRRLL };

    }
    private void Rest()
    {
        //does nothing
    }

    // field�� �ִϸ��̼��� ���͸��� �˸��� �ִϸ��̼� �̸����� �ٲ��־�� ��. (������ �̹� ������� ī�޶� ���� �˼� One���� ����)
    private void Default1_1()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }
    private void Default1_2()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("One");
    }
    
    private void Default2_1()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }

    private void Default2_2()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("One");
    }

    private void Default2_3()
    {
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
       
    }

    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();

        /* callOrderList.Add(noteBarList_1);
         callOrderList.Add(noteBarList_2);
         callOrderList.Add(noteBarList_3);
         callOrderList.Add(noteBarList_4);
         callOrderList.Add(noteBarList_3);
         callOrderList.Add(noteBarList_5);*/

        callOrderList.Add(noteBarList_6);


        return callOrderList;
    }

   
    // attack pattern ����ֱ�
    #region navigationattackpattern

    public void One()
    {

        int x = UnityEngine.Random.Range(0, 3);
        int y = UnityEngine.Random.Range(0, 3);

        Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
        //grid ������ �ٲٴ� �ִϸ��̼��� ȣ���ϰ� �� ���� Destination_Attack �Լ��� event�� ȣ��

    }

    List<String> destinationArray = new List<string>() { "Destination_0","Destination_1","Destination_2","Destination_3" };
    //int destinationNum = 0;
    public void Destination_Attack()
    {
        int destinationNum = UnityEngine.Random.Range(0, destinationArray.Count);
        Debug.Log("destinationNUM:  " + destinationNum);

        //GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/CameraMonster/Effects/{tantacleArray[tantacleNum]}");
        Managers.Sound.Play("NavigationMonster/Destination", Define.Sound.Effect, 1.0f, 0.1f);
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/NavigationMonster/Effects/{destinationArray[destinationNum]}");//destination prefab�� �ε��Ͽ� ����
        if (go == null) 
            Debug.Log("go is null");
        GameObject destination = Instantiate<GameObject>(go);
        GameObject grid = Managers.Field.GetGrid(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
        Vector2 girdPosition = grid.transform.position;
        girdPosition.y += 2.7f;
        destination.transform.localPosition = girdPosition;

        /*Debug.Log("field�� �׸��尡 ȣ���ϴ�:  "+ destinationNum);
        destinationNum++;
        if (destinationNum > 3)
            destinationNum = 0;*/
        //destination prefab�� ������ ������� �ϴ� ��ũ��Ʈ�� ������ �ڵ�����Ǵ� �ִϸ��̼��� ������ �־���Ѵ�
    }

    public void StraightArrow_Attack()
    {
        Managers.Resource.Instantiate("  "); //straight_arrow prefab�� �ε��Ͽ� ����
        //straight_arrow prefab�� ������ ������� �ϴ� ��ũ��Ʈ�� ������ �ڵ�����Ǵ� �ִϸ��̼��� ������ �־���Ѵ�
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
            //�������� grid�� ������ ���ϵ��� �ϰ� Ư�� grid���� straight_arrow prefab �� instantiate �Ѵ�
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
            //�������� grid�� ������ ���ϵ��� �ϰ� Ư�� grid���� straight_arrow prefab �� instantiate �Ѵ�
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
            //������ grid���� �ִϸ��̼��� �����Ѵ�
            //�ش� �ִϸ��̼��� ������ �̹� ������ ������ SpecialAttack_1()�� Instantiate �Ѵ�
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
