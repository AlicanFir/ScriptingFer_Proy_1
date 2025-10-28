using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variables
    [SerializeField] private TMP_Text coinsCounter;
    [SerializeField] private TMP_Text deathCounter;
    [SerializeField] private int condicionPasada;
    [SerializeField] private int nextScene;
    
    Transition transitionScript;
    

    private int coins = 0;
    private int deaths = 0;
    
    [SerializeField]  private float velocidad;
    [SerializeField] private Vector3 posicionInicial = new Vector3(0,0,0);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // capa el framerate a 60fps
        
        this.gameObject.transform.position = posicionInicial;
        this.gameObject.transform.eulerAngles = new Vector3(0,0,0); // <-- mejor esto que poner quaternion o quaternion.euler
        
        transitionScript = gameObject.GetComponent<Transition>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ObtenerCoins(other); //ctrl + r + m --> convirte en una funcion automaticamente
        }
        else if (other.gameObject.CompareTag("Damage"))
        {
            transform.position = posicionInicial;
            deaths++;
            deathCounter.text = "Deaths : " + deaths.ToString();
        }
        else if (other.gameObject.CompareTag("PassPlatform") && coins == condicionPasada)
        {
            transitionScript.LoadNextLevel();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("AHHHHHHHHHHHH");
        }
    }
    private void ObtenerCoins(Collider2D other)
    {
        coins++;
        Destroy(other.gameObject); //formas de destruir otros game objects
        coinsCounter.text = ("Score: " + coins.ToString());
        Debug.Log(coins);
    }
    
    private void Movement()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movementDirection = new Vector3(hInput, vInput,0).normalized;
        transform.Translate(movementDirection*(velocidad*Time.deltaTime), Space.World); //metodo para realizar traslaciones
    }
}
