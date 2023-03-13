using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler_Invincible : HitHandler
{
    public HitHandler_Invincible(PlayerStat stat)
    {
        successor = new HitHandler_Shield(stat);
        this.stat = stat;
    }
    public override void Request()
    {
        GameObject Item_angle = stat.GetItem_Angle();
        if (Item_angle == null)
            successor.Request();

        if (!Item_angle.GetComponent<Item_angle>().Invincible())
            successor.Request();
    }
}
