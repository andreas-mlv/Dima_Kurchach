using System.Diagnostics;
using UnityEngine;

public class StartingCell : MonoBehaviour
{
    private CellData cellData;
    private GameController gameController;

    void Start()
    {
        cellData = GetComponent<CellTap>().cellData;
        gameController = FindObjectOfType<GameController>();
        if (gameController == null)
        {
            UnityEngine.Debug.LogError("GameController not found in the scene.");
        }
    }

    void OnMouseDown()
    {
        if (gameController != null)
        {
            gameController.SetStartingCell(cellData);
        }
    }
}
