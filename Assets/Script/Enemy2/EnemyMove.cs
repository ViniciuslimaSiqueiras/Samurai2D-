using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Animator")]
    public string run = "Run";
    public string deaths = "Death";

    [Header("life")]
    public int life = 10;
    public int _currentLife;
    public bool death;

    [Header("Move")]
    public float velocity = 25;
    public float RbVelocity;
    public int Dir;
    public int tempoPraAndar = 3;
    public bool EstaAndando;
    public bool possoAndar;
    public bool EstaNoChao;
    public Vector3 Spawn;
    public Coroutine _currentCoroutine;

    [Header("Referencias")]
   // public _Dash dash;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform target1;
    public Transform target2;
    public Transform PlayerTarget;
    public Transform _currentTarget;
    private void Start()
    {
       
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerTarget = GameObject.Find("PlayerTarget").GetComponent<Transform>();
        _currentLife = life;
        if (_currentTarget == null)
        {
            _currentTarget = target1;
            _currentCoroutine = null;
        }
    }

    private void Awake()
    {
        possoAndar = true;
    }


    private void Update()
    {
        if (possoAndar)
        {
            
            Move();
            Direção();
            Animations();
        }
    }
    public void Direção()
    {
        RbVelocity = transform.position.x - _currentTarget.position.x;
        if(RbVelocity != 0)
        {
            EstaAndando = true;
        }
        else
        {
            EstaAndando = false;
        }
            if (RbVelocity < 0)
            {
                transform.localScale = new Vector3(18, 18, 18);
                Dir = 1;
            }
                 if (RbVelocity > 0)
                 {
                     transform.localScale = new Vector3(-18, 18, 18);
                     Dir = 0;
                 }
    }
    
    void Move()
    {
        var E = new Vector2(_currentTarget.position.x, transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position,E, velocity* Time.deltaTime );

        if(_currentTarget == target1 && transform.position.x == _currentTarget.position.x && _currentCoroutine == null)
        {
           _currentCoroutine = StartCoroutine(TimeToMoveT1());
        }
        if(_currentTarget == target2 && transform.position.x == _currentTarget.position.x && _currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(TimeToMoveT2());
        }
    }
  
   
    IEnumerator TimeToMoveT1()
    {
        yield return new WaitForSeconds(tempoPraAndar);
        _currentTarget = target2;
        _currentCoroutine = null;
    }
    IEnumerator TimeToMoveT2()
    {
        yield return new WaitForSeconds(tempoPraAndar);
        _currentCoroutine = null;
        _currentTarget = target1;
    }
    void Animations()
    {
        if (EstaAndando)
        {
         animator.SetBool(run, true);
        }
        else
        {
         animator.SetBool(run, false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            EstaNoChao = true;
        }
        else
        {
            EstaNoChao = false; 
        }
    }

}
