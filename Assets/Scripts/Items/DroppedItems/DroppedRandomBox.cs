using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Type
{
    BENEFIT,
    HARM,

}
public class DroppedRandomBox : MonoBehaviour
{
    public float BuffTime = 3f;
    string benefit = "Items/ActiveItems/Item_Angle";
    string harm = "Items/ActiveItems/Item_Angle";
    Type type;

    private void Start()
    {
        int rand = Random.Range(0, 0);

        if (rand == 0)
            type = Type.BENEFIT;
        else
            type = Type.HARM;

    }

    public void Active()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject go = collision.gameObject;
        if (!go.CompareTag("Player"))
            return;

        PlayerStat player = go.GetComponent<PlayerStat>();
        if (player != null)
        {
            switch (type)
            {
                case Type.BENEFIT:
                    player.FillInvincible(benefit);
                    Managers.Item.ItemDeSpawn(gameObject);

                    break;
                case Type.HARM:
                    //player.ReverseKey(BuffTime);
                    Managers.Item.ItemDeSpawn(gameObject);

                    break;
            }
        }

    }
}
