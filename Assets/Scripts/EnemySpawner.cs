using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float xLimit;

    [SerializeField]
    private float[] xpositions;

    [SerializeField]
    private wave[] wave;

    [SerializeField]
    private GameObject[] enemyPrefabs;

    private float currentTime;                              //calcs time past when a wave started

    List<float> remainingPositions = new List<float>();     
    private int waveIndex;                                  //decides which wave to spawn
    float xPos = 0;                                         //position the enemy will spawn
    int rand;                                               //random number

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        remainingPositions.AddRange(xpositions);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy(float xPos)
    {
        int r = Random.Range(0, 1);             //generates random enemy if more than one
        GameObject enemyObj = Instantiate(enemyPrefabs[r], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
    }

    void SelectWave()
    {
        remainingPositions = new List<float>();
        remainingPositions.AddRange(xpositions);
        waveIndex = Random.Range(0, wave.Length);

        if(wave[waveIndex].spawnAmount == 1){
            xPos = Random.Range(-xLimit, xLimit);
        }
        else if(wave[waveIndex].spawnAmount > 1)        //spawn more than 1 enemy
        {
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }

        for (int i = 0; i < wave[waveIndex].spawnAmount; i++)
        {
            SpawnEnemy(xPos);
            rand = Random.Range(0, remainingPositions.Count);
            xPos = remainingPositions[rand];
            remainingPositions.RemoveAt(rand);
        }
    }
}
[System.Serializable]
public class wave
{
    public float DelayTime;
    public float spawnAmount;

}
