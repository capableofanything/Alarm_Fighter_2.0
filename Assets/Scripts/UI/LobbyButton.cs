using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class LobbyButton : MonoBehaviour
{
    public void OnClick()
    {
        Managers.Scene.Clear();
        Managers.Scene.LoadScene(Define.GameSceneOrder.TimeScene_main.ToString());        
    }

    public void ClickQuit()
    {
        Managers.Game.QuitGame();
    }
    public void ClickScan()
    {
        GetComponent<Animator>().SetTrigger("ScanStart");
    }

    public void LoadStage()
    {
        GameObject go = Managers.Resource.Instantiate("UI/DoorCloseUI");
        go.GetComponent<Door>().SetName(Managers.Game.NextStage.ToString());
    }
}
