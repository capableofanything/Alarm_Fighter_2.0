using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum GameSceneOrder
    {
        TimeScene_main = 1,//100
        MessageScene_main,//100
        NavigationScene_main,//100
        CameraScene_main,//120
        SettingScene_main,//120


        //Finished
        //FolderScene,
        //CallScene,

        //WeatherScene,
        //DiliveryScene,
        Count,
    }
}
