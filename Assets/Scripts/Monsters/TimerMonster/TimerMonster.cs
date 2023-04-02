using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerMonster : MonoBehaviour
{
    TimerAttackPattern timerAttackPattern;
    List<List<TimerAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        timerAttackPattern = GetComponent<TimerAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = timerAttackPattern.CreateCallOrderList();

        index = 0;
        note = 0;

    }

    void BitBehave()
    {
        if (!this.transform.GetComponent<Animator>().GetBool("startEnd"))
            return;

        if (index > callOrderList.Count - 1)
            index = 2;

        callOrderList[index][note]();

        note++;
        if (note >= callOrderList[index].Count)
        {
            note = 0;
            index++;
        }

    }

    public void SetStartEnd()
    {
        this.transform.GetComponent<Animator>().SetBool("startEnd", true);
    }
}
