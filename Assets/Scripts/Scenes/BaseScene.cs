using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour     //��� �� script�� ��ӹ޴� Ŭ����(���� MonoBehaviour)
{
    [SerializeField]
    protected string soundBgmName;                  //�ش� ���� BGM �̸�
    private IEnumerator coroutine;
    protected void SetBpm(int bpm)
    {
        Managers.Bpm.BPM = bpm;
    }
    private void Awake()
    {
        Init();
        coroutine = SpawnDoorOpenUI();
        StartCoroutine(coroutine);

    }
    protected virtual void Init()                   //EventSystem(Prefab)���� @EventSystem(GameObject)����
    {
        Object obj = GameObject.FindObjectOfType(typeof(EventSystem));      //==GameObject.FindObjectOfType<EventSystem>();
        if (obj == null)
        {
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }
    public abstract void Clear();
    
    protected void SoundBgmPlay()
    {
        Managers.Sound.Play(soundBgmName, Define.Sound.Bgm,1.0f,0.2f);
    }
    protected void CheckingGame()//if -ing game, player alive or monster alive checking manager
    {
        Managers.Resource.Instantiate("Manager/CheckingGame");
    }
    protected IEnumerator SpawnDoorOpenUI()
    {
        Managers.Resource.Instantiate("UI/DoorOpenUI");
        GameObject go = Managers.Sound.GetCurrentBGM();
        go.GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(1.0f);
        go.GetComponent<AudioSource>().Play();
        StopCoroutine(coroutine);

    }
}
