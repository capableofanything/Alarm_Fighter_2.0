using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitHandler
{
    protected HitHandler successor;
    protected PlayerStat stat;

    public abstract void Request();

}
