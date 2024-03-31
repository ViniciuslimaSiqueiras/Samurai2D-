using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Animation")]
    public string runAnim = "Run";
    public string jumpAnim = "Jump";

    [Header("Move")]
    public int velocity = 5;
    public int _currentVelocity = 5;
    public bool _isMoving;

    [Header("jump")]
    public int jumpForce = 5;

    [Header ("Move Variables")]
    public float dirX;


    [Header("References")]
    private Rigidbody2D rb;
   // public _Dash dash;
    private Animator animator;
    private PlayerAttack playerAttack;
    private Transform Player;
    public Transform floorCheck;

    private void Start()
    {
        _currentVelocity = velocity;
        playerAttack = GetComponentInChildren<PlayerAttack>();
        animator = GetComponentInChildren<Animator>();
        Player = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //dash = GetComponent<_Dash>();

    }
    private void FixedUpdate()
    {
        movePlayer();
    }
    private void Update()
    {
            animationManage();
            TocandoChao();
            jump();
        
    }
    void movePlayer()
    {
        dirX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(1 * velocity* Time.deltaTime,0,0));
            //dirX = math.ceil(dirX);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1 * velocity*Time.deltaTime,0,0));
           // dirX = math.floor(dirX);
        }
        else { _isMoving = false;}
        
    }
    void jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        rb.velocity = new Vector3(rb.velocity.x, jumpForce) ;

    }
    void animationManage()
    {
        if(dirX > 0)
        {
            transform.localScale = new Vector3(-15, 15, 0); 

        }else if(dirX < 0)
        {
            transform.localScale = new Vector3(15, 15, 0);

        }
        if (dirX != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);       
        }
    }
    void Street()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
        }
    }
    void Dash()
    {
    }
    void timetodash()
    {
    }
    void TocandoChao()
    {
    }
  
    #region COLLISIONS
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
        }

    }

    #endregion
}
