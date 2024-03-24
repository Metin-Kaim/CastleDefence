using Runtime.Abstract.Enemies;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Handlers.Turrets
{
    public class TurretHandler : MonoBehaviour
    {
        public AbsEnemy currentTarget;

        [SerializeField] MeshRenderer _rangeMeshRenderer;
        [SerializeField] SphereCollider _sphereCollider;
        [SerializeField] Transform _turretBody;
        [SerializeField] Transform _bulletHole;

        int _availableCounter;
        Color _defaultRangeColor;
        bool _canPlacable;
        private float speed = 10f;
        bool _isTurretPlaced;

        public bool CanPlacable { get => _canPlacable; set => _canPlacable = value; }

        private void Start()
        {
            _defaultRangeColor = _rangeMeshRenderer.material.color;
            _rangeMeshRenderer.material.color = Color.green;
            _canPlacable = true;
        }

        private void Update()
        {
            if (currentTarget)
            {
                var targetRotation = Quaternion.LookRotation(currentTarget.transform.position - new Vector3(_turretBody.position.x, 0, _turretBody.position.z));
                _turretBody.rotation = Quaternion.Slerp(_turretBody.rotation, targetRotation, speed * Time.deltaTime);
            }
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void OnMouseDown()
        {
            if (_isTurretPlaced)
                _rangeMeshRenderer.enabled = true;
        }
        private void OnMouseOver()
        {
            if (_isTurretPlaced)
                _rangeMeshRenderer.enabled = true;
        }
        private void OnMouseExit()
        {
            if (_isTurretPlaced)
                _rangeMeshRenderer.enabled = false;
        }

        private void SubscribeEvents()
        {
            TurretSignals.Instance.onTurretPlaced += OnTurretPlaced;
        }
        public void OnTurretPlaced()
        {
            _rangeMeshRenderer.material.color = _defaultRangeColor;
            _sphereCollider.enabled = true;
            _rangeMeshRenderer.enabled = false;
            _isTurretPlaced = true;
        }
        private void UnsubscribeEvents()
        {
            TurretSignals.Instance.onTurretPlaced -= OnTurretPlaced;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_isTurretPlaced) return;
            if (!other.CompareTag("Ground") && !other.CompareTag("TurretRange"))
            {
                _availableCounter++;
                _canPlacable = false;
                _rangeMeshRenderer.material.color = Color.red;
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (_isTurretPlaced) return;

            if (!_canPlacable && !other.CompareTag("Ground") && !other.CompareTag("TurretRange"))
            {
                _availableCounter--;
                if (_availableCounter == 0)
                {
                    _rangeMeshRenderer.material.color = Color.green;
                    _canPlacable = true;
                }
            }
        }
        private void OnDrawGizmos()
        {
            if (!currentTarget) return;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(_bulletHole.position, currentTarget.hitPoint.position);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(new(currentTarget.hitPoint.position.x, currentTarget.hitPoint.position.y - .1f, currentTarget.hitPoint.position.z), .7f);

        }
    }
}
