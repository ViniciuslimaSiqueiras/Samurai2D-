using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LifeManage lifeEnemy;
    //public _Dash dash;
    private void Start()
    {
        //dash = GameObject.FindObjectOfType<_Dash>();
        lifeEnemy = GameObject.FindObjectOfType<LifeManage>();
        
    }
    private void Update()
    {
     /*   if (dash.Dashing || lifeEnemy.death)
        {
          ignoreLayer();
        }
        else
        {
         Physics2D.IgnoreLayerCollision(6, 7,false);
        }
        */
    }
    void ignoreLayer()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
    }



}
