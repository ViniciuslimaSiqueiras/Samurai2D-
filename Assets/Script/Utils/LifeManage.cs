using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class LifeManage : MonoBehaviour
{

    [Header("animation")]
    public string deaths = "Death";

    [Header("Vida")]
    public int life = 10;
    public int _currentLife;
    public bool death = false;

    [Header("Referencs")]
    public EnemyMove enemyMove;
    public Animator animator;

    private void Awake()
    {

    }
    private void Start()
    {
        _currentLife = life;
        animator = GetComponent<Animator>();
        enemyMove = GetComponent<EnemyMove>();
    }
    private void Update()
    {
        Death();
    }
    public void Damage(int damage)
    {
        this._currentLife -= damage;
    }
    void Death()
    {
        if (_currentLife <= 0)
        {
            animator.SetBool(deaths, true);
            death = true;
            Destroy(GameObject.Find("AttackEnemy").GetComponent<CapsuleCollider2D>());
            Destroy(gameObject.GetComponent<EnemyMove>());
            Destroy(gameObject.GetComponentInChildren<ViuOplayer>());
            Destroy(gameObject.GetComponent<EnemyAttack2>());
            Destroy(gameObject, 5f);
        }
    }
}
