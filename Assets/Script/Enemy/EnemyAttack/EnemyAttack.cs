using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("ATTACK")]
    public string ataque = "Attack";


    [Header("ataque")]
    public int damage;
    public float timeToAttak = 0.2f;
    public bool noAlcance;

    [Header("referencias")]
    public CapsuleCollider2D colider;
    public Animator animator;
    private void Start()
    {
        colider.enabled = false;
    }

    void Attack()
    {
        
        colider.enabled = true;
        animator.SetBool(ataque, true);
    }void AttackOff()
    {
        
        colider.enabled = false;
        animator.SetBool(ataque, false);
        noAlcance = false;
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && colider.enabled == false)
        {
            Invoke("Attack", timeToAttak);
            noAlcance = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(colider.enabled == true)
        {
            
            Invoke("AttackOff", timeToAttak);
        }
        
    }
}
