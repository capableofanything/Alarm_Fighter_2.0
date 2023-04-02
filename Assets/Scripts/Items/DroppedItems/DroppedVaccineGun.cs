using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedVaccineGun : DroppedItem
{
    public float timeAmount = 3f;
    string vaccine = "Items/ActiveItems/VaccineEffect";
    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    
    //when player and the item collides
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Player"))
        {
            PlayerStat stat = go.GetComponent<PlayerStat>();
            Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Sad");
            
            if (stat != null)
            {

                Managers.Resource.Instantiate(vaccine, go.transform);//player arms the item(item instantiates below player)
                Managers.Item.ItemDeSpawn(gameObject);               //destories the item on field


            }
        }
    }

}
