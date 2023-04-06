using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraGameScene : BaseScene//At the beginning of the this scene, responsible for the essential spawn.
{
    [SerializeField] GameObject backGround;
    [SerializeField] GameObject BossMonster;
    [SerializeField] GameObject MonsterHP;

    protected override void Init()
    {
        base.Init();            
        SoundBgmPlay();
        SpawnBackGround();
        SpawnField();
        SpawnMonster();       
        SpawnPlayer();
        SpawnItemSpawner();
        CheckingGame();
    }
    public void Update()
    {
        Managers.Bpm.UpdatePerBit();
    }

    private void SpawnBackGround()
    {
        GameObject go = Managers.Resource.Instantiate("BackGrounds/CleanCameraStageBackGround");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_0");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_1");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_2");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_3");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_4");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_5");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_6");
        Managers.Resource.Instantiate("Monsters/CameraMonster/CameraSubMonster/CameraSubMonster_7");
    }
    private void SpawnField()
    {
        GameObject go = Managers.Resource.Instantiate("Fields/Fields");
        if(go != null) 
        {
            Managers.Field.SetField(go.GetComponent<Field>());
            Managers.Field.Init();
            Animator[] ani = go.GetComponentsInChildren<Animator>();
            foreach (Animator a in ani)
            {
                a.runtimeAnimatorController = Managers.Resource.Load<RuntimeAnimatorController>("Art/Animations/Fields/CameraFieldAnimation/CameraGridAnimator");
            }
        }
    }
    private void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/PlayerRig");
        if(go != null) 
        {
            go = Managers.Resource.Instantiate("Players/PlayerRig");
            Managers.Player.SetPlayer(go.GetComponent<Player>());
            SpawnPlayerHpBar(go);
        }
    }
    private void SpawnMonster()                
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/CameraMonster");
        if( go != null)
        {
            SpawnMonsterHpBar(go);
            Managers.Monster.BossMonster = go;
            Managers.Monster.Init(Define.GameSceneOrder.CameraScene_main);
        }
    }   
    private void SpawnPlayerHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Instantiate("Players/PlayerHP");
        parent.GetComponent<PlayerHpBarUpdater>().SetPlayerHpBar(go);
    }

    private void SpawnMonsterHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/CameraMonster/MonsterHP");
        if(go != null) 
        {
            parent.GetComponent<MonsterHpBarUpdater>().monsterHPbar = go;
        }
    }

    public override void Clear()
    {
        Managers.Bpm.Clear();
    }
    private void SpawnItemSpawner()
    {
        Managers.Item.Init();
    }
}
