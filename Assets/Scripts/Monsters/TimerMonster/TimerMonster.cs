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

        Managers.Bpm.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = timerAttackPattern.CreateCallOrderList();

        index = 0;
        note = 0;
    }

    void BitBehave()
    {
        if (index > callOrderList.Count - 1)
            index = 0;

        callOrderList[index][note]();

        note++;
        if (note >= 4)
        {
            note = 0;
            //index++; // notebarlist�� �߰��ϸ� �ٽ� �ּ� Ǯ����� ��.
        }

        //index++;
    }

}
