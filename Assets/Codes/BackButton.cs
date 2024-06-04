using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Game"); // Замініть "GameSceneName" на фактичну назву сцени
    }
}