using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : MonoBehaviour
{
    [Header("Attack")]
    public int damage = 10;
    public float tempoPraAtacar = 0.2f;
    public string attack = "Attack";
    public string player = "Player";
    public Coroutine _currentCoroutine;
    public bool mato;


    [Header("Distancia")]
    public float distance;
    public bool alcance = false;
    public bool dapraAtacar;


    [Header("Referencias")]

    public LayerMask PlayerLayer;
    public EnemyMove enemymove;
    public Animator animator;
    public CapsuleCollider2D coliderAttack;
    public EnemyAttack2 EnemyAttack;
    public lifemanagePlayer lifePlayer;
    public LifeManage lifeEnemy;
    private void Awake()
    {
        mato = false;
       animator = GetComponentInParent<Animator>();    
       coliderAttack = GetComponent<CapsuleCollider2D>();
       lifeEnemy = GetComponentInParent<LifeManage>();
       coliderAttack.enabled = false;
       // lifePlayer = GameObject.Find("Player 1").GetComponent<lifemanagePlayer>();
    }
    private void Update()
    {
        attacks();
        DistanciaAtePlayer();
        if (lifeEnemy.death)
        {
            StopAllCoroutines();
        }
    }

    void DistanciaAtePlayer()
    {
        RaycastHit2D hit ;
        if (enemymove.Dir == 0)
        {
            hit = Physics2D.Raycast(transform.position,Vector2.left,distance,PlayerLayer);
            if (hit)
            {
                alcance = true;
                Debug.DrawLine(transform.position, hit.point);
                enemymove.possoAndar = false;
                enemymove.animator.SetBool("Run", false);
            }
            else
            {
                if (!enemymove.possoAndar)
                {
                    alcance = false;
                    enemymove.animator.SetBool("Run", true);
                    enemymove.EstaAndando = true;
                    enemymove.possoAndar = true;
                }
            }
        }
        else if(enemymove.Dir == 1)
        {
            hit = Physics2D.Raycast(transform.position,-Vector2.left,distance,PlayerLayer);
            if (hit)
            {
             alcance = true;
             Debug.DrawLine(transform.position, hit.point);
             enemymove.possoAndar = false;
             enemymove.animator.SetBool("Run", false);
            }
            else
            {
                if (!enemymove.possoAndar)
                {
                    alcance = false;
                    enemymove.animator.SetBool("Run", true);
                    enemymove.EstaAndando = true;
                    enemymove.possoAndar = true;
                }
            }
        }
        

    }
    //gerencia o desligamento do collider aplicando tempo atraves do invoke
    void attacks()
    {
        if (alcance && _currentCoroutine == null && mato == false )
        {
            
            _currentCoroutine = StartCoroutine(AtackOn());  
        }
        
    }
    //liga e desliga o collider pra contar o dano
   IEnumerator AtackOn()
    {
        yield return new WaitForSeconds(tempoPraAtacar);
        if(coliderAttack !=null)
        coliderAttack.enabled = true;
        animator.SetBool(attack, true);
        yield return new WaitForSeconds(tempoPraAtacar);
        animator.SetBool(attack, false);
        coliderAttack.enabled = false;
        _currentCoroutine = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<lifemanagePlayer>())
        {
            lifePlayer = collision.GetComponent<lifemanagePlayer>();
            lifePlayer.Damage(damage);
            Debug.Log("Dano Inimigo");  
            mato = true;
        }
    }

}
