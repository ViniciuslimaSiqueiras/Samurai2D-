using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool dash; 

    public GameObject DashAni;
    public Transform DashPos;
    public ParticleSystem DashPar;
    public PlayerMove Playermove;
    private void Start()
    {
        Playermove = GameObject.FindObjectOfType<PlayerMove>();
    }
    void Update()
    {
         DashParticle();
        
    }
    void DashParticle()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            var dash = Instantiate(DashAni);
            dash.transform.position = DashPos.position;
          
            Destroy(dash, 2);
        }
    }
}
