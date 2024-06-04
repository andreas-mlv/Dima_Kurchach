using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    void OnMouseDown()
    {
        PlayerPrefs.DeleteAll(); // Очистити всі збережені дані для нової гри
        SceneManager.LoadScene("Game"); // Завантажити сцену гри
    }
}
