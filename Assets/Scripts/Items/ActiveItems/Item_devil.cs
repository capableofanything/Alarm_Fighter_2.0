using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_devil : MonoBehaviour
{
    public float time = 4;

    private void Start()
    {
        StartCoroutine("ActiveBuff");
    }

    private void Destroy()
    {
        //Managers.Resource.Destroy(gameObject);
        Object.Destroy(gameObject);
    }
    IEnumerator ActiveBuff()
    {
        Debug.Log("Active");
        yield return new WaitForSeconds(time);
        Destroy();
    }
}
