using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager
{
    private Player currentPlayer;
    private bool alive = true;
    public void SetPlayer(Player player) { this.currentPlayer = player; Init(); }
    public void Init() { this.alive = true; }
    public Transform GetCurrentTransform() { return currentPlayer.transform; }
    public float GetCurrentPositionX() { return currentPlayer.transform.position.x; }
    public float GetCurrentPositionY() { return currentPlayer.transform.position.y; }
    public int GetCurrentIndX() { return currentPlayer.GetPlayerCurrentIndX(); }
    public int GetCurrentIndY() { return currentPlayer.GetPlayerCurrentIndY(); }
    public bool IsAlive() { return alive; }
    public void SetAlive(bool alive) { this.alive = alive; }
}
