using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler_Defalut : HitHandler
{
    public HitHandler_Defalut(PlayerStat stat)
    {
        this.stat = stat;
    }

    public override void Request()
    {
        float damage = -1f;
        if(stat != null)
        {
            stat.FillHp(damage);
        }
    }
}
