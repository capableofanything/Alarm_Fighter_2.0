using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgunAttack : MonoBehaviour
{
    
    void Start()
    {
        Invoke("Destroy", 1.0f);
        
    }
    void Update()
    {

        
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
    void Move()
    {

    }
}
