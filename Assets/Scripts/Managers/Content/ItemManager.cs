using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    List<string> itemList;
    GameObject pool; 

    public GameObject ItemSpawn(int x, int y)
    {
        int rand = Random.Range(0, itemList.Count);
        GameObject grid = Managers.Field.GetGrid(x, y);
        GameObject item = Managers.Resource.Instantiate(itemList[rand], grid.transform);

        return item;
    }
    
    public void ItemDeSpawn(GameObject go)
    {
        pool.GetComponent<GridBaseSpawn>().ItemDestroy(go);
    }

    public void Init()
    {
        SetWeaponList();
        pool = Managers.Resource.Instantiate("Items/@ItemSpawn");
    }

    public void SetWeaponList()
    {
        //to do : player 캐릭터에 따라 weaponList 바뀌게
        itemList = new List<string>();
        itemList.Add("Items/DroppedItems/DroppedShield");
        itemList.Add("Items/DroppedItems/DroppedHealPotion");
        itemList.Add("Items/DroppedItems/DroppedRandomBox");
        itemList.Add("Items/DroppedItems/DroppedVaccineGun");
    }
}
