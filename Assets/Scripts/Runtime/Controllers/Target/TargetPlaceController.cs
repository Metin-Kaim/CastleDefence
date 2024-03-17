using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Target
{
    public class TargetPlaceController : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayer;
        [SerializeField] Transform turretPrefab;

        Transform currentTurret;
        Ray ray;
        RaycastHit hit;
        int counter;

        void Update()
        {
            if (currentTurret != null)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                {
                    currentTurret.transform.position = hit.point;
                }
            }
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onLeftMousePress += PlaceTarget;
        }
        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onLeftMousePress -= PlaceTarget;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        private void PlaceTarget()
        {
            if (counter == 0)
            {
                currentTurret = Instantiate(turretPrefab, hit.point, Quaternion.identity, transform);
                counter++;
            }
            else
            {
                currentTurret = null;
                counter--;
            }
        }
    }
}
