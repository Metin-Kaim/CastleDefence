using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance;

        public UnityAction onLeftMousePress = delegate { };
        public UnityAction onTouchRelease = delegate { };

        private void Awake()
        {
            if (Instance != this && Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
    }
}
