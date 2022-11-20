using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;
    [SerializeField] List<MedusaController> _medusas;
        [SerializeField] int _maxEnemyCount = 4;

        [SerializeField] List<CollectiableController> _pearls;
        [SerializeField] int _maxPearlCount = 8;
        GameObject _gameManager;
        public bool CanSpawn => _maxEnemyCount > _medusas.Count;  
        public bool CanSpawnPearl => _maxPearlCount > _pearls.Count;   

        
    void Awake()

        {
            if (Instance == null)
            {
                Instance = this;
            }
            _medusas = new List<MedusaController>();
            _pearls = new List<CollectiableController>();
        }
        public void AddEnemy(MedusaController medusaController)
        {
            medusaController.transform.parent = this.transform;
            _medusas.Add(medusaController);
        }

        public void RemoveEnemy(MedusaController medusaController)
        {
            _medusas.Remove(medusaController);
        }

        public void AddPearl(CollectiableController pearl)
        {
            _pearls.Add(pearl);
        }
        public void RemovePearl(CollectiableController pearl)
        {
            _pearls.Remove(pearl);
        }
}
