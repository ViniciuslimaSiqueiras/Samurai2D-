using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public bool atacando;
    public Coroutine _currentCoroutine;
    public CapsuleCollider2D _collider;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        _currentCoroutine = null;
        atacando = false;
    }
    private void Update()
    {
       attack();
        AttackCollider();
    }

    public void attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && !atacando && _currentCoroutine == null)
        {
           atacando = true;
            animator.SetBool("Attack",true);
            _currentCoroutine = StartCoroutine(AttackTimer());
        }
    }
    void AttackCollider()
    {
        if (atacando)
        {
            _collider.enabled = true;
        }
        else
        {
            _collider.enabled = false;

        }
    }


    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.6f);
        atacando = false;
          _currentCoroutine = null;
             animator.SetBool("Attack",false);
    }
}
