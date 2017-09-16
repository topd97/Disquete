using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : PhysicsObject 
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
    public string nextSceane;
     

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool testeRolamento = false;
    public static bool getFita;



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
        getFita = false;
        count = 0;
        moving = false;
     
    }

    void Awake()
    {
        getFita = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
   

    protected override void ComputeVelocity()
    {
        animator.SetBool("Pulando", false);
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        

        if (velocity.y < 0.05)
        {

            if (testeRolamento == true)
            {
                animator.SetBool("rolar", true);
                testeRolamento = false;
            }
            testeRolamento = true;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("Pulando", true);
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
           
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
            
        }
        if(velocity.y!=0)
        {
            
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > -0.01f) : (move.x <= 0.01f));

        
        if(move.x!=0)
        {
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;

            }
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
       else if(other.gameObject.tag == "Fita")
        {
            getFita = true;
            other.gameObject.SetActive(false);
        }
    }
}
