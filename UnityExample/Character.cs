using UnityEngine;

using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Character : Unit

{
    [SerializeField]
    private Text nats;
    private int NatsInt;
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private FixedJoystick fixedJoystick;
    public int Lives

    {

        get { return lives; }

        set

        {
            
            lives = value;
            if (value == 0) restartGame();
            livesBar.Refresh();

        }

    }

    private LivesBar livesBar;

    [SerializeField]

    private float speed = 3.0F;

    [SerializeField]

    private float jumpForce = 15.0F;

    private bool isGrounded = false;
    float distance = 1.5f;
    private Bullet bullet;
    private bool isLadder = false;
    private bool isClimbing;
    // private Bullet bullet;

    private CharState State

    {

        get { return (CharState)animator.GetInteger("State"); }

        set { animator.SetInteger("State", (int)value); }

    }

    new private Rigidbody2D rigidbody;
    private float vertical = 0.1f;
    private Animator animator;

    private SpriteRenderer sprite;
    private AudioSource audioSCh;
    [SerializeField]
    private AudioClip[] step;
    private void Awake()

    {
        Time.timeScale = 1;
        audioSCh = GetComponent<AudioSource>();
       
        livesBar = FindObjectOfType<LivesBar>();

        rigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        sprite = GetComponentInChildren<SpriteRenderer>();
        audioSCh.mute = false;
        
        bullet = Resources.Load<Bullet>("Nuts");


    }
 
    private void FixedUpdate()

    {
        if (isClimbing)
        {
            rigidbody.gravityScale = 0f;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, vertical * speed);
        }
        else
        {
            rigidbody.gravityScale = 1f;
        }
    
    CheckGround();

    }

    private void Update()

    {
        vertical = fixedJoystick.Vertical;

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        if (isGrounded) State = CharState.Idle;
       // if (Input.touchCount > 1)
       // {
        //    if(Input.GetTouch(1).phase == TouchPhase.Began)
        //    {
          //      Debug.Log("Input1");
         //   }
            //(isGrounded && fixedJoystick.Vertical > 0.8f) ||
          //  if ( (isGrounded && Input.GetTouch(1).phase == TouchPhase.Began)) Jump();
       // }
            if ((fixedJoystick.Horizontal > 0.1f && fixedJoystick.Horizontal < 0.5f) || (fixedJoystick.Horizontal < -0.1f && fixedJoystick.Horizontal > -0.5f)) {
            speed = 3.0f;
            Walk();
            
        }else if ((fixedJoystick.Horizontal > 0.5f && fixedJoystick.Horizontal < 1f) || (fixedJoystick.Horizontal < -0.5f && fixedJoystick.Horizontal > -1f))
        {
            speed = 6.0f;
            Walk();

        }


     

    }


    private void Walk()
    {

        //Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        Vector3 direction = transform.right * fixedJoystick.Horizontal;
     
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        sprite.flipX = direction.x < 0.0F;
        if(speed == 3) { if (isGrounded) State = CharState.Walk; } else
        {
            if (isGrounded) State = CharState.Run;
        }
       

    }

        public void Jump()
        {
        if (isGrounded){
            State = CharState.Jump;
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        }
    public void Shoot()

    {
        int.TryParse(nats.text, out NatsInt);
        if (NatsInt > 0) {
            NatsInt--;
            audioSCh.PlayOneShot(step[5]);
            Vector3 position = transform.position; position.y += 0.1F;

            Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

            newBullet.Parent = gameObject;

            newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0F : 1.0F);
            nats.text = NatsInt.ToString();
        }
       
    }

    public void SoundStep()
    {

        audioSCh.PlayOneShot(step[Random.Range(0,3)]);
    }
    public void SoundStepRun()
    {

        audioSCh.PlayOneShot(step[3]);
    }
    public void SoundJump()
    {

        audioSCh.PlayOneShot(step[4]);
    }
    public override void ReceiveDamage()

    {
        Lives--;
        Debug.Log("RECIVVEE");
        rigidbody.velocity = Vector3.zero;

        rigidbody.AddForce(transform.up * 8.0F, ForceMode2D.Impulse);

        Debug.Log(lives);

    }
 

    private void CheckGround()
    {

        Vector2 origionPos = (Vector2)transform.position;
        Vector2 direction = Vector2.down;
        int layerMask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(origionPos, direction, distance, layerMask);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded) State = CharState.Jump;

    }
    public void restartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name, LoadSceneMode.Single);
    }
    private void OnTriggerEnter2D(Collider2D collider)

    {
        if (collider.tag == "Die")
        {
            restartGame();
        }
        if (collider.CompareTag("Ladder"))
        {
            isLadder = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }

}

public enum CharState

{

    Idle,

    Run,

    Walk,

    Jump

}