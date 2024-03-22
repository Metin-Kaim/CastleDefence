using Runtime.Signals;
using System;
using UnityEngine;

namespace Runtime.Handlers.Turrets
{
    public class TurretHandler : MonoBehaviour
    {
        public bool CanPlacable { get => _canPlacable; set => _canPlacable = value; }

        [SerializeField] MeshRenderer meshRenderer;

        int _availableCounter;
        Color _defaultRangeColor;
        private bool _canPlacable;

        private void Start()
        {
            _defaultRangeColor = meshRenderer.material.color;
            meshRenderer.material.color = Color.green;
            _canPlacable = true;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            TurretSignals.Instance.onTurretPlaced += OnTurretPlaced;
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
            if (!other.CompareTag("Ground"))
            {
                _availableCounter++;
                _canPlacable = false;
                meshRenderer.material.color = Color.red;
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Ground") && !_canPlacable)
            {
                _availableCounter--;
                if (_availableCounter == 0)
                {
                    meshRenderer.material.color = Color.green;
                    _canPlacable = true;
                }
            }
        }
        public void OnTurretPlaced()
        {
            meshRenderer.material.color = _defaultRangeColor;
            meshRenderer.gameObject.SetActive(false);
        }
    }
}
