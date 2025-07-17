using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMain : MonoBehaviour
{
    bool zombieExists = false;

    [Header("Drag and Drop Here")]
    public GameObject thingToSpawn;

    [Header("Spawn Settings")]
    public GameObject spawnLoc; 
    public float spawnDelay = 1f; 

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopAllCoroutines();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine (SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (zombieExists)  
        {
            if (thingToSpawn != null)
            {
                Instantiate(thingToSpawn, spawnLoc.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("5assign a thing to spawn in the Inspector!", this);
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
