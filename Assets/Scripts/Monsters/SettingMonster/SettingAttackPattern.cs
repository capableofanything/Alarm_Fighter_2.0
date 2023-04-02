using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAttackPattern : MonoBehaviour
{
    public delegate void FunctionPointer();
    public List<FunctionPointer> noteBarList_1;
    public List<FunctionPointer> noteBarList_2;
    public List<FunctionPointer> noteBarList_3;

    private IEnumerator coroutine;
    float del_time = 0.9f;
    float temp;
    void Start()
    {
        coroutine = MyFunction();
        StartCoroutine(coroutine);
    }

    private IEnumerator MyFunction()
    {
        yield return new WaitForSeconds(3.27f);
        Special();

        yield return new WaitForSeconds(0.91f);
        Special();
        Init();
        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.95f);
        Special();

        yield return new WaitForSeconds(0.88f);
        Special();

        yield return new WaitForSeconds(0.99f);
        Special();

        yield return new WaitForSeconds(0.91f);
        Special();

        yield return new WaitForSeconds(0.93f);
        Special();

        yield return new WaitForSeconds(0.90f);//10.72sec
        Special();

        yield return new WaitForSeconds(0.24f);//10.96sec
        Special();
        yield return new WaitForSeconds(0.22f);//11.18sec
        Special();
        yield return new WaitForSeconds(0.52f);//11.70sec
        Special();

        yield return new WaitForSeconds(0.97f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.97f);
        Special();

        yield return new WaitForSeconds(0.49f);
        Special();

        yield return new WaitForSeconds(0.47f);
        Special();

        yield return new WaitForSeconds(0.89f);
        Special();

        yield return new WaitForSeconds(0.93f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.99f);
        Special();

        yield return new WaitForSeconds(0.84f);
        Special();

        yield return new WaitForSeconds(1.0f);
        Special();

        yield return new WaitForSeconds(0.9f);
        Special();

        yield return new WaitForSeconds(0.95f);
        Special();

        yield return new WaitForSeconds(0.98f);
        Special();

        yield return new WaitForSeconds(0.96f);
        Special();
        yield return new WaitForSeconds(0.9f);
        Special();

        yield return new WaitForSeconds(0.94f);
        Special();

        yield return new WaitForSeconds(0.92f);
        Special();

        yield return new WaitForSeconds(0.97f);//29.59
        Special();
        int i = 1;
        while (true)
        {
            yield return new WaitForSeconds(del_time);
            temp += 0.9f;
            if(temp>10)
            {
                del_time += 0.1f;
                GameObject go = Managers.Sound.GetCurrentBGM();
                go.GetComponent<AudioSource>().pitch = 0.8f;
                if(i%2==0)
                {
                    Middle();
                    i++;
                }
                else
                {
                    Column2();
                    i++;
                }
            }
            Special();
            if (!Managers.Monster.IsAlive()) { StopAllCoroutines(); }
        }
        
    }

    public void Init()
    {
        noteBarList_1 = new List<FunctionPointer>() { Row1, Column1, Row2, Column2 };
        noteBarList_2 = new List<FunctionPointer>() { Row2, Column1, Row3, Column3 };
        noteBarList_3 = new List<FunctionPointer>() { Agun, Rest, Agun, Rest };
    }
   
    private void Special()
    {
        DarkModeAttack();
    }
    public void Rest()
    {
        //does nothing
    }

    private void Row1()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(0, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row2()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(1, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Row3()
    {
        for (int i = 0; i < Managers.Field.GetWidth(); i++)
        {
            Managers.Field.GetGrid(2, i).GetComponent<Animator>().SetTrigger("Row");
        }
    }
    private void Column1()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 0).GetComponent<Animator>().SetTrigger("Column");
        }
    }
    private void Column2()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 1).GetComponent<Animator>().SetTrigger("Column");
        }
    }
    private void Column3()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            Managers.Field.GetGrid(i, 2).GetComponent<Animator>().SetTrigger("Column");
        }
    }
    private void Middle()
    {
        Managers.Field.GetGrid(1, 1).GetComponent<Animator>().SetTrigger("Column");
    }
    private void Cross()
    {
        for (int i = 0; i < Managers.Field.GetHeight(); i++)
        {
            for( int j=0;j< Managers.Field.GetWidth(); j++)
            {
                if (i==j)
                    continue;
                Managers.Field.GetGrid(i, j).GetComponent<Animator>().SetTrigger("Column");
            }
        }
    }

    private void Agun()
    {
        Managers.Field.GetGrid(0, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(0, 2).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 0).GetComponent<Animator>().SetTrigger("One");
        Managers.Field.GetGrid(2, 2).GetComponent<Animator>().SetTrigger("One");
        Invoke("Instantiate_Agun", 0.25f);
    }
    private void Instantiate_Agun()
    {
        AgunAttack();
        AgunFieldAttack();
    }

    public List<List<FunctionPointer>> CreateCallOrderList()
    {
        List<List<FunctionPointer>> callOrderList = new List<List<FunctionPointer>>();
        
        callOrderList.Add(noteBarList_1);
        callOrderList.Add(noteBarList_2);
        callOrderList.Add(noteBarList_3);
        return callOrderList;
    }

    #region settingattackpattern

    public void AgunAttack() 
    { 
        AgunInit();
        //Managers.Sound.Play("Effects/Tantacle01", Define.Sound.Effect, 1.0f, 0.01f);
    }
    public void AgunFieldAttack()
    {
        Managers.Resource.Instantiate("Monsters/SettingMonster/Effects/AgunFieldAttack");

    }
    #region Agun_Private
    private void AgunInit()
    {     
        GameObject go = Managers.Resource.Instantiate("Monsters/SettingMonster/Effects/Agun");
    }
    #endregion

    public void DarkModeAttack()
    {
        DarkModeInit();
    }
    #region DarkMode_Private
    private void DarkModeInit()
    {
        GameObject go = Managers.Resource.Instantiate("Monsters/SettingMonster/Effects/DarkMode");
    }
    #endregion

    int BlackThunderNum = 0;
    List<String> BlackThunderArray = new List<string>() { "Thunder0", "Thunder1", "Thunder2" };
    public void BlackThunderAttack()
    {
        BlackThunderInit(Managers.Field.GetIndex_X(gameObject), Managers.Field.GetIndex_Y(gameObject));
        //Managers.Sound.Play("Effects/Tantacle01", Define.Sound.Effect, 1.0f, 0.01f);
    }
    #region Black ThunderAttack Private
    private void BlackThunderInit(int x, int y)
    {
        GameObject go = Managers.Resource.Load<GameObject>($"Prefabs/Monsters/SettingMonster/Effects/{BlackThunderArray[BlackThunderNum]}");
        GameObject Thunder = Instantiate<GameObject>(go);
        Managers.Field.ScaleByRatio(Thunder, x, y);
        FieldInfo fieldInfo = Managers.Field.GetFieldInfo(x, y);
        Thunder.transform.localScale = new Vector3(1.5f, 2.0f, 1f) * fieldInfo.ratio;
        Thunder.transform.position = fieldInfo.grid.transform.position;

        BlackThunderNum++;
        if (BlackThunderNum > 2)
            BlackThunderNum = 0;
    }
    #endregion
    #endregion
}
