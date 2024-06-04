using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ResourceManager : MonoBehaviour
{
    public UnityEngine.UI.Text woodText;
    public UnityEngine.UI.Text stoneText;

    private int woodAmount = 0;
    private int stoneAmount = 0;

    void Start()
    {
        if (woodText == null)
        {
            UnityEngine.Debug.LogError("Wood Text is not assigned.");
        }

        if (stoneText == null)
        {
            UnityEngine.Debug.LogError("Stone Text is not assigned.");
        }

        LoadResources();
        UpdateResourceText();
    }

    public void AddResources(int wood, int stone)
    {
        woodAmount += wood;
        stoneAmount += stone;
        UpdateResourceText();
        SaveResources();
    }

    void UpdateResourceText()
    {
        if (woodText != null)
        {
            woodText.text = "Wood: " + woodAmount;
        }

        if (stoneText != null)
        {
            stoneText.text = "Stone: " + stoneAmount;
        }
    }

    void SaveResources()
    {
        PlayerPrefs.SetInt("WoodAmount", woodAmount);
        PlayerPrefs.SetInt("StoneAmount", stoneAmount);
    }

    void LoadResources()
    {
        if (PlayerPrefs.HasKey("WoodAmount"))
        {
            woodAmount = PlayerPrefs.GetInt("WoodAmount");
        }

        if (PlayerPrefs.HasKey("StoneAmount"))
        {
            stoneAmount = PlayerPrefs.GetInt("StoneAmount");
        }
    }
}
