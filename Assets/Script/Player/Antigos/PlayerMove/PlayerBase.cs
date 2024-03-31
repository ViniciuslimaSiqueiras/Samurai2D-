using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Header("Animator")]
    public string run = "Velocity";
    public string DashAttack = "Dash";
    public string pulo = "Jump";

    [Header("Atack")]
    public bool estaAtacando;

    [Header("floorCheck")]
    public float distancia;
    public bool inFloor;
    public LayerMask floor;

    [Header("Dash")]
    public bool PossoDaDash;
    public int timeToDash;

    [Header("Street")]
    public float streetMove = 18;
    public bool Streeth;

    [Header("Jump")]
    public int jumpPower = 40;
    public int _currentJumpPower;
    public bool fall;


    [Header("Move")]
    public float _currentVelocity;
    public float velocity = 35;
    public float velocityrb;
    public float Dir = 1;
    public bool andando;

    public Vector3 direction;

}
