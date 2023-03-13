using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridBaseSpawn : MonoBehaviour
{
    public int maxItem = 4;
    public float delay = 10f;

    int currentItem = 0;
    double currentTime = 0;
    // Start is called before the first frame update



    public void ItemDestroy(GameObject go)
    {
        Debug.Log("Destroy");
        Managers.Resource.Destroy(go);
        currentItem--;
    }



    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentItem >= maxItem)
            return;
        if(currentTime >= delay)
        {
            int x, y;
            
            CalculateLocation(out x, out y);
            Managers.Item.ItemSpawn(x, y);
            currentItem += 1;
            currentTime = 0;
        }

    }


    // Update is called once per frame

    void CalculateLocation(out int x, out int y)
    {
        int rangeX = Managers.Field.GetWidth();
        int rangeY = Managers.Field.GetHeight();
        while (true)
        {
            int tempX = Random.Range(0, rangeX);
            int tempY = Random.Range(0, rangeY);

            if (!(Managers.Field.GetFieldInfo(tempX, tempY).spawnable))
                continue;


            x = tempX;
            y = tempY;
            return;

        }


    }
}
