using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    HitHandler hitHandler;
    
    void Start()
    {
        hitHandler = new HitHandler_Invincible(GetComponent<PlayerStat>());
    }

    private void Hit()
    {
        hitHandler.Request();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            Hit();
        }
    }
}
