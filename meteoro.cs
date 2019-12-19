using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meteoro : MonoBehaviour
{
    private float velocidad = 12f;
    public SpriteRenderer met1, met2, met3;
    private TrailRenderer trail;
    public GameObject explosion;
    private GameObject explosionCop;
    private int metId;
    public CapsuleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        //Se van destruyendo los meteoritos cada 5 segundos, para que no se acumulen y ralenticen
        Destroy(gameObject, 5);
        metId = Random.Range(0, 3);
        trail = GetComponent<TrailRenderer>();
        coll = GetComponent<CapsuleCollider2D>();

        switch (metId)
        {
            case 0:
                met1.enabled = true;
                break;
            case 1:
                met2.enabled = true;
                break;
            case 2:
                met3.enabled = true;
                break;
        }

    }

    void Update()
    {
        //movimiento meteorito
        float y = velocidad * Time.deltaTime;
        transform.Translate(0, -y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bala")
        {
            //Cuando el meteorito toca la balla, se destruye en 0 segundos
            explosionCop = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(coll, 0);
            Destroy(met1, 0);
            Destroy(met2, 0);
            Destroy(met3, 0);
            Destroy(trail, 0);
            this.velocidad = 0;
            nave_mov.scoreCont++;
            Destroy(explosionCop.gameObject,1);
        }

        if (other.gameObject.tag == "Player")
        {
            //Cuando el meteorito toca la balla, se destruye en 0 segundos
            explosionCop = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(met1, 0);
            Destroy(met2, 0);
            Destroy(met3, 0);
            Destroy(trail, 0);
            this.velocidad = 0;
            Destroy(explosionCop.gameObject, 1);
        }

    }

   
}
