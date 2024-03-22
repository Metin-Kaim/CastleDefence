//TODO
using Runtime.Data.UnityObjects;
using Runtime.Handlers.Turrets;
using Runtime.Runtime.Signals;
using Runtime.Signals;
using System.Linq;
using UnityEngine;

namespace Runtime.Controllers.Turret
{
    public class TargetPlaceController : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayer;
        [SerializeField] Transform turretPrefab;

        TurretHandler _currentTurret;
        Ray _ray;
        RaycastHit _hit;
        int _counter;
        SO_EntityDoc _entityDoc;

        private void Start()
        {
            _entityDoc = Resources.Load<SO_EntityDoc>("Data/EntityDoc");
        }

        void Update()
        {
            if (_currentTurret != null)
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, groundLayer))
                {
                    _currentTurret.transform.position = _hit.point;
                }
            }
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onLeftMousePress += PlaceTurret;
        }
        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onLeftMousePress -= PlaceTurret;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        private void PlaceTurret()
        {
            if (_counter == 0 && (bool)TurretSignals.Instance.onGetIsTurretButtonClicked?.Invoke())
            {
                //TODO::Eðer baþka butona basarsa yeni oluþan objeyi 'þimdilik' yok et.
                GameObject newEntity = GetNewEntity();

                _currentTurret = Instantiate(newEntity, Input.mousePosition, Quaternion.identity, transform).GetComponent<TurretHandler>();
                _counter = 1;
            }
            else if (_counter == 1 && _currentTurret.CanPlacable && !(bool)UISignals.Instance.onIsMouseOverUI?.Invoke())
            {
                TurretSignals.Instance.onTurretPlaced?.Invoke();
                _currentTurret = null;
                _counter = 0;
            }
        }

        private GameObject GetNewEntity()
        {
            int entityIndex = (int)TurretSignals.Instance.onGetCurrentTurretIndex?.Invoke();
            return _entityDoc.List_TexturesAndEntities.FirstOrDefault(x => x.EntityIndex == entityIndex).EntityObject;
        }
    }
}
