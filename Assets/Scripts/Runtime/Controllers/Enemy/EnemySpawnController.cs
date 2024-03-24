using Runtime.Abstract.Enemies;
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

        int entityCounter = 0;

        private IEnumerator Start()
        {
            while (true)
            {
                AbsEnemy newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform).GetComponent<AbsEnemy>();
                newEnemy.List_pathPoints.AddRange(pathPoints);
                newEnemy.Index = entityCounter;
                entityCounter++;
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}