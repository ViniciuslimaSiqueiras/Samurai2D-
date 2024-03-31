using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetected : MonoBehaviour
{
    [Header("variaveis")]
    public string playerTag = "Player";

    [Header("Referencias")]
    public EnemyBase enemy;

    private void Start()
    {
       enemy = GetComponentInParent<EnemyBase>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {

           enemy.playerDetected = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            enemy.playerDetected = false;

        }
        
    }
}
