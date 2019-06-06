using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject whitePoint;
    public GameObject blackPoint;

    public float spawnTime;
    public float spawnDelay;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnDelay);
    }

    public void Spawn()
    {
        int decider = Random.Range(0, 2);
        if (decider == 0)
            Instantiate(whitePoint, this.transform.position,this.transform.rotation);
        else if (decider == 1)
            Instantiate(blackPoint, this.transform.position,this.transform.rotation);
    }
}
