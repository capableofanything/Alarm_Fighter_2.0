using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Defalut1_1, Defalut1_2, Defalut1_1, Defalut1_2 };
        noteBarList_2 = new List<FunctionPointer>() { Rest, Agun, Rest, Agun };
        // ������ �����ϴ� �κ� �߰� �ʿ�
    }
    private void Rest()
    {
        //does nothing
    }
    // field�� �ִϸ��̼��� ���͸��� �˸��� �ִϸ��̼� �̸����� �ٲ��־�� ��. (������ �̹� ������� ī�޶� ���� �˼� One���� ����)
    private void Defalut1_1()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }
    private void Defalut1_2()
    {
        Managers.Field.GetGrid(1, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 1).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(1, 2).GetComponent<Animator>().SetTrigger("One");
    }

    private void Agun()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
    }

    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();
        
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);

        return callOrderList;
    }

    // attack pattern ����ֱ�
    #region settingattackpattern

    #endregion
}
