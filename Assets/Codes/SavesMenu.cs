using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

public class SavesMenu : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;
    //public Button backButton;

    void Start()
    {
        LoadSaveGames();
        //backButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
    }

    void LoadSaveGames()
    {
        // Завантажити інформацію про збереження
        string save1 = PlayerPrefs.GetString("Save_1", "No Save");
        string save2 = PlayerPrefs.GetString("Save_2", "No Save");
        string save3 = PlayerPrefs.GetString("Save_3", "No Save");

        saveSlot1.GetComponentInChildren<UnityEngine.UI.Text>().text = save1;
        saveSlot2.GetComponentInChildren<UnityEngine.UI.Text>().text = save2;
        saveSlot3.GetComponentInChildren<UnityEngine.UI.Text>().text = save3;

        saveSlot1.onClick.AddListener(() => LoadGame(1));
        saveSlot2.onClick.AddListener(() => LoadGame(2));
        saveSlot3.onClick.AddListener(() => LoadGame(3));
    }

    void LoadGame(int slot)
    {
        // Перевірити, чи є збереження
        if (PlayerPrefs.HasKey("Save_" + slot))
        {
            PlayerPrefs.SetInt("CurrentSaveSlot", slot);
            SceneManager.LoadScene("Game");
        }
        else
        {
            UnityEngine.Debug.LogError("No save found in slot " + slot);
        }
    }
}