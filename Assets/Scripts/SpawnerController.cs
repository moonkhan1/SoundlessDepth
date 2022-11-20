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

        if (_currentTime > _maxTime && _enemyManager.GetComponent<EnemyManager>().CanSpawnPearl )
        {
            SpawnPearl();
        }
        
    }

    private void Spawn()
    {
        if(_spawnData.Medusa == null) return;

        MedusaController medusaController =  Instantiate(_spawnData.Medusa, transform.position, Quaternion.identity);
        StartCoroutine(WaitAndKill(20, medusaController));
        _enemyManager.GetComponent<EnemyManager>().AddEnemy(medusaController);

        Debug.Log("Spawned");
        _currentTime = 0f;
        _maxTime = _spawnData.RandomSpawn;
    }

    private void SpawnPearl()
    {
        if(_spawnData.Pearl == null) return;

        CollectiableController pearl =  Instantiate(_spawnData.Pearl, transform.position, Quaternion.identity);
        StartCoroutine(WaitAndDestroy(20, pearl));
        _enemyManager.GetComponent<EnemyManager>().AddPearl(pearl);

        Debug.Log("Spawned Pearl");
        _currentTime = 0f;
        _maxTime = _spawnData.RandomSpawn;
    }

     IEnumerator WaitAndKill(int interval, MedusaController _medusaController)
     {
        while (true)
        {

            yield return new WaitForSeconds(interval);
            if (_medusaController != null)
            {
            Destroy(_medusaController.gameObject);
            _enemyManager.GetComponent<EnemyManager>().RemoveEnemy(_medusaController);
                
            }
        }
     }

     IEnumerator WaitAndDestroy(int interval, CollectiableController _pearl)
     {
        while (true)
        {

            yield return new WaitForSeconds(interval);
            if (_pearl != null)
            {
            Destroy(_pearl.gameObject);
            _enemyManager.GetComponent<EnemyManager>().RemovePearl(_pearl);
                
            }
        }
     }
}
