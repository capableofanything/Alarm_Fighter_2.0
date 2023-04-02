using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler_Shield : HitHandler
{
    public HitHandler_Shield(PlayerStat stat)
    {
        successor = new HitHandler_Defalut(stat);
        this.stat = stat;
    }
    public override void Request()
    {
        GameObject shield = stat.GetShield();
        if (shield == null)
        {
            successor.Request();
            return;
        }

        //has the shield so uses the shield an returns false
        //and calls HitHandler_Defalut.Request()
        //dong ju : fix complete
        shield.GetComponent<Shield>().BlockDamage();

        
    }
}
