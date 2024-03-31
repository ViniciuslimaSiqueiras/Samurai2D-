using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViuOplayer : MonoBehaviour
{
    [Header("PlayerDetected")]
    public float distance;

    [Header("LayerMask")]
    public LayerMask playerLayer;


    [Header("Timers")]
    public float tempoPraAndarProPlayer = 0.5f;
    public float tempoPraAndarProTarget = 3f;

    [Header("Strings")]
    public string player = "Player";

    [Header("referencias")]
    public EnemyMove enemymove;
    public Transform Enemy;
    public Transform Ray;
    private void Start()
    {
        enemymove = GetComponentInParent<EnemyMove>();
        
    }
    void Update()
    {
        PlayerDetected();
    }
       
    IEnumerator TimeToMoveT1()
    {
        yield return new WaitForSeconds(tempoPraAndarProTarget);
        enemymove._currentTarget = enemymove.target1;
        enemymove._currentCoroutine = null;

    }
    void PlayerDetected()
    {
        RaycastHit2D hit;
        if(enemymove.Dir == 1)
        {
         hit = Physics2D.Raycast(Ray.position, transform.right, distance, playerLayer);
             if (hit)
             {
               enemymove.StopAllCoroutines();
                enemymove._currentTarget = enemymove.PlayerTarget;
                enemymove._currentCoroutine = null;
                Debug.DrawLine(transform.position, hit.point);
             }
             else if (!hit && enemymove._currentTarget == enemymove.PlayerTarget && enemymove._currentCoroutine == null)
             {
                enemymove.StartCoroutine(TimeToMoveT1());
 
             }

        }
        else if(enemymove.Dir == 0)
        {
            hit = Physics2D.Raycast(Ray.position, -transform.right, distance, playerLayer);
                if (hit)
                {
                    Debug.DrawLine(transform.position, hit.point);
                      enemymove.StopAllCoroutines();
                        enemymove._currentTarget = enemymove.PlayerTarget;
                          enemymove._currentCoroutine = null;

                }
                else if (!hit && enemymove._currentTarget == enemymove.PlayerTarget && enemymove._currentCoroutine == null)
                {
                    enemymove.StartCoroutine(TimeToMoveT1());                    

                }
        }
    }
}
