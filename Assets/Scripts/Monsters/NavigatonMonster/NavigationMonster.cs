using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationMonster : MonoBehaviour
{
    NavigationAttackPattern navigationAttackPattern;
    List<List<NavigationAttackPattern.FunctionPointer>> callOrderList;

    int index;
    int note;

    void Start()
    {
        navigationAttackPattern = GetComponent<NavigationAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = navigationAttackPattern.CreateCallOrderList();

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
