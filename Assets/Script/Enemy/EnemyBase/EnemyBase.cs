using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Animation")]
    public float Dir;
    public string run = "Run";
    public string morte = "Death";
    

    [Header("vida")]
    public int life = 10;

    [Header("Verificaçoes")]
    public bool estaNoChao;
    public LayerMask floor;

    [Header("EnemyMove")]
    public Transform _currentTarget;
    public float _currentVelocity;
    public float velocity;
    public float detectedPlayerVelocity;
    public int mudarDireção;
    public bool playerDetected;
    public bool playerStreetDetected;
    public Coroutine _currentCoroutine;

    [Header("references")]
    public Transform checarChao;
    public Transform targetA;
    public Transform targetB;
    public Transform PlayerTarget;
    public Rigidbody2D rb;
    public Animator animator;
    public EnemyAttack enemyAttack;
    void Start()
    {
        _currentCoroutine = null;
        _currentTarget = targetA;
        estaNoChao = false;
        playerDetected = false;
        _currentVelocity = velocity;
        detectedPlayerVelocity = velocity * 2;
        targetA.position = new Vector2(targetA.position.x,  transform.position.y );
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (enemyAttack.noAlcance)
        {
            return;
        }
        else
        {
        move();
        }
        death();
        TargetPos();
    }
    void TargetPos()
    {
        targetA.position = new Vector2(targetA.position.x, transform.position.y);
        targetB.position = new Vector2(targetB.position.x, transform.position.y);
        PlayerTarget.position = new Vector2(PlayerTarget.position.x, transform.position.y);
    }

    void move()
    {

        Dir = transform.localPosition.x - _currentTarget.position.x;
        if(Dir < 0)
        {
            transform.localScale = new Vector3(17, 17, 0);
        }
        else if(Dir > 0)
        {
            transform.localScale = new Vector3(-17, 17, 0);

        }
        transform.position = Vector2.MoveTowards(transform.position, _currentTarget.position, _currentVelocity * Time.deltaTime);  
        
        if (!playerDetected)
        {
            
            if (_currentTarget == PlayerTarget)
            {
                  _currentVelocity = velocity;
                 if(_currentCoroutine == null)
                 {
                    _currentCoroutine = StartCoroutine(TargetMoveA());
                 }
            }
            if (_currentTarget == targetA && Dir == 0)
            {
                 if(_currentCoroutine == null)
                {
                   _currentCoroutine = StartCoroutine(TargetMoveB());

                }
                 
            }
            if (_currentTarget == targetB && Dir == 0)
            {
                if (_currentCoroutine == null)
                {
                    _currentCoroutine = StartCoroutine(TargetMoveA());
                }
            }
        }
        else
        {
            StopAllCoroutines();
            _currentTarget = PlayerTarget;
            _currentVelocity = detectedPlayerVelocity;
            _currentCoroutine = null;
        }
        //animação
        if(Dir != 0)
        {
            animator.SetBool(run, true);
        }
        else
        {
            animator.SetBool(run, false);
        }

        estaNoChao = Physics2D.Linecast(checarChao.position, transform.position, floor);

    }
    IEnumerator TargetMoveB()
    {
        yield return new WaitForSeconds(mudarDireção);
        _currentTarget = targetB;
        _currentCoroutine = null;
    }
    IEnumerator TargetMoveA()
    {
        yield return new WaitForSeconds(mudarDireção);
        _currentTarget = targetA;
        _currentCoroutine = null;
    }
    
    public void damage(int damage)
    {
        this.life -= damage;
    }
    void death()
    {
        if(life <= 0)
        {
           // Destroy(GetComponent<Rigidbody2D>());
           // Destroy(GetComponent<CapsuleCollider2D>());
            Destroy(GetComponent<EnemyBase>());
            Destroy(GetComponentInChildren<EnemyAttack>());
            animator.SetBool(morte, true);

        }
    }

    
}
