using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public void StartGame(int S)
    {
        SceneManager.LoadScene(S);
    }
}
