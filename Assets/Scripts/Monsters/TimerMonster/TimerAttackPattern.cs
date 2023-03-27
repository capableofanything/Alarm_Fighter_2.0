using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;
    public List<FunctionPointer> noteBarList_4;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Rest, Defalut1_1, Rest, Rest, Rest, Defalut1_2, Rest, Rest, Rest};
        noteBarList_2 = new List<FunctionPointer>() { Defalut1_1, Defalut1_2, Defalut1_1, Defalut1_2, One, Row0, Row1, Row2, Row3,
        Rest, Defalut1_1, Defalut1_2, Defalut1_1, Defalut1_2, One, Row0, Row1, Row2, Row3,
        Rest, Defalut1_1, Defalut1_2, Defalut1_1, Defalut1_2, One, Row0, Row1, Row2, Row3};
        noteBarList_3 = new List<FunctionPointer>() {Defalut1_1, Defalut1_2, One, One, Defalut1_1, Defalut1_2, One, One, Row0, Row1, Row2, Row3};
    }
    private void Rest()
    {
        //does nothing
    }

    private void One()
    {
        int xrand = (int)Random.Range(0, 3);
        int yrand = (int)Random.Range(0, 3);
        Managers.Field.GetGrid(xrand, yrand).GetComponent<Animator>().SetTrigger("TimerOne");
    }

    // field�� �ִϸ��̼��� ���͸��� �˸��� �ִϸ��̼� �̸����� �ٲ��־�� ��. (������ �̹� ������� ī�޶� ���� �˼� One���� ����)
    private void Defalut1_1()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("TimerOne");
    }
    private void Defalut1_2()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("TimerOne");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("TimerOne");
    }
    private void Row0()
    {
        // ���� ���� �� Rest 
        One();
        Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_hand_idle2");
    }
    private void Row1()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(0, i).GetComponent<Animator>().SetTrigger("TimerRow");
        }
    }
    private void Row2()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(1, i).GetComponent<Animator>().SetTrigger("TimerRow");
        }
    }
    private void Row3()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(2, i).GetComponent<Animator>().SetTrigger("TimerRow");
        }
    }
    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();

        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);
        callOrderList.Add(noteBarList_3);

        return callOrderList;
    }

    // attack pattern ����ֱ�
    #region timeattackpattern
    public void RingOneAttack()
    {
        // �ݶ��̴��� �� gameobject�� ������ ����.
    }

    public void RingRowAttack()
    {
        StartCoroutine(Ringing());
    }

    private IEnumerator Ringing()
    {
        yield return new WaitForSeconds(0.2f);
    }
    #endregion
}
