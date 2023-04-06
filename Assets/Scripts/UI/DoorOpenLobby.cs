using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenLobby : MonoBehaviour
{
    private IEnumerator coroutine;
    void Start()
    {

    }

    void Update()
    {
        //Managers.Sound.Play("Effects/Door", Define.Sound.Effect, 1.0f, 0.1f);
        GameObject go = Managers.Sound.GetCurrentBGM();
        go.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0.01f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        coroutine = MyFunction(go);
        StartCoroutine(coroutine);
    }

    private IEnumerator MyFunction(GameObject go)
    {
        yield return new WaitForSeconds(0.03f);//finish animation time
        StopCoroutine(coroutine);
        Managers.Resource.Instantiate("UI/Lobby");
        Time.timeScale = 1.0f;
        go.GetComponent<AudioSource>().Play();
        Managers.Resource.Destroy(gameObject);
    }
}
