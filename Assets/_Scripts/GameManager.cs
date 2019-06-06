using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public static float score;

    private void Update()
    {
        Debug.Log(score);
    }
}
