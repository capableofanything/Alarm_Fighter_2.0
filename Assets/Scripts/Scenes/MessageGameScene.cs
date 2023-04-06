using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageGameScene : BaseScene//At the beginning of the this scene, responsible for the essential spawn.
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
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/BackGrounds/MessageBackground/MessageBackground");
        if (go != null)
        {
            go = Managers.Resource.Instantiate("BackGrounds/MessageBackground/MessageBackground");
        }
    }
    private void SpawnField()
    {
        GameObject go = Managers.Resource.Instantiate("Fields/Fields");
        if (go != null)
        {
            Managers.Field.SetField(go.GetComponent<Field>());
            Managers.Field.Init();
            Animator[] ani = go.GetComponentsInChildren<Animator>();
            foreach(Animator a in ani)
            {
                a.runtimeAnimatorController = Managers.Resource.Load<RuntimeAnimatorController>("Art/Animations/Fields/MessageFieldAnimation/MessageGridAnimator");
            }
        }
    }
    private void SpawnPlayer()
    {
        GameObject go = Managers.Resource.Load<GameObject>("Prefabs/Players/PlayerRig");
        if (go != null)
        {
            go = Managers.Resource.Instantiate("Players/PlayerRig");
            Managers.Player.SetPlayer(go.GetComponent<Player>());
            SpawnPlayerHpBar(go);
        }
    }
    private void SpawnMonster()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/MessageMonster/MessageMonster");
        if (go != null)
        {
            SpawnMonsterHpBar(go);
            Managers.Monster.BossMonster = go;
            Managers.Monster.Init(Define.GameSceneOrder.MessageScene_main);
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
        if (go != null)
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
