using Runtime.Runtime.Signals;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runtime.Managers.UIs
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            UISignals.Instance.onIsMouseOverUI += IsPointerOverUI;
        }
        private void OnDisable()
        {
            UISignals.Instance.onIsMouseOverUI -= IsPointerOverUI;
        }

        private bool IsPointerOverUI()
        {
            //true => on ui, false => on world
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}