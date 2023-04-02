using System.Collections.Generic;
using UnityEngine;

public class MonsterManager
{
    private GameObject bossMonster;
    private Define.GameSceneOrder CurrentMonsterScene;
    private bool alive = true;
    public GameObject BossMonster
    {
        get { return bossMonster; }
        set { bossMonster = value;}
    }
    public void Init(Define.GameSceneOrder name) { alive = true; CurrentMonsterScene = name; }//sunho 0402 needed!!@@
    public bool IsAlive()
    {
        return alive;
    }
    public void SetAlive(bool alive)
    {
        this.alive = alive;
    }
    public Define.GameSceneOrder CurrentMonsterSceneName() { return CurrentMonsterScene; }
}
