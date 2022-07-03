using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class touchpad2 : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothdirection1;
    public float smooth;
    private int pointerID;
    private void Awake()
    {
        direction = Vector2.zero;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Put1:" + eventData.pointerId);
        Vector2 currentPosition = eventData.position;
        Vector2 directionRaw = currentPosition - origin;
        direction = directionRaw.normalized;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }
    public Vector2 GetDirection()
    {
        smoothdirection1 = Vector2.MoveTowards(smoothdirection1, direction, smooth);
        return smoothdirection1;
    }
}
