using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    float MaxHP;
    float CurrentHP;
    GameObject shield;
    GameObject item_angle;
    void Start()
    {
        MaxHP = 10;
        CurrentHP = 10;
        //GetComponent<HpBarUpdater>().GetSliderComponent().maxValue = MaxHP;

    }

    public void FillHp(float mount)
    {
        CurrentHP += mount;
        if (MaxHP <= CurrentHP)
            CurrentHP = MaxHP;
    }
    public void FillShield(string Shield)
    {
        this.shield = Managers.Resource.Instantiate(Shield, transform);
    }
    public void FillInvincible(string item_angle)
    {
        this.item_angle = Managers.Resource.Instantiate(item_angle, transform);
    }

    public GameObject GetShield() { return  shield; }
    public GameObject GetItem_Angle() { return  item_angle; }
}
