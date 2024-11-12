using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform targetImage;
    public Vector3 hoverOffset = new Vector3(0, 10, 0); 
    public float duration = 0.5f;

    private void Start()
    {
        targetImage = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        targetImage.DOLocalMove(targetImage.localPosition + hoverOffset, duration)
                   .SetEase(Ease.OutBack); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetImage.DOLocalMove(targetImage.localPosition - hoverOffset, duration)
                   .SetEase(Ease.OutBack);
    }
}