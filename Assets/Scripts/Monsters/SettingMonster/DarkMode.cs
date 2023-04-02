using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMode : MonoBehaviour
{
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Invoke("Destroy", 0.25f);
    }

    void Update()
    {
        //float alpha = rend.color.a;

        //rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, alpha);
    }
    void Destroy()
    {
        Managers.Resource.Destroy(gameObject);
    }
}

