using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers.Inputs
{
    public class InputManager : MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                InputSignals.Instance.onLeftMousePress?.Invoke();
            }
            if(Input.GetMouseButtonUp(0))
            {
                InputSignals.Instance.onLeftMouseRelease?.Invoke();
            }
        }
    }
}
