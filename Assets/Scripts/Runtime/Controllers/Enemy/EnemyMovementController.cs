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

        private void Update()
        {
            // Anlýk konum takibi
            // Hedef deðiþimi
            if (Vector2.Distance(new(transform.position.x, transform.position.z), new(_currentTarget.position.x, _currentTarget.position.z)) < .2f)
            {
                if (list_pathPoints.Count <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(_currentTarget.eulerAngles);
                    //transform.DORotate(_currentTarget.transform.eulerAngles, .2f);
                    TargetDesignator();
                }
            }
        }

        private void FixedUpdate()
        {
            // Hedefe ilerleme
            transform.position += moveSpeed * Time.fixedDeltaTime * transform.forward;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("DeadZone"))
            {
                Debug.LogWarning("DeadZone");
                Destroy(gameObject);
            }
        }

        private void TargetDesignator()
        {
            //Hedef Belirleme Fonksiyon
            _currentTarget = list_pathPoints[0];
            list_pathPoints.RemoveAt(0);
        }
    }
}