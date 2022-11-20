using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScrollProject.Datas;
using System;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] SpawnData _spawnData;
    [SerializeField]float _maxTime;
    float _currentTime = 0f;
    GameObject _enemyManager;

    void Start()
    {
        _enemyManager = GameObject.FindGameObjectWithTag("EnemyManager");  
        _maxTime = _spawnData.RandomSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxTime && _enemyManager.GetComponent<EnemyManager>().CanSpawn )
        {
            Spawn();
        }
        
    }

    private void Spawn()
    {
        MedusaController medusaController =  Instantiate(_spawnData.Medusa, transform.position, Quaternion.identity);
        _enemyManager.GetComponent<EnemyManager>().AddEnemy(medusaController);

        Debug.Log("Spawned");
        _currentTime = 0f;
        _maxTime = _spawnData.RandomSpawn;
    }
}
