using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private int round;
    Animator animator;

    private void Start()
    {
        StartCoroutine(wawes());
    }

    IEnumerator wawes()
    {
        while (true)
        {
            Spawn(0);
            Spawn(1);
            Spawn(2);
            Spawn(3);
            yield return new WaitForSeconds(10f);
        }
    }

    private void Spawn(int spawnPoint)
    {
        int enemy = Random.Range(0, enemyPrefabs.Length);
        
        Instantiate(enemyPrefabs[enemy], spawnPoints[spawnPoint].position, Quaternion.identity);
    }
}
