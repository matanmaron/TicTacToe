using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField] GameObject _cellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        List<Cell> cells = new List<Cell>();
        for (int i = 0; i < 9; i++)
        {
            cells.Add(Instantiate(_cellPrefab, transform).GetComponent<Cell>());
        }
        GameManager.Instance.SetCells(cells);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
