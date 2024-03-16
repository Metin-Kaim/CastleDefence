using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        public List<Transform> list_pathPoints = new();

        [SerializeField][Range(1, 50)] float moveSpeed;

        private Transform _currentTarget;

        private void Start()
        {
            TargetDesignator();
        }

        private void FixedUpdate()
        {
            MoveTowardsTarget();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("DeadZone"))
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PathPoint"))
            {
                if (list_pathPoints.Count <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.DORotate(_currentTarget.transform.eulerAngles, .5f);
                    TargetDesignator();
                }
            }
        }

        private void MoveTowardsTarget()
        {
            transform.position += moveSpeed * Time.fixedDeltaTime * transform.forward;
        }

        private void TargetDesignator()
        {
            _currentTarget = list_pathPoints[0];
            list_pathPoints.RemoveAt(0);
        }
    }
}