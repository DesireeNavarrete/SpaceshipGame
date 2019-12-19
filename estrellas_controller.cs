using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estrellas_controller : MonoBehaviour
{
    public Animator anim;
    public float cont;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cont += Time.deltaTime;

        if(cont >= 5)
        {
            anim.speed += 0.1f;
            cont = 0;
        }

    }
}
