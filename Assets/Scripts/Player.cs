using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    [SerializeField] private TMP_Text coinsCounter;
    
    private Vector3 posicionInicial;

    private int coins = 0;
    
    [SerializeField]  private float velocidad;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // capa el framerate a 60fps
        
        posicionInicial = new Vector3(7, 0, 0);
        this.gameObject.transform.position = posicionInicial;
        
        //this.gameObject.transform.rotation = Quaternion.Euler(0,90,45); //Un quaternion es una especie de vector que indica una rotacion. te da la rotacion por el camino mas corto.
        this.gameObject.transform.eulerAngles = new Vector3(0,0,0); // <-- mejor esto que poner quaternion o quaternion.euler
        //la w es el orden en el que se aplican los giros
        //Quaternion.Euler transforma de euler a quaterniones
        
        //this.gameObject.transform.localScale = new Vector3(2,2,1);


    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime = por segundo
        //this.gameObject.transform.position += new Vector3(0, 3f, 0)* Time.deltaTime; // 3 unidades por segundo

        Movement();
    }
    
    private void OnTriggerEnter2D(Collider2D other) //ASEGURATE DE QUE ES ESTO SI NO NO FUNCIONA
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ObtenerCoins(other); //ctrl + r + m --> convirte en una funcion automaticamente
        }
        else if (other.gameObject.CompareTag("Damage"))
        {
            transform.position = posicionInicial;
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
