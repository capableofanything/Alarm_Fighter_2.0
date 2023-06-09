using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

enum LobbyState
{
    Ready,
    Scan,
    ScanEnd,
    Finish,
    
}
public class LobbyUI : MonoBehaviour
{
    LobbyState state = LobbyState.Ready;
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Button scanBtn;


    public void SetState(int state)
    {
        this.state = (LobbyState)state;
    }


    private void Update()
    {
        switch(state)
        {
            case LobbyState.Ready:
                UpdateReady();
                break;
            case LobbyState.Scan:
                UpdateScan();
                break;
            case LobbyState.ScanEnd:
                UpdateScanEnd();
                break;
            case LobbyState.Finish:
                UpdateFinish();
                break;
        }
    }

    private void UpdateReady()
    {
        if (Managers.Game.NextStage != Define.GameSceneOrder.TimeScene_main)
        {
            progressBar.fillAmount = (float)(Managers.Game.NextStage - 1) / (float)Define.GameSceneOrder.Count;
        }
    }
    private void UpdateScan()
    {
        UpdateProgress();

    }
    private void UpdateScanEnd()
    {
        progressBar.color = Color.red;

    }
    private void UpdateFinish()
    {
        if(scanBtn.interactable)
            scanBtn.interactable = false;
    }


    private void UpdateProgress()
    {
        float progress = (float)Managers.Game.NextStage /  (float)Define.GameSceneOrder.Count;
        if(progressBar.fillAmount == 1)
        {
            //End!!
            Debug.Log("end");
            state = LobbyState.Finish;
            GetComponent<Animator>().Play("Finish");
        }
        if(progressBar.fillAmount <= progress)
        {
            progressBar.fillAmount += 0.08f * Time.deltaTime;

        }
        else
        {
            state = LobbyState.ScanEnd;
            Util.FindChild(gameObject, $"{Managers.Game.NextStage}_Btn", true).GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("ScanEnd", true);

        }
    }
    public void Reset()
    {
        progressBar.fillAmount = 0;
        scanBtn.interactable = true;
        state = LobbyState.Ready;
        GetComponent<Animator>().Play("Idle");
    }

}
