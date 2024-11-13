using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform targetImage;
    public Vector3 hoverOffset = new Vector3(0, 10, 0); 
    public float duration = 0.5f;
    private Camera _camera;
    Vector3 offset;
    private bool _isDragging = false;
    public Transform _defaultParent;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _camera = Camera.main;
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        targetImage = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
      // if(!_isDragging) targetImage.DOLocalMove(targetImage.localPosition + hoverOffset, duration)
                 //  .SetEase(Ease.OutBack); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // if (!_isDragging) targetImage.DOLocalMove(targetImage.localPosition - hoverOffset, duration)
                //   .SetEase(Ease.OutBack);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _isDragging = true; 
        offset = transform.position - _camera.ScreenToWorldPoint(eventData.position);
        _defaultParent = transform.parent;
        transform.SetParent(_defaultParent.parent);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = _camera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _isDragging = false;
        transform.SetParent(_defaultParent);
        _canvasGroup.blocksRaycasts = true;
    }
}