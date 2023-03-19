using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraMonster : MonoBehaviour
{
    //public delegate void FunctionPointer();
    CameraAttackPattern cameraAttackPattern;
    List<List<CameraAttackPattern.FunctionPointer>> callOrderList;
    //public Transform CurrentTransform() { return transform; }//sunho 0218

    int index;
    int note;

    void Start()
    {
        cameraAttackPattern = GetComponent<CameraAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = cameraAttackPattern.CreateCallOrderList();

        index = 0;
        note = 0;
        /*        CallOrderList.Add(Pattern1);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern1);
        */
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
