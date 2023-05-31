using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hawk : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField]
    float distance = 0.5f;
    // новая позиция объекта
    private Vector3 newPoint;
    [SerializeField]
    private float speed = 1.2F;
    [SerializeField]
    private float minstartofset = 0.1f;
    [SerializeField]
    private float maxstartofset = 1.2f;
    private Vector3 BackPosition;
    private SpriteRenderer sprite;
    [SerializeField]
    GameObject shit;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        // даю начальную позицию
        startPosition = transform.position;
        newPoint = new Vector2(
            Random.Range(startPosition.x - Random.Range(minstartofset, maxstartofset), startPosition.x + Random.Range(minstartofset, maxstartofset)),
            startPosition.y
            );
    }
    private void FixedUpdate()
    {
        Vector2 origionPos = (Vector2) transform.position;
        Vector2 direction = Vector2.down;
        int layerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(origionPos, direction, distance, layerMask);
        if(hit.collider != null && GameObject.FindGameObjectsWithTag("Shit").Length < 1)
        {
            Instantiate(shit,transform.position,transform.rotation);
            Debug.Log("Hit Character");
            
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        if (newPoint != transform.position)
        {
            BackPosition = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, newPoint, speed * Time.deltaTime);
            if (transform.position.x - BackPosition.x > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }

        }
        else
        {

            newPoint = new Vector2(Random.Range(startPosition.x - Random.Range(minstartofset, maxstartofset), startPosition.x + Random.Range(minstartofset, maxstartofset)), startPosition.y);

        }
    }
}
