using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingGameScene : BaseScene//At the beginning of the this scene, responsible for the essential spawn.
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
        Managers.Resource.Instantiate("BackGrounds/SettingBackground");
    }
    private void SpawnField()
    {
        Managers.Resource.Instantiate("Fields/Fields_SettingDemo");
        GameObject go = Managers.Resource.Instantiate("Fields/Fields_Setting");
        if(go != null) 
        {
            Managers.Field.SetField(go.GetComponent<Field>());
            Managers.Field.Init();
        }
        Animator[] ani = go.GetComponentsInChildren<Animator>();
        foreach(Animator a in ani)
        {
            a.runtimeAnimatorController = Managers.Resource.Load<RuntimeAnimatorController>("Art/Animations/fields/SettingFieldAnimation/SettingGridAnimator");
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
        GameObject go = Managers.Resource.Instantiate("Monsters/SettingMonster/SettingMonster");
        if( go != null)
        {
            SpawnMonsterHpBar(go);  
            Managers.Monster.BossMonster = go;
            Managers.Monster.Init(Define.GameSceneOrder.SettingScene_main);
        }
    }   
    private void SpawnPlayerHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Instantiate("Players/PlayerHP_Setting");
        parent.GetComponent<PlayerHpBarUpdater>().SetPlayerHpBar(go);
    }

    private void SpawnMonsterHpBar(GameObject parent)
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/SettingMonster/MonsterHP");
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
