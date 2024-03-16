using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] List<Transform> pathPoints = new();

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject newEnemy = Instantiate(enemyPrefab,spawnPoint.position,Quaternion.identity,transform);
                newEnemy.GetComponent<EnemyMovementController>().list_pathPoints.AddRange(pathPoints);
            }
        }
    }
}