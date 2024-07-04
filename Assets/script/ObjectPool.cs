using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] pool;
    [SerializeField] int poolSize=5;
    [SerializeField] float spawnTime=1f;
    [SerializeField] GameObject enemyPrefab;

    private void Awake()
    {
        PopulatePool();
    }
    private void Start()
    {
        
        StartCoroutine(SpawnEnemy());
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab,transform);
            pool[i].SetActive(false);
        }

    }

    void EnableObjectsInPool ()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false) 
            {
                pool[i].SetActive (true);
                return;
            }
        }

    }

    IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
