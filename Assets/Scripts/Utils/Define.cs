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
        TimeScene_main = 1,//120
        CameraScene_main,//120
        NavigationScene_main,//HP 100
        MessageScene_main,//120
        SettingScene_main,//120
        Map,
        //Finished
        //FolderScene,
        //CallScene,

        //WeatherScene,
        //DiliveryScene,
        Count,
    }
}
