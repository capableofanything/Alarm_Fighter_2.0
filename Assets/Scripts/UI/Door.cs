using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private IEnumerator coroutine;
    private string SceneName;

    public void SetName(string name) { SceneName = name; }
    void Start()
    {
        coroutine = MyFunction();
        StartCoroutine(coroutine);
        Managers.Sound.Play("Effects/Door");
    }

    private IEnumerator MyFunction()
    {
        yield return new WaitForSeconds(3.0f);//finish animation time
        StopCoroutine(coroutine);
        if(SceneName != null)
            Managers.Scene.LoadScene(SceneName);
    }

}
