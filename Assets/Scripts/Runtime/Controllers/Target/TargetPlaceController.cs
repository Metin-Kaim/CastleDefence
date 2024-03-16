using UnityEngine;

namespace Runtime.Controllers.Target
{
    public class TargetPlaceController : MonoBehaviour
    {
        [SerializeField] LayerMask groundLayer;

        Ray ray;
        RaycastHit hit;

        void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                //pos = hit.point;
            }
        }
    }
}
