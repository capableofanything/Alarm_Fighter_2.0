using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgunCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 0.5f);
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
}
