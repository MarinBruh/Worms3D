using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    GameObject currentPoint;
    public GameObject[] Players;

    int index;
    
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        int PlayerIndex = Random.Range (0, Players.Length);
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (Players[PlayerIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
