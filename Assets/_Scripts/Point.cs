using UnityEngine;

public class Point : MonoBehaviour
{
    
    public float speed;
    Vector3 originalPos;
    Vector3 destination;
    float scoreVar;

    private void Start()
    {
        originalPos = this.transform.position;
        destination = new Vector3(originalPos.x, -originalPos.y, originalPos.z);
    }
    private void Update()
    {
        scoreVar = GameManager.score;
        Move();
        SpeedControl();
    }

    public void Move()
    {
        Vector3 pos = Vector3.MoveTowards(
            this.transform.position, destination, Time.deltaTime * speed);
        pos.x = originalPos.x;
        pos.z = originalPos.z;
        transform.position = pos;
    }

    public void SpeedControl()
    {
        if (GameManager.isGameOver)
        {
            scoreVar = 0f;
        }
        if (scoreVar >= 14 && scoreVar < 30)
            Time.timeScale = 1.2f;
        if (scoreVar >= 30 && scoreVar < 50)
            Time.timeScale = 1.4f;
        if (scoreVar >= 50 && scoreVar < 80)
            Time.timeScale = 1.6f;
        if (scoreVar >= 80 && scoreVar<100)
            Time.timeScale = 1.8f;
        if (scoreVar >= 100)
            Time.timeScale = 2f;
    }
}
