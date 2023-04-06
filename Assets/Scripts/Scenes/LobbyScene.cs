using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    public override void Clear()
    {
        Managers.Bpm.Clear();
    }

    protected override void Init()
    {
        base.Init();
        SoundBgmPlay();
        SpawnLobbyUI();
    }
    
    private void SpawnLobbyUI()
    {
        Managers.Resource.Instantiate("UI/Lobby/LobbyUI");
    }
}
