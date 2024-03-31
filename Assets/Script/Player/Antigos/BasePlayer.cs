using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    [Header("Animation")]
    public string runAnim = "Run";
    public string jumpAnim = "Jump";

    [Header("Move")]
    public int velocity = 5;
    public int _currentVelocity = 5;
    public bool _isMoving;

    [Header("jump")]
    public int jumpForce = 5;
}
