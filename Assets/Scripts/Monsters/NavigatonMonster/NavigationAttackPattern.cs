using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Defalut1_1, Defalut1_2, Defalut1_1, Defalut1_2 };
        noteBarList_2 = new List<FunctionPointer>() { One, One, One, One };
    }
    private void Rest()
    {
        //does nothing
    }

    // field�� �ִϸ��̼��� ���͸��� �˸��� �ִϸ��̼� �̸����� �ٲ��־�� ��. (������ �̹� ������� ī�޶� ���� �˼� One���� ����)
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
        
        callOrderList.Add(noteBarList_2);
      

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

    List<String> destinationArray = new List<string>() { "Destination_0","Destination_1","Destination_2","Destinatioin_3" };
    public void Destination_Attack()
    {
        //GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/CameraMonster/Effects/{tantacleArray[tantacleNum]}");
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/NavigationMonster/Effects/{destinationArray[0]}");//destination prefab�� �ε��Ͽ� ����
        GameObject destination = Instantiate<GameObject>(go);
        GameObject grid = Managers.Field.GetGrid(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
        destination.transform.localPosition = grid.transform.position;
        //destination prefab�� ������ ������� �ϴ� ��ũ��Ʈ�� ������ �ڵ�����Ǵ� �ִϸ��̼��� ������ �־���Ѵ�
    }

    public void Row()
    {
        int row_index = UnityEngine.Random.Range(0, Managers.Field.GetHeight());
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(row_index, i).GetComponent<Animator>().SetTrigger("Row");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
        }
    }

    public void Column()
    {
        int column_index = UnityEngine.Random.Range(0, Managers.Field.GetWidth());
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, column_index).GetComponent<Animator>().SetTrigger("Column");
            //Managers.Field.GetGrid(x, y).GetComponent<Animator>().SetTrigger("One");
            //�������� grid�� ������ ���ϵ��� �ϰ� Ư�� grid���� straight_arrow prefab �� instantiate �Ѵ�
        }
    }
    public void StraightArrow_Attack()
    {
        Managers.Resource.Instantiate("  "); //straight_arrow prefab�� �ε��Ͽ� ����
        //straight_arrow prefab�� ������ ������� �ϴ� ��ũ��Ʈ�� ������ �ڵ�����Ǵ� �ִϸ��̼��� ������ �־���Ѵ�
    }

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

    public void SpecialAttack_1()
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
