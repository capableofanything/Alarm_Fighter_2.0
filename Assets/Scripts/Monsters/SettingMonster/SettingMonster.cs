using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMonster : MonoBehaviour
{
    SettingAttackPattern settingAttackPattern;
    List<List<SettingAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        settingAttackPattern = GetComponent<SettingAttackPattern>();
        Invoke("BitChecking", 4.3f);
    }
    void BitChecking()
    {
        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = settingAttackPattern.CreateCallOrderList();

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
            index++;
        }

        //index++;
    }

}
