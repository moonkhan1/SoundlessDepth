using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SideScrollProject.Datas
{
[CreateAssetMenu(fileName ="Spawner Data", menuName ="Info/SpawnerData", order =51)]
public class SpawnData : ScriptableObject
{
    [SerializeField] MedusaController _medusa;
    [SerializeField] float _maxSpawnTime = 20f;
    [SerializeField] float _minSpawnTime = 5f;

    public MedusaController Medusa => _medusa;
    public float RandomSpawn => Random.Range(_minSpawnTime, _maxSpawnTime);
}
}
