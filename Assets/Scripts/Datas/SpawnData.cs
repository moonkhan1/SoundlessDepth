using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SideScrollProject.Datas
{
[CreateAssetMenu(fileName ="Spawner Data", menuName ="Info/SpawnerData", order =51)]
public class SpawnData : ScriptableObject
{
    [SerializeField] MedusaController _medusa;
    [SerializeField] CollectiableController _pearl;
    [SerializeField] float _maxSpawnTime = 15f;
    [SerializeField] float _minSpawnTime = 5f;

    public MedusaController Medusa => _medusa;
    public CollectiableController Pearl => _pearl;
    public float RandomSpawn => Random.Range(_minSpawnTime, _maxSpawnTime);
}
}
