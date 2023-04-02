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

        Managers.Bpm.BehaveAction -= BitBehave;      //몬스터의 비트 마다 실행할 BitBehave 구독
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
        if (note >= 8)
        {
            note = 0;
            index++;
            
            if(index == 1 || index == 3)
            {
                GetComponent<Animator>().SetTrigger("Angry_Idle");
            }
            else
            {
                GetComponent<Animator>().SetTrigger("Caution");
            }
        }
     }

        //index++;
}


