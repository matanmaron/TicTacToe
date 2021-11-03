using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    Cell[] board;

    public void SetCells(List<Cell> cells)
    {
        board = cells.ToArray();
    }

    public void AfterTurnChecks()
    {
        if (isFullBoard())
        {
            Debug.Log("board full, game over");
        }
        var status = IsWinning();
        switch (status)
        {
            case CellType.None:
                break;
            case CellType.X:
                Debug.Log("x wins, game over");
                break;
            case CellType.O:
                Debug.Log("o wins, game over");
                break;
            default:
                break;
        }
    }

    private CellType IsWinning()
    {
        //row
        for (int i = 0; i < board.Length; i += 3)
        {
            if (board[i].CellValue == board[i + 1].CellValue && board[i + 1].CellValue == board[i + 2].CellValue && board[i].CellValue != CellType.None)
            {
                return board[i].CellValue;
            }
        }
        //column
        for (int i = 0; i < 3; i++)
        {
            if (board[i].CellValue == board[i + 3].CellValue && board[i + 3].CellValue == board[i + 6].CellValue && board[i].CellValue != CellType.None)
            {
                return board[i].CellValue;
            }
        }
        //diagonal
        if (board[0].CellValue == board[4].CellValue && board[4].CellValue == board[8].CellValue && board[0].CellValue != CellType.None)
        {
            return board[0].CellValue;
        }
        if (board[2].CellValue == board[4].CellValue && board[4].CellValue == board[6].CellValue && board[2].CellValue != CellType.None)
        {
            return board[2].CellValue;
        }
        return CellType.None;
    }

    bool isFullBoard()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i].CellValue == CellType.None)
            {
                return false;
            }
        }
        return true;
    }
}
