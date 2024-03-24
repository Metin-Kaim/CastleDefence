using System;
using UnityEngine;

namespace Runtime.Signals
{
    public class UISignals : MonoBehaviour
    {
        public static UISignals Instance;

        public Func<bool> onIsMouseOverUI;

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