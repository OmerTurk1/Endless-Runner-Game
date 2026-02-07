using UnityEngine;
using UnityEngine.EventSystems;

public class TouchScript : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector2 startPos;
    private Vector2 currentPos; // good
    public Vector2 delta;
    private bool isdragging;
    private float len;
    private void Start()
    {
        isdragging = false;
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 size = rect.rect.size;
        len = size.x < size.y ? size.x : size.y; // take smaller one
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        currentPos = eventData.position;
        isdragging = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        currentPos = eventData.position;    
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isdragging = false;
        delta = Vector2.zero;
    }
    private void Update()
    {
        if (!isdragging)
        {
            delta = Vector2.zero;
            return;
        }
        delta = (currentPos - startPos)/len;
    }
}
