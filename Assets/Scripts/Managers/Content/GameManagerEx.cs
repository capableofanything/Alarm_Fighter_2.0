using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerEx
{
    public Define.GameSceneOrder NextStage { get; private set; } //= Define.GameSceneOrder.NavigationScene_main;



    public void QuitGame()
    {
        SaveGame();
        Application.Quit();
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("NextStage", (int)NextStage);
    }

    public void LoadGame()
    {
        if (!PlayerPrefs.HasKey("NextStage"))
            return;

        NextStage = (Define.GameSceneOrder)PlayerPrefs.GetInt("NextStage");

    }
}

