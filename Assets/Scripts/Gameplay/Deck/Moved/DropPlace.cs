using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Gameplay.Deck.Moved
{
    public class DropPlace : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            HoverEffect hoverEffect = eventData.pointerDrag.GetComponent<HoverEffect>();
            if (hoverEffect != null)
            {
                hoverEffect._defaultParent = transform;
            }
        }
    }
}
