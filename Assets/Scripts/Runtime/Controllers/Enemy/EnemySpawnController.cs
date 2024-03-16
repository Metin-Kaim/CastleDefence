using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefab;
        [SerializeField] Transform spawnPoint;
        [SerializeField] List<Transform> pathPoints = new();

        private IEnumerator Start()
        {
            while (true)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
                newEnemy.GetComponent<EnemyMovementController>().list_pathPoints.AddRange(pathPoints);
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}