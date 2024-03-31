using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    Animator anim;

    public int life = 20;
    bool morto;
    int dano;

    private void Start()
    {
        anim = GetComponent<Animator>();
        morto = false;
    }

    private void Update()
    {
        if (life <= 0)
        {
            morto=true;
            Destroy(GetComponent<BoxCollider2D>());
            anim.SetBool("Morto", true);

        }
    }

    public void damage(int dano)
    {
        this.dano = dano;
        Invoke("levandoDano", 0.5f);
    }
    void levandoDano()
    {
        life -= dano;

    }

}
