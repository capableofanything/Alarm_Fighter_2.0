using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageMonster : MonoBehaviour
{
    [SerializeField]
    Transform beak;
    [SerializeField]
    Transform body;

    // Start is called before the first frame update



    public void BeakAttack(int x, int y)
    {

        beak.position = Managers.Field.GetGrid(x, y).transform.position;
        LookAtTarget(beak.gameObject, body.gameObject );

    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("ddf");
            BeakAttack(0, 0);

        }

    }
    void LookAtTarget(GameObject go, GameObject target)
    {
        float z = Mathf.Atan2(target.transform.position.y - go.transform.position.y, target.transform.position.x - go.transform.position.x) * Mathf.Rad2Deg;
        
        Quaternion angleAxis  = Quaternion.AngleAxis(z - 90f, Vector3.forward);
        go.transform.rotation = angleAxis;
    }
}
