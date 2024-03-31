using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
        {
            Invoke(nameof(menu), 2);
        }
    }
    void menu()
    {
        SceneManager.LoadScene(0);
    }
}
