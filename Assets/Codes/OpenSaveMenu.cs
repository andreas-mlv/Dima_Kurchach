using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSaveMenu : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("SaveCurrentGame");
    }
}
