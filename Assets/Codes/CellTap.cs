using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CellTap : MonoBehaviour
{
    public CellData cellData;

    private void OnMouseDown()
    {
        if (cellData != null)
        {
            CellDataTransfer.SelectedCellData = cellData;
            SceneManager.LoadScene("CellDetailScene");
        }
        else
        {
            UnityEngine.Debug.LogError("CellData is null");
        }
    }
}