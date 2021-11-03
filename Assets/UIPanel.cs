using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public void StartGame(CellType turn)
    {
        ShowTurn(turn);
    }

    public void ShowTurn(CellType turn)
    {
        Debug.Log($"Turn - {turn}");
    }
}
