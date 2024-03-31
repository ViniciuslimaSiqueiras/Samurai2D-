using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5f);
    }
    void destroy()
    {
        Destroy(gameObject);
    }
    
}
