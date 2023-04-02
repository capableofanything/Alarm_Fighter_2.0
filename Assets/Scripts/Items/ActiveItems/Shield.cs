using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int durability;
    public float time;

    public bool BlockDamage()
    {
        durability -= 1;
        if (durability <= 0)
        {
            GetComponent<Animator>().Play("Hit");
        }
        return false;

    }
    private void Start()
    {
        StartCoroutine("ActiveBuff");
    }

    public void Destroy()
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
