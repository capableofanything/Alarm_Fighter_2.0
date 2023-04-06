using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    void Start()
    {
        //Managers.Sound.Play("Effects/Door",Define.Sound.Effect,1.0f,0.1f);
        Invoke("Destroy", 1.05f);
    }

    void Update()
    {
 
    }
    void Destroy()
    {
        Managers.Destroy(gameObject);
    }
}
