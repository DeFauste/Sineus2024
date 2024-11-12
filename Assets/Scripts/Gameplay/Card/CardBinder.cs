using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.Card
{
    public class CardBinder : MonoBehaviour
    {
        [SerializeField] private SOCard _card;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        private HoverEffect _howerEffect;
        public void SetCard(SOCard card) => _card = card;
        public SOCard GetCard() => _card;
        private void Awake()
        {
            _howerEffect = GetComponent<HoverEffect>();
        }
        private void Start()
        {
            UpdateCardView();
        }

        public void IsInteract(bool isInteract) => _howerEffect.enabled = isInteract;
        public void UpdateCardView()
        {
            if(_card != null)
            {
                _name.text = _card.Name;
                _image.sprite = _card.Sprite;
                _description.text = _card.Description;
            }
        }
    }
}
