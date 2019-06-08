using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float time = 2.5f;
    public void Start()
    {
        StartCoroutine(SplashScreenTimer(time));
    }

    IEnumerator SplashScreenTimer(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(1);
    }
}
