using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] List<MedusaController> _medusas;
        [SerializeField] int _maxEnemyCount = 2;
        GameObject _gameManager;
        public bool CanSpawn => _maxEnemyCount > _medusas.Count;    
        
    void Awake()
        {
            _medusas = new List<MedusaController>();
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
}
