using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] List<Transform> pathPoints = new();
        [SerializeField][Range(1, 50)] float moveSpeed;

        private Transform _currentTarget;

        private void Awake()
        {
            TargetDesignator();
        }

        private void Update()
        {
            // Anlýk konum takibi
            // Hedef deðiþimi
            float distance = Vector2.Distance(new(transform.position.x, transform.position.z), new(_currentTarget.position.x, _currentTarget.position.z));
            print($"Distance: {distance}");
            if (distance < .5f)
            {
                if (pathPoints.Count <= 0)
                {
                    print("Hedef Yok Edildi");
                    Destroy(gameObject);
                    //return;
                }
                else
                {
                    print($"Düþman {_currentTarget.name}'e ulaþtý.");
                    transform.DORotate(_currentTarget.transform.eulerAngles, .2f);
                    TargetDesignator();
                }
            }
        }

        private void FixedUpdate()
        {
            // Hedefe ilerleme
            transform.position += moveSpeed * Time.fixedDeltaTime * transform.forward;
        }
        private void TargetDesignator()
        {
            //Hedef Belirleme Fonksiyon
            _currentTarget = pathPoints[0];
            print($"Yeni hedef:: ${_currentTarget.name}");
            pathPoints.RemoveAt(0);
        }
    }
}