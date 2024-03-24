using Runtime.Abstract.Enemies;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class TurretSignals : MonoBehaviour
    {
        public static TurretSignals Instance;

        public Func<int> onGetCurrentTurretIndex;
        public UnityAction onTurretPlaced;
        public Func<bool> onGetIsTurretButtonClicked;

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