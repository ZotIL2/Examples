using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFrogS : MonoBehaviour
{

    [SerializeField]
    float distance = 5.5f;
    [SerializeField]
    private Transform leftPoint; // Точка зліва
    [SerializeField]
    private Transform rightPoint; // Точка справа
    [SerializeField]
    private Transform transformNuts;
    [SerializeField]
    private float movementSpeed = 5f; // Швидкість переміщення ворога
    private bool movingRight = true; // Пр

    Vector2 direction1;
    private bool flagCol = false;
    [SerializeField]
    private int lives = 10;
    private bool flagB = true;
    bool DieB = false;
    Object NutsObj;
    private Animator animator;
    private Vector3 NewPos;
    private MonsterState State

    {

        get { return (MonsterState)animator.GetInteger("State"); }

        set { animator.SetInteger("State", (int)value); }

    }
    private void Awake()
    {

        animator = GetComponent<Animator>();
    }

    private void Start()

    {
        NutsObj = Resources.Load("NutsGold");
       
    }

    private void  Update()

    {

        if (flagCol == false && DieB == false) { Move(); }


    }

    private void FixedUpdate()
    {
        Vector2 origionPos = transform.position;
        if (transform.eulerAngles.y == 180)
        {
            direction1 = Vector2.right;
        }
        else
        {
            direction1 = Vector2.left;
        }
        int layerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(origionPos, direction1, distance, layerMask);
        if (hit.collider != null && DieB == false)
        {
            flagCol = true;
            animator.SetTrigger("Attack");
            NewPos = new Vector3(hit.collider.transform.position.x - 4, transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, NewPos , movementSpeed * Time.deltaTime);
        }
        else
        {
          //  State = MonsterState.Frog;
            flagCol = false;
        }
    }
    // private void LateUpdate()
    //  {
    //     Debug.DrawRay(transform.position, direction1 * distance, Color.red);
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Unit unit = collision.gameObject.GetComponent<Unit>();
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet &&  flagB == true)

        {
            animator.SetTrigger("Hit");
            lives--;
            flagB = false;
            flagCol = true;
            Debug.Log(lives);
            if (lives <= 0)
            {
                DieB = true;
                flagB = false;
                flagCol = true;
                State = MonsterState.Die;
                Debug.Log("Die");
            }
            flagB = true;
            flagCol = false;
            Destroy(collision.gameObject);      
           

        }
        if (unit && unit is Character)

        {
            if (Mathf.Abs(unit.transform.position.x - transform.position.x) < 0.5F)
            {
             
            }
            else { unit.ReceiveDamage(); }

        }
    }
    public void HitBA()
    {
        flagB = true;
        DieB = false;
    }
    public void die()
    {
        Instantiate(NutsObj, transformNuts.position, transform.rotation);
        Destroy(gameObject);
    }
   

    void OnTriggerExit2D(Collider2D collider)

    {
        if (DieB == false)
        {
            flagCol = false;
          //  State = MonsterState.Frog;
        }
       
    }
    private void Move()
    {
        Transform targetPoint = movingRight ? rightPoint : leftPoint;

        // Переміщення ворога до цільової точки
       Vector3 newpos =  Vector3.MoveTowards(transform.position, targetPoint.position, movementSpeed * Time.deltaTime);

        transform.position = new Vector3(newpos.x,newpos.y);
      
        // Перевірка, чи досягнуто цільову точку
        if (transform.position == targetPoint.position)
        {
            // Зміна напрямку руху
            movingRight = !movingRight;

            // Розворот ворога
            transform.eulerAngles = new Vector3(0, movingRight ? 180 : 0, 0);
        }
    }
    public enum MonsterState

    {

        Frog,

        Attack,

        Hit,

        Die

    }
}
