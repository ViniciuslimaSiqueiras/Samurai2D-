using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lifemanagePlayer : MonoBehaviour
{
    [Header("animation")]
    public string deaths = "Death";

    [Header("Vida")]
    public int life = 10;
    public int _currentLife;
    public bool death = false;

    [Header("Referencs")]
    public Animator animator;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _currentLife = life;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Death();
    }
    public void Damage(int damage)
    {
        _currentLife -= damage;
    }
    void Death()
    {
        if (_currentLife <= 0)
        {
            animator.SetBool(deaths, true);
            death = true;
            Destroy(gameObject.GetComponent<PlayerMove>());
            rb.velocity = new Vector2(0,rb.velocity.y);
            Invoke(nameof(returnToMenu), 3f);
        }
    }
    void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
