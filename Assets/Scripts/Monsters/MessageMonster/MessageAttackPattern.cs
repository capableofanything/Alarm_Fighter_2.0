using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { One, Rest, One, Rest };
        noteBarList_2 = new List<FunctionPointer>() { Row, Rest, Column, Rest };
        noteBarList_3 = new List<FunctionPointer>() { One, Rest, One, Rest };
    }

    private void Rest()
    {
        //does nothing
    }

    private void One()
    {
        int xrand = (int)Random.Range(1, 3);
        int yrand = (int)Random.Range(0, 3);

        Managers.Field.GetGrid(xrand, yrand).GetComponent<Animator>().SetTrigger("MessageOne");
        Invoke("ActivateOneAttackAnim", 0.1f);
    }
    private void Column()
    {
        Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Message_WingAttack");
        //ActivateFeatherEffect();
        int colInd = (int)Random.Range(0, 3);
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(i, colInd).GetComponent<Animator>().SetTrigger("MessageRow");
        }
    }
    private void Row()
    {
        Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Message_WingAttack");
        //ActivateFeatherEffect();
        int rowInd = (int)Random.Range(0, 3);
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(rowInd, i).GetComponent<Animator>().SetTrigger("MessageRow");
        }
    }
 
    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();

        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);
        callOrderList.Add(noteBarList_3);

        return callOrderList;
    }

    // attack pattern 집어넣기
    #region messageattackpattern
    public void ActivateOneAttackAnim()
    {
        Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Message_Attack");
    }

    public void MessageOneAttack()
    {
        MessageOneAttackInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
    }
    private void MessageOneAttackInit(int x, int y)
    {
        //Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Message_Attack");

        //Managers.Monster.BossMonster.GetComponent<Animator>().SetTrigger("Message_Attack");
        Managers.Monster.BossMonster.GetComponent<MessageMonster>().BeakAttack(x, y);

        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/MessageMonster/Effects/MessageBeakAttack");
        GameObject beak = Instantiate(go);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);
        beak.transform.position = fieldInfo.grid.transform.position;
        Managers.Sound.Play("MessageMonster/OneAttack", Define.Sound.Effect, 1.0f, 0.1f);
    }


    public void MessageRowAttack()
    {
        MessageRowAttackInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
    }

    private void ActivateFeatherEffect()
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/MessageMonster/Effects/FeatherEffect");
        GameObject effect = Instantiate(go);
    }

    private void MessageRowAttackInit(int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/MessageMonster/Effects/MessageFeatherAttack");
        GameObject feather = Instantiate(go);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);
        feather.transform.position = fieldInfo.grid.transform.position;
        Managers.Sound.Play("MessageMonster/FeatherAttack", Define.Sound.Effect, 1.0f, 0.1f);
    }
    #endregion
}
