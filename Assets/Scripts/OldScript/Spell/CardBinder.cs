using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Spell
{
    public class CardBinder : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private TMP_FontAsset _font;
        [SerializeField] private Image _image;
        [SerializeField] private SOCard _SOCard;


        private void Start()
        {
            BindCardField();
        }


        public void BindCardField()
        {
            if(_SOCard == null) return;
            _name.text = _SOCard.Name;
            _description.text = _SOCard.Description;
            _image.sprite = _SOCard.Image;
            _name.font = _font;
            _description.font = _font;
        }
    }
}
