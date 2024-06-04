using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    public Button saveSlot1;
    public Button saveSlot2;
    public Button saveSlot3;
    public Button backButton;
    public SaveManager saveManager;

    void Start()
    {
        if (saveManager == null)
        {
            UnityEngine.Debug.LogError("SaveManager is not assigned.");
            return;
        }

        saveSlot1.onClick.AddListener(() => SaveGame(1));
        saveSlot2.onClick.AddListener(() => SaveGame(2));
        saveSlot3.onClick.AddListener(() => SaveGame(3));
        backButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
    }

    void SaveGame(int slot)
    {
        if (saveManager != null)
        {
            saveManager.SaveGame(slot);
        }
        else
        {
            UnityEngine.Debug.LogError("SaveManager is null.");
        }
    }
}
