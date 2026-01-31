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
        RectTransform rect = GetComponent<RectTransform>();
        Vector2 size = rect.rect.size;
        len = size.x < size.y ? size.x : size.y; // küçük olaný al
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
        isdragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentPos = eventData.position;    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isdragging = false;
        delta = Vector2.zero;
    }
    private void Update()
    {
        if (!isdragging)
            return;

        delta = (currentPos - startPos)/len;
        if (delta.sqrMagnitude < 0.01) delta = Vector2.zero;
        Debug.Log("Anlýk delta: " + delta);
    }
}
