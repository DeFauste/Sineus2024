using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay.Card
{
    public class CardBinder : MonoBehaviour
    {
        [SerializeField] private Card _card;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        public void SetCard(Card card) => _card = card;

        private void Start()
        {
            UpdateCardView();
        }

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
