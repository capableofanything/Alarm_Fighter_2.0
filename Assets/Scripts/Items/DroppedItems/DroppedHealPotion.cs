using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedHealPotion : MonoBehaviour
{
    public float healPower = 2;

    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if(go.CompareTag("Player"))
        {
            PlayerStat stat = go.GetComponent<PlayerStat>();
            if (stat != null)
            {
                stat.FillHp(healPower);
                Managers.Item.ItemDeSpawn(gameObject);
            }
        }
    }
}
