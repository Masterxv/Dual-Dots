using UnityEngine;

public class Point : MonoBehaviour
{
    public  float speed;
    Vector3 originalPos;
    Vector3 destination;

    private void Start()
    {
        originalPos = this.transform.position;
        destination = new Vector3(originalPos.x, -originalPos.y, originalPos.z);
    }
    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 pos = Vector3.MoveTowards(
            this.transform.position, destination, Time.deltaTime * speed);
        pos.x = originalPos.x;
        pos.z = originalPos.z;
        transform.position = pos;
    }
}
