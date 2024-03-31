using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Caracteristicas do ataque")]
    int dano = 999;

    [Header("SimpleAttack Animation")]
    public float timeToAttack = 1, timerSimpleAttack;
    public bool _attacking = false;
    public Animator anim;

    [Header("DashAttack Animation")]
    public int distance = 1;
    public bool dashAttacking = false;
    public float timerDash, timeToDash = 5f;


    private KeyCode simpleAttackKey = KeyCode.J ;
    private KeyCode DashAttackKey = KeyCode.LeftShift;

    [Header("Attack collider")]
    public int raio = 8;
    public LayerMask targetLayer;
    public Collider2D[] targets;
    public Transform attackTarget;
    private PlayerMovev2 playerMove;

    private void Start()
    {
        attackTarget = GameObject.Find("Attack").GetComponent<Transform>();
        playerMove = GetComponent<PlayerMovev2>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        attackArea();
        attack();
        
        if (Input.GetKeyDown(DashAttackKey))
        {
            Vector2 direcaoDoDash = new Vector2 (1,0);
            transform.Translate(direcaoDoDash * playerMove._direction * distance * 3000 * Time.deltaTime);
            anim.SetBool("Dash", true);
            anim.SetBool("Dash", false);

            Debug.Log("dash");
        }
    }
    void attack()
    {
        if (Input.GetKeyDown(simpleAttackKey) && !_attacking && playerMove.inGrounded)
        {
            anim.SetBool("SimpleAttack", true);
            _attacking = true;
            if(targets != null)
            {
                for(int i = 0; i < targets.Length; i++)
                {   
                    var a = targets[i].GetComponent<Transform>();
                    a.GetComponent<LifeBase>().damage(dano);
                }
            }
        }
        if (Input.GetKeyUp(simpleAttackKey)) { anim.SetBool("SimpleAttack", false); }
        if (_attacking)
        {
            timerSimpleAttack += Time.deltaTime;
            if(timerSimpleAttack >= timeToAttack)
            {
                anim.SetBool("Attack", false);
                timerSimpleAttack = 0;
                _attacking = false;
            }
        }
    }

    void attackArea()
    {
        targets = Physics2D.OverlapCircleAll(attackTarget.position,raio,targetLayer);

        foreach (Collider2D target in targets)
        {
            Debug.Log("Colidiu");
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackTarget.position,raio);
    }

}
