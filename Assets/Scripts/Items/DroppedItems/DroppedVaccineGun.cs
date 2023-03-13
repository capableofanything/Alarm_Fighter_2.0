using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedVaccineGun : MonoBehaviour
{
    public float timeAmount = 3f;

    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            //Managers.Timer.ReduceTime(timeAmount);
            Managers.Item.ItemDeSpawn(gameObject);

        }
    }
}
