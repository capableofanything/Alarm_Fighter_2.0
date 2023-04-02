using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public void Destroy()
    {
        Managers.Destroy(gameObject);
    }
}
