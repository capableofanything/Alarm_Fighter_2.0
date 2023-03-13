using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraMonster : MonoBehaviour
{
    //public delegate void FunctionPointer();
    CameraAttackPattern cameraAttackPattern;
    List<CameraAttackPattern.FunctionPointer> callOrderList;
    //public Transform CurrentTransform() { return transform; }//sunho 0218

    
    int index = 0;

    void Start()
    {
        cameraAttackPattern = GetComponent<CameraAttackPattern>();

        Managers.Bpm.BehaveAction -= BitBehave;      //������ ��Ʈ ���� ������ BitBehave ����
        Managers.Bpm.BehaveAction += BitBehave;

        callOrderList = cameraAttackPattern.CreateCallOrderList();

        /*        CallOrderList.Add(Pattern1);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern2);
                CallOrderList.Add(Pattern1);
        */
    }

    void BitBehave()
    {
        if (index > callOrderList.Count - 1) // 4 ���뼺 ����, �ٸ� ������ ��ü�� �� ����
            index = 0;

        callOrderList[index]();
        index++;

    }
}
