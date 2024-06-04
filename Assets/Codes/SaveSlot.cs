using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class SaveSlot : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;

    public SaveManager saveManager;

    void Start()
    {
        if (saveManager == null)
        {
            saveManager = FindObjectOfType<SaveManager>();
        }

        saveSlot1.onClick.AddListener(() => SaveGame(1));
        saveSlot2.onClick.AddListener(() => SaveGame(2));
        saveSlot3.onClick.AddListener(() => SaveGame(3));

        UpdateSaveSlotText();
    }

    void SaveGame(int slot)
    {
        if (saveManager != null)
        {
            saveManager.SaveGame(slot);
            UpdateSaveSlotText();
        }
        else
        {
            UnityEngine.Debug.LogError("SaveManager is null.");
        }
    }

    void UpdateSaveSlotText()
    {
        saveSlot1.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save1.dat") ? "Save 1" : "No Save";
        saveSlot2.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save2.dat") ? "Save 2" : "No Save";
        saveSlot3.GetComponentInChildren<UnityEngine.UI.Text>().text = File.Exists(UnityEngine.Application.persistentDataPath + "/save3.dat") ? "Save 3" : "No Save";
    }
}
