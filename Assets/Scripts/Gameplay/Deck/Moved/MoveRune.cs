using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
    public class MoveRune:  MonoBehaviour
{
        public RectTransform uiImage; // Ссылка на ваш UI-элемент
        public RectTransform parent; // Ссылка на ваш UI-элемент

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Получаем позицию клика мыши в мировых координатах
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Преобразуем мировые координаты в локальные координаты RectTransform
                Vector2 targetPosition = uiImage.parent.InverseTransformPoint(worldPosition);

                // Перемещаем UI-элемент с анимацией
                uiImage.DOAnchorPos(targetPosition, 1f); // 1f - продолжительность анимации
            }
        }
    }
}
