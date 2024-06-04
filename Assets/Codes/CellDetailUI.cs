using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class CellDetailUI : MonoBehaviour
{
    public UnityEngine.UI.Text cellNumberText;
    public UnityEngine.UI.Text terrainTypeText;
    public UnityEngine.UI.Text woodText;
    public UnityEngine.UI.Text stoneText;
    public UnityEngine.UI.Image terrainTypeIcon;
    public Sprite[] terrainTypeIcons;

    void Start()
    {
        CellData cellData = CellDataTransfer.SelectedCellData;
        if (cellData == null)
        {
            UnityEngine.Debug.LogError("Selected CellData is null");
            return;
        }

        cellNumberText.text = "Cell Number: " + cellData.cellNumber;
        terrainTypeText.text = "Terrain Type: " + cellData.terrainType;
        woodText.text = "Wood: " + cellData.wood;
        stoneText.text = "Stone: " + cellData.stone;

        terrainTypeIcon.sprite = terrainTypeIcons[(int)cellData.terrainType];
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}
