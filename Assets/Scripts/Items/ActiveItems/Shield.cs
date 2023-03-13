using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int durability;
    public float time;

    public bool BlockDamage()
    {
        if (durability <= 0)
        {
            Destroy();
            return false;
        }
        durability -= 1;
        return true;

    }
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
