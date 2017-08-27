using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : PhysicsObject 
{

    /* public Sprite mario;
     public int velocidade;


     private Rigidbody2D rb;


     // Use this for initialization
     void Awake ()
     {
         rb = GetComponent<Rigidbody2D>();
     }

     // Update is called once per frame
     void Update ()
     {

         float MoveHorizontal = Input.GetAxis("Horizontal");
         if(MoveHorizontal>0)
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
             rb.AddForce(new Vector2(MoveHorizontal, 0) * velocidade);
         }
         else if(MoveHorizontal<0)
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
             rb.AddForce(new Vector2(MoveHorizontal, 0) * velocidade);
         }


     }*/

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public static int count;
    public static bool moving;
    public static bool gula1, gula2, gula3;
    public static int inimigosmortos;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    



    enum CurrentStage
    {
        ganancia,
        luxuria,
        ira,
        orgulho,
        inveja,
        gula,
        preguica
    }
    [SerializeField]
    CurrentStage currentstage;
    // Use this for initialization
    void Start()
    {
        count = 0;
        inimigosmortos = 0;
        moving = false;
        gula1 = false;
        gula2 = false;
        gula3 = false;
    }

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        animator.SetBool("Pulando", false);
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
           
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
                animator.SetBool("Pulando", true);

            }
            

        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x < -0.01f) : (move.x > 0.01f));

        
        if (!flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        if (move.x > 0.1f || move.x < -0.01f)
        {
            moving = true;
            animator.SetBool("Parado", false);
        }
        else
        {
            moving = false;
            animator.SetBool("Parado", true);

        }
        targetVelocity = move * maxSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag=="Espinho")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //morreu reinicia a fase
        }
    }
}
