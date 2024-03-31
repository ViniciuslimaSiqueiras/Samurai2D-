using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComTranslate : MonoBehaviour
{
    public float velocidadeCam;

    public Transform targetCam1V;
    public Transform targetCam2V;
    public Transform transformCam;
    public Transform _currentTarget;

    private void Start()
    {
        _currentTarget = targetCam1V;
    }

    private void Update()
    {
        
        translate();
    }


    void estabilaze()
    {
        transformCam.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void translate()
    {
        transform.position = Vector2.MoveTowards(transformCam.position,_currentTarget.position, velocidadeCam);

        if(_currentTarget == targetCam1V && transform.position == targetCam1V.position)
        {
            _currentTarget = targetCam2V;
        }
        else if(_currentTarget == targetCam2V && transform.position == targetCam2V.position)
        {
            _currentTarget = targetCam1V;
        }

    }
}
