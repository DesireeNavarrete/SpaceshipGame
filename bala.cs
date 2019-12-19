using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bala : MonoBehaviour
{
    
    public float velocidad = 5f;

    void Update()
    {
        //Movimiento bala
        float y = velocidad * Time.deltaTime;
        transform.Translate(0, y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject, 0);
        }
    }
}

