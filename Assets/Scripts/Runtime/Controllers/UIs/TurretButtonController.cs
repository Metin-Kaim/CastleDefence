using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.UIs
{
    public class TurretButtonController : MonoBehaviour
    {
        [SerializeField] int entityIndex = -1;
        [SerializeField] bool isClickedTurretButton;


        public void HandleOnHoverButton(int entityIndex)
        {
            this.entityIndex = entityIndex;
        }

        private void OnEnable()
        {
            TurretSignals.Instance.onGetCurrentTurretIndex += OnClickedTurretButton;
            TurretSignals.Instance.onTurretPlaced += OnTurretPlaced;
            TurretSignals.Instance.onGetIsTurretButtonClicked += OnGetIsTurretButtonClicked;
        }

        private int OnClickedTurretButton()
        {
            return entityIndex;
        }
        public void OnTurretSelected()
        {
            isClickedTurretButton = true;
        }
        private void OnTurretPlaced()
        {
            isClickedTurretButton = false;
            entityIndex = -1;
        }
        public bool OnGetIsTurretButtonClicked()
        {
            return isClickedTurretButton;
        }

        private void OnDisable()
        {
            TurretSignals.Instance.onGetCurrentTurretIndex -= OnClickedTurretButton;
            TurretSignals.Instance.onTurretPlaced -= OnTurretPlaced;
            TurretSignals.Instance.onGetIsTurretButtonClicked -= OnGetIsTurretButtonClicked;
        }
    }
}
