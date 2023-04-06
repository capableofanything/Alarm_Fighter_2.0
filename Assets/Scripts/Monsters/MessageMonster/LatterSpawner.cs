using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatterSpawner : MonoBehaviour
{
    [SerializeField]
    private float width;
    [SerializeField]
    List<string> objects = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 SetLocation()
    {
        float x = Random.Range(transform.position.x - width, transform.position.x + width);
        return new Vector3(x, transform.position.y, 0);
    }
    
    public void SpawnLatter()
    {
        int rand = Random.Range(0, objects.Count - 1);
        GameObject go = Managers.Resource.Instantiate(objects[rand]);
        go.transform.position = SetLocation();
        StartCoroutine("DestroyLatter", go);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyLatter(GameObject go)
    {
        yield return new WaitForSeconds(8f);
        Managers.Resource.Destroy(go);
    }
}
