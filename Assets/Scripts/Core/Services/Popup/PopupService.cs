using Assets.Scripts.Gameplay.Popup;
using UnityEngine;

namespace Assets.Scripts.Core.Services.Popup
{
    public class PopupService: MonoBehaviour
    {
        [SerializeField] private PopupNoUI popupNoUI;
        private PopupNoUIManager _popupNoUIManager;

        private void Awake()
        {
            _popupNoUIManager = new PopupNoUIManager(popupNoUI);
        }

        public PopupNoUIManager Intarcat() => _popupNoUIManager;
    }
}
