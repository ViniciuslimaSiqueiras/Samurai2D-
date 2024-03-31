using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscutoOplayer : MonoBehaviour
{
    [Header("String")]
    public string player = "Player";


    [Header("Referencias")]
    //public CircleCollider2D trigger;
    public PlayerMove playerMove;
    public EnemyMove enemyMove;
    private void Start()
    {
       // trigger = GetComponent<CircleCollider2D>();
        enemyMove = GetComponentInParent<EnemyMove>();
        playerMove = GameObject.FindObjectOfType<PlayerMove>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
       /* if (collision.gameObject.CompareTag(player) && !playerMove.Streeth && playerMove.rb.velocity.x != 0)
        {
            if(enemyMove._currentCoroutine != null)
            {
             enemyMove.StopAllCoroutines();
            }
            enemyMove._currentTarget = enemyMove.PlayerTarget;
        }*/
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(enemyMove != null) 
        if(enemyMove._currentTarget == enemyMove.PlayerTarget)
        {
            enemyMove.StopAllCoroutines();
            enemyMove.StartCoroutine(TimeToReturn());
        }
    }
    
    IEnumerator TimeToReturn()
    {
        yield return new WaitForSeconds(3f);
        enemyMove._currentTarget = enemyMove.target1;

        yield return new WaitForSeconds(3f);
        enemyMove._currentCoroutine = null; 
    }
}
