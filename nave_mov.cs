using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nave_mov : MonoBehaviour
{
    public float velocidad;
    private int rotNave = 30;
    public GameObject bala, spawnBala, meteorito, spawnMeteorito;
    public GameObject vida1,vida2,vida3;
    GameObject balaCreada;
    public float spawnTime = 0.5f;
    private float timer = 0;
    public static int vidas;

    //Spawnpos, arrayMet
    private Vector3 spawnPos = new Vector3(0, -6, 0);
    public GameObject mets;
    public static GameObject destroyMetsTrigger;
    public static int scoreCont;
    public Text scoreText;

    private void Awake()
    {
        destroyMetsTrigger = GameObject.Find("_GAMEMANAGER");
        
    }
    void Start()
    {
        vidas = 4;
        destroyMetsTrigger.SetActive(false);
    }

    void Update()
    {
        //Input system
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 0)
        {
            transform.Translate(0, 5*velocidad*Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x <= 15)
        {
            transform.Translate(5 * velocidad * Time.deltaTime, 0,0);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x >= -15)
        {
            transform.Translate(-5 * velocidad * Time.deltaTime, 0,0);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y >= -8)
        {
            transform.Translate(0,-5 * velocidad * Time.deltaTime, 0, 0);
        }

        //Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            balaCreada=Instantiate(bala, spawnBala.transform.position, Quaternion.identity);
            Destroy(balaCreada, 5);
        }

        //Tiempo spawn meteoritos y UI score
        timer += Time.deltaTime;   
        if (timer > spawnTime)  
        {
            spawnMet();       
            timer = 0;       
        }

        scoreText.text = scoreCont.ToString();

    }
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            transform.position = spawnPos;//al quitar una vida a la nave, la movemos a la posicion original
            despawnMet(); //destruir meteoritos
            vidas--;//restamos vida
            print("vidas= " + vidas);

            //al llegar a 0 vidas, reseteamos el nivel
            if (vidas == 0)
            {
                print("you die");
                UI_Manager.restartGame();//cargamos la escena d nuevo
            }

            if (vidas == 1)
            {
                vida1.SetActive(false);
            }

            if (vidas == 2)
            {
                vida2.SetActive(false);
            }

            if (vidas == 3)
            {
                vida3.SetActive(false);
            }
        }
    }


    //Aparicion de los meteoritos
    void spawnMet()
    {
        Instantiate(meteorito, spawnMeteorito.transform.position + new Vector3(Random.Range(-10.0f, 10.0f), 20,0), Quaternion.identity);
    }

    //Destruir todos los meteoritos
    void despawnMet()
    {
        Destroy(mets, 0);
        destroyMetsTrigger.SetActive(true);
        StartCoroutine(resetTrigger());
    }

    IEnumerator resetTrigger()
    {
        destroyMetsTrigger.SetActive(false);

        yield return new WaitForSeconds(0.1f);
    }
}
