using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Variables
    [SerializeField] private TMP_Text coinsCounter;
    [SerializeField] private TMP_Text deathCounter;
    [SerializeField] private int condicionPasada;
    [SerializeField] private int nextScene;
    [SerializeField] private GameObject deathScreen;
    
    private Rigidbody2D rb;
    [SerializeField] Transition transitionScript;
    

    private int coins = 0;
    private int deaths = 0;

    private float hInput;
    private float vInput;
    private bool isDead = false;
    
    [SerializeField]  private float velocidad;
    [SerializeField] private Vector3 posicionInicial = new Vector3(0,0,0);
    
    void Start()
    {
        Application.targetFrameRate = 60; // capa el framerate a 60fps
        
        this.gameObject.transform.position = posicionInicial;
        this.gameObject.transform.eulerAngles = new Vector3(0,0,0); // <-- mejor esto que poner quaternion o quaternion.euler
        
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");

        if (deaths >= 5)
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
        }
        else if (!isDead)
        {
            Movement();
        }
        
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
        rb.AddForce(new Vector2(hInput,vInput)*velocidad,  ForceMode2D.Impulse);
    }

    private void Death()
    {
        isDead =  true;
        deathScreen.SetActive(true);
    }
    
}
