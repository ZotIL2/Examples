using UnityEngine;
using UnityEngine.EventSystems;

public class touchpad : MonoBehaviour,IPointerDownHandler,IDragHandler,IPointerUpHandler
{
    private Vector2 origin;
    private Vector2 direction;
    private Vector2 smoothdirection;
    public float smooth;
    private int pointerID = 0;

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
        Debug.Log("Put:" + eventData.pointerId);
        if (eventData.pointerId == pointerID)
        {
            Vector2 currentPosition = eventData.position;
            Vector2 directionRaw = currentPosition - origin;
            direction = directionRaw.normalized;
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }
    public Vector2 GetDirection()
    {
        smoothdirection = Vector2.MoveTowards(smoothdirection,direction,smooth);
        return smoothdirection; 
    }
}
