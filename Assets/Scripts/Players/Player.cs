using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int currentX, currentY;
    private int moveX, moveY;

    public int GetPlayerCurrentIndX() { return currentX; }
    public int GetPlayerCurrentIndY() {  return currentY; }

    void Start()
    {
        currentX = Managers.Field.GetWidth() / 2;
        currentY = Managers.Field.GetHeight() / 2;
        this.transform.position = Managers.Field.GetGrid(currentX, currentY).transform.position;
        Managers.Field.ScaleByRatio(gameObject, currentX, currentY);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&Managers.Player.IsAlive())
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 pos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
                
            if (hit.collider != null)
            {
                moveX = Managers.Field.GetIndex_X(hit.collider.gameObject);
                moveY = Managers.Field.GetIndex_Y(hit.collider.gameObject);
                //this.transform.position = hit.collider.transform.position;
                if((Mathf.Abs(moveX - currentX) <= 1) && (Mathf.Abs(moveY - currentY) <= 1))
                {
                    if (currentX == moveX && currentY == moveY) return;
                    this.transform.position = Managers.Field.GetGrid(moveX, moveY).transform.position;
                    currentX = moveX;
                    currentY = moveY;
                    Managers.Sound.Play("Effects/Move06", Define.Sound.Effect, 1.0f, 1.0f);
                }
            }
        }
        //float HP = GetComponent<PlayerStat>().CurrentHP;
        //Debug.Log("Current HP" + HP);
    }
}
