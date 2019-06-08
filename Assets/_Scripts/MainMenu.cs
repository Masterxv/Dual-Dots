using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
