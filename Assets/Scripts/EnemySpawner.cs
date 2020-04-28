using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float randx;
    public float rate = 3f;
    Vector2 SpawnLoc;
    float spawnNext = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext)
        {
            spawnNext = Time.time + rate;
            randx = Random.Range(-10f, 10f);
            SpawnLoc = new Vector2(randx, transform.position.y);
            Instantiate(enemy, SpawnLoc, Quaternion.identity);
        }
    }


}
