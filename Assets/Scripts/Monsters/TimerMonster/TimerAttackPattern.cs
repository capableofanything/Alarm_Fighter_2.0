using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Rest, One, Rest, Rest, Rest, One, Rest, Rest, Rest};
        noteBarList_2 = new List<FunctionPointer>() { One, Rest, One, Rest, One, Rest , One, Rest, One, Rest, One, Rest , One, Rest, One, Rest, One, Rest
         ,One, Rest, One, Rest, One, Rest,  One, Rest};
        noteBarList_3 = new List<FunctionPointer>() {One, Rest, One, Rest, One, Rest, One, Rest, One, Rest, Row0, Row1, Row2, Row3};
    }

    private void Rest()
    {
        //does nothing
    }

    private void One()
    {
        int xrand = (int)Random.Range(1, 3);
        int yrand = (int)Random.Range(0, 3);
        if(xrand == 1 && yrand == 0)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack10");
        }
        else if(xrand == 1 && yrand == 1)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack11");
        }
        else if (xrand == 1 && yrand == 2)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack12");
        }
        else if (xrand == 2 && yrand == 0)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack20");
        }
        else if (xrand == 2 && yrand == 1)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack21");
        }
        else if (xrand == 2 && yrand == 2)
        {
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("timer_oneattack22");
        }
        Managers.Field.GetGrid(xrand, yrand).GetComponent<Animator>().SetTrigger("TimerOne");
    }

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

    // attack pattern 집어넣기
    #region timeattackpattern
    public void TimerAttack()
    {
        TimerAttackInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
    }

    private void TimerAttackInit(int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/TimerMonster/Effects/TimerSonic");
        GameObject sonic = Instantiate(go);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);
        sonic.transform.position = fieldInfo.grid.transform.position;
    }

    public void TimerRowAttack()
    {
        TimerRowAttackInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
    }

    private void TimerRowAttackInit(int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/TimerMonster/Effects/TimerSonic");
        GameObject sonic = Instantiate(go);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);

        GameObject effect = Managers.Resource.Load<GameObject>("Monsters/TimerMonster/Effects/TimerSonicEffect");

        sonic.transform.position = fieldInfo.grid.transform.position;
    }
    #endregion
}
