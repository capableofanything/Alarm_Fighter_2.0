using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class GameManagerEx
{
    public void GameOver()      
    {
        Managers.Clear();
        Managers.Sound.Clear();     
        Managers.Scene.LoadScene("GameOverScene");
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);   

    }
    public void StageClear()       
    {
        Managers.Clear();
        Managers.Scene.LoadScene("StageClearScene");
        Managers.Sound.Clear();     
        //Managers.Sound.Play("GameClear", Define.Sound.Bgm);

    }
    public void GameClear()
    {
        Managers.Clear();
        Managers.Scene.LoadScene("GameClearScene");
        Managers.Sound.Clear();
    }
}

