using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{       

    //variables del movimiento del personaje

    public float jumpForce = 6f;
    public float runningSpeed = 2f;
    private Rigidbody2D rigidBody;
    Animator animator;

    private const string STATE_ALIVE = "IsAlive";
    private const string STATE_ON_THE_GROUND = "IsOnTheGround";

    public LayerMask groundMask;

    void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(STATE_ALIVE, true);
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {   
       if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
       {    
            //salta si se pulsa la tecla espacio o el boton izquierdo del mouse
            jump();
            
       }

       animator.SetBool(STATE_ON_THE_GROUND, IsTochingTheGround());

       Debug.DrawRay(this.transform.position, Vector2.down * 1.0f, Color.blue);

    }

    void FixedUpdate()
    {   
        rigidBody.velocity = new Vector2(Input.GetAxis("Horizontal") * runningSpeed , rigidBody.velocity.y);
        
        if(Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
            
    }
4

    void jump()
    {   
        if(IsTochingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsTochingTheGround()//esta tocando el suelo
    {
        //Metodo para saber si esta en el suelo
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 1.0f, groundMask))
        {
            //programar logica de contacto de suelo
            
            return true;
        }
        else
        {
            //programar logica de no contactO

            return false;
        }


    }

}
