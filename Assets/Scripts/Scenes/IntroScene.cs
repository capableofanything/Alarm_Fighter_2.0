using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IntroScene : BaseScene
{
    public override void Clear()
    {

    }

    protected override void Init()
    {
        base.Init();
        SoundBgmPlay();
    }
}
