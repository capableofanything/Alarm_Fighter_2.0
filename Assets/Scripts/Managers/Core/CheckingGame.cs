using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingGame : MonoBehaviour
{
    bool HasBeenCalled = false;
    void Start()
    {
        HasBeenCalled = false;
    }


    void Update()
    {
        if(!Managers.Player.IsAlive()&&!HasBeenCalled)
        {
            GameObject go = Managers.Resource.Instantiate("UI/Door");
            go.GetComponent<Door>().SetName("Map");
            HasBeenCalled = true;
        }
        else if(!Managers.Monster.IsAlive()&&!HasBeenCalled)
        {
            GameObject go = Managers.Resource.Instantiate("UI/Door");
            if ((Managers.Monster.CurrentMonsterSceneName() + 1) != Define.GameSceneOrder.Finished)
            {
                go.GetComponent<Door>().SetName((Managers.Monster.CurrentMonsterSceneName() + 1).ToString());
            }
            else
            {
                go.GetComponent<Door>().SetName("FinishedScene");
            }
            Managers.Clear();
            Managers.Sound.Clear();
            HasBeenCalled = true;
        }
    }
}
