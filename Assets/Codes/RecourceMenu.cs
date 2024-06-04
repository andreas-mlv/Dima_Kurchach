using UnityEngine;
using UnityEngine.SceneManagement;

public class RecourceMenu : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("ResourceScene"); // Замініть "GameSceneName" на фактичну назву сцени
    }
}