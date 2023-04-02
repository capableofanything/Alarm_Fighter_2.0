using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BpmManager
{
    int bpm = 115;
    //public bool Able;

    public Action BehaveAction;     //BpmManager의 UpdatePerBit()에서 실행(바로 아래)
    double currentTime = 0;
    
    public int BPM
    {
        get { return bpm; }
        set { bpm = value; }
    }

    //Activates BehaveAction every 60d / bpm seconds
    public void UpdatePerBit()      //GameScene의 Update()문에서 호출   
    {
        currentTime += Time.deltaTime;
        if (currentTime >= 60d / Managers.Bpm.BPM)
        {
            if (BehaveAction != null)
                BehaveAction.Invoke();
            //Debug.Log("work!");
            currentTime -= 60d / Managers.Bpm.BPM;
        }
    }

    public void Clear()
    {
        BehaveAction = null;
        currentTime = 0;
    }

    public float GetAnimSpeed()
    {
        float speed = bpm / 60;

        return speed;
    }
}
