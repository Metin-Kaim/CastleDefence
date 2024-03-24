using DG.Tweening;
using Runtime.Handlers.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {

        [SerializeField][Range(1, 50)] float moveSpeed;

        private List<Transform> _list_pathPoints;
        private Transform _currentTarget;

        private void Awake()
        {
            _list_pathPoints = GetComponent<EnemyHandler>().List_pathPoints;
        }

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
                if (_list_pathPoints.Count <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.DORotate(_currentTarget.transform.eulerAngles, 1 / moveSpeed);
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
            _currentTarget = _list_pathPoints[0];
            _list_pathPoints.RemoveAt(0);
        }

    }
}