using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovePlayer : BasePlayer
{

    public AnimatorManager animManager;
    public AttackPlayer AttackPlayer;
    public Vector2 direction;
    public Animator animator;
    public Rigidbody2D rb;
    void Start()
    {
        AttackPlayer = GetComponent<AttackPlayer>();
        rb = GetComponent<Rigidbody2D>();
        _currentVelocity = velocity;
        _isMoving = false;
    }

    void Update()
    {
        if (!AttackPlayer.atacando)
        {
         move();
        }
        Jump();
        animations();
    }

    public void move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal") * _currentVelocity, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = direction;
            _isMoving = true;
            //transform.eulerAngles = new Vector2(-15,15);
            transform.localScale = new Vector2(-15,15);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = direction;
            _isMoving = true;
            transform.localScale = new Vector2(15,15);

        }
        else
        {
            _isMoving = false;
            rb.velocity = new Vector2(0,rb.velocity.y);
        }
        
    }
    public void animations()
    {
        #region JUMP
         animator.SetFloat("Jump",rb.velocity.y);
        #endregion
        #region Run
         if (_isMoving)
         {
           animator.SetBool("Run", true);
         }
           else
           {
             animator.SetBool("Run", false);
           }

        #endregion
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(transform.up * jumpForce,ForceMode2D.Impulse); 
    }
}
