using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
    public class DropPlace : MonoBehaviour, IDropHandler
    {
        public virtual void OnDrop(PointerEventData eventData)
        {
            HoverEffect hoverEffect = eventData.pointerDrag.GetComponent<HoverEffect>();
            if (hoverEffect != null)
            {
                hoverEffect._defaultParent = transform;
            }
        }
    }
}
