using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    //funcion para cargar la escena
    public static void restartGame()
    {
        SceneManager.LoadScene("game");
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "enemy")
        {
            Destroy(other.gameObject, 0);
        }
    }
}
