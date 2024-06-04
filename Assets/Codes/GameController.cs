using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Resources;

public class GameController : MonoBehaviour
{
    public Button nextTurnButton;
    public UnityEngine.UI.Text turnCounterText;
    public ResourceManager resourceManager;
    private int turnCounter = 0;
    private CellData startingCell;

    void Start()
    {
        if (nextTurnButton != null)
        {
            nextTurnButton.onClick.AddListener(OnNextTurnButtonClicked);
        }
        else
        {
            UnityEngine.Debug.LogError("Next Turn Button is not assigned.");
        }

        if (turnCounterText != null)
        {
            LoadGameState();
            UpdateTurnCounterText();
        }
        else
        {
            UnityEngine.Debug.LogError("Turn Counter Text is not assigned.");
        }

        if (resourceManager == null)
        {
            UnityEngine.Debug.LogError("Resource Manager is not assigned.");
        }
    }

    void OnNextTurnButtonClicked()
    {
        turnCounter++;
        AddResourcesFromStartingCell();
        UpdateTurnCounterText();
        SaveGameState();
    }

    void UpdateTurnCounterText()
    {
        if (turnCounterText != null)
        {
            turnCounterText.text = "Turn: " + turnCounter;
        }
    }

    void AddResourcesFromStartingCell()
    {
        if (resourceManager == null)
        {
            UnityEngine.Debug.LogError("Resource Manager is not assigned.");
            return;
        }

        if (startingCell != null)
        {
            resourceManager.AddResources(startingCell.wood, startingCell.stone);
        }
    }

    void SaveGameState()
    {
        PlayerPrefs.SetInt("TurnCounter", turnCounter);
        if (startingCell != null)
        {
            PlayerPrefs.SetInt("StartingCellNumber", startingCell.cellNumber);
        }
    }

    void LoadGameState()
    {
        if (PlayerPrefs.HasKey("TurnCounter"))
        {
            turnCounter = PlayerPrefs.GetInt("TurnCounter");
        }

        if (PlayerPrefs.HasKey("StartingCellNumber"))
        {
            int startingCellNumber = PlayerPrefs.GetInt("StartingCellNumber");
            startingCell = CellDataManager.LoadCellData(startingCellNumber);
        }
    }

    public void SetStartingCell(CellData cellData)
    {
        startingCell = cellData;
        SaveGameState();
    }

    public void SaveAndSwitchScene(string sceneName)
    {
        SaveGameState();
        SceneManager.LoadScene(sceneName);
    }
}
