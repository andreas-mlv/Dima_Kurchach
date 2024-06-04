using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SaveLoadMenu : MonoBehaviour
{
    public Button loadSlot1;
    public Button loadSlot2;
    public Button loadSlot3;

    public SaveManager saveManager;

    void Start()
    {
        if (saveManager == null)
        {
            saveManager = FindObjectOfType<SaveManager>();
        }

        loadSlot1.onClick.AddListener(() => LoadGame(1));
        loadSlot2.onClick.AddListener(() => LoadGame(2));
        loadSlot3.onClick.AddListener(() => LoadGame(3));


        UpdateLoadSlotText();
    }

    void LoadGame(int slot)
    {
        if (saveManager != null)
        {
            saveManager.LoadGame(slot);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        else
        {
            UnityEngine.Debug.LogError("SaveManager is null.");
        }
    }

    void UpdateLoadSlotText()
    {
        loadSlot1.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save1.dat") ? "Save 1" : "No Save";
        loadSlot2.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save2.dat") ? "Save 2" : "No Save";
        loadSlot3.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save3.dat") ? "Save 3" : "No Save";
    }
}
