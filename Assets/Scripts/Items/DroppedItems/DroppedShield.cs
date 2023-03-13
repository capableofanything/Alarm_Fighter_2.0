using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedShield : MonoBehaviour
{
    string Shield = "Items/ActiveItems/Shield";

    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            PlayerStat stat = go.GetComponent<PlayerStat>();
            if (stat != null)
            {
                stat.FillShield(Shield);
                Debug.Log("fillshield");
                Managers.Item.ItemDeSpawn(gameObject);

            }
        }
    }
}
