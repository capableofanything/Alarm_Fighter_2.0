using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injector : MonoBehaviour
{
    GameObject effect;
    GameObject target;
    private void Start()
    {
        //Util.FindChild<SpriteRenderer>(gameObject, "injector").sortingOrder = Util.FindChild<SpriteRenderer>( transform.parent.gameObject , "���� ��", true).sortingOrder-1;
        target = Managers.Monster.BossMonster;
        effect = Util.FindChild(gameObject, "����Ʈ");

        effect.transform.parent = target.transform;
        Util.LookAtTarget(gameObject, target);
        Util.LookAtTarget(effect, target);



    }
    public void Attack()
    {
        //Managers.Timer.ReduceTime(timeAmount);
        Destroy();
    }

    private void Update()
    {
        effect.transform.position = Vector3.MoveTowards(effect.transform.position, target.transform.position, 20 * Time.deltaTime);

        if (Vector3.Magnitude(effect.transform.position - target.transform.position) <= 0.001)
        {
            Attack();
        }
    }

    void Destroy()
    {
        //Managers.Resource.Destroy(gameObject);
        Object.Destroy(gameObject);
        effect.GetComponent<Animator>().Play("Hit");
    }



}

