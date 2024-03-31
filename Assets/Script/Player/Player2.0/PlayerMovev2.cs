using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovev2 : MonoBehaviour
{
    [Header("Animation")]
    public string runAnim = "Walk";
    public string jumpAnim = "Jump";


    [Header("Move")]
    public int velocity = 25;
    public float dirX;
    public int _currentVelocity = 5;
    public bool _isMoving;
    public int _direction;

    [Header("Jump")]
    public int jumpForce = 25;
    public float dirY;
    public float distanceFloor;
    public bool inGrounded;
    public LayerMask floorLayer;

    [Header("References")]
    private Animator animator;
    private Rigidbody2D rb;
    private Transform groundedCheck;
    private PlayerAttack playerAttack;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        groundedCheck = GameObject.Find("EstaNoChao").GetComponent<Transform>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        animationManage();
        jump();
    }


    void movePlayer()
    {
        dirX = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.D))
        {
            if (playerAttack._attacking) return;
            transform.Translate(new Vector3(1 * velocity * Time.deltaTime, 0, 0));
            transform.localScale = new Vector3(15, 15, 1);
            dirX = math.ceil(dirX);
            _isMoving = true;
            _direction = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if(playerAttack._attacking)return;
            transform.Translate(new Vector3(-1 * velocity * Time.deltaTime, 0, 0));
            transform.localScale = new Vector3(-15, 15, 1);
            dirX = math.floor(dirX);
            _isMoving = true;
            _direction = -1;
        }
        else { _isMoving = false; }

    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce);
        }  
        else if (inGrounded && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0) ;
        }
       
        dirY = rb.velocity.y;

        inGrounded = Physics2D.Raycast(groundedCheck.position, Vector2.down,distanceFloor, floorLayer);


    }

    void animationManage()
    {

        animator.SetFloat("Fall", dirY);

        if (_isMoving && !playerAttack._attacking)
        {
            animator.SetBool(runAnim, true);
        }
        else
        {
            animator.SetBool(runAnim, false);
        }
        if(dirY > 2)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
