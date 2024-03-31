using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetDetected : MonoBehaviour
{

    public PlayerMove player;
    public EnemyBase enemy;
    public Rigidbody2D rb;
    private void Start()
    {
       enemy = GetComponentInParent<EnemyBase>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            enemy.playerStreetDetected = false;


    }
}
