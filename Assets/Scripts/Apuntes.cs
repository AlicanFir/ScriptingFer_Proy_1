using UnityEngine;

public class Apuntes : MonoBehaviour
{
    //Declarar variables 
    // private(solo accesible desde este script)
    // protected (solo accesible desde jerarquia de clases) - solo accesible con jerarquia de clases, en familia
    // publico (accesible desde cualquier punto del programa) -- NO SE HACEN VARIABLES PUBLICAS -- se muestra en el inspector
    
    //POR DEFECTO SON PRIVADAS
    //SerializedField muestra variables en el inspector y prioriza el valor colocado en el inspector
    // si ponemos en serializedfield no poner valor, asi no hay tantos problemas.
    
    /*
    [SerializeField] int numeroA = 5;
    [SerializeField] string cadena = "Hola Mundo";
    [SerializeField] bool envenenado = false;
    [SerializeField] float velocidad;
    */
    
    [Header("Player Data")] 
    [SerializeField] private int vidas;
    [SerializeField] private float velocidad;
    [SerializeField] private string nombre;
    
    [Header("Energias")]
    [SerializeField] private int energia;
    [SerializeField] private int energiaMax;
    [SerializeField] private int energiaTemp;

    private int numeroRandom;
    private float decimalRandom;
    
        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hola Mundo"); // los debug
        
        numeroRandom = Random.Range(0, 100); // entre 0 y 99
        Debug.Log(numeroRandom); 
        
        decimalRandom = Random.Range(-100f, 50f); //para decimales
        
        //this.gameObject = el gameobject en el que esta este script, el this es redundante
        Debug.Log(this.gameObject.name);
    }

    void Update()
    {
        //La toma de inputs siempre desde el update
        EjemploInputs();
    }
    
    void EjemploInputs()
    {
        //Fases de toma de inputs por teclado
        if (Input.GetKey(KeyCode.W)) { this.gameObject.transform.position += new Vector3(0, 3f, 0)* Time.deltaTime;}
        if (Input.GetKey(KeyCode.A)) { this.gameObject.transform.position += new Vector3(-3f, 0, 0)* Time.deltaTime;}
        if (Input.GetKey(KeyCode.S)) { this.gameObject.transform.position += new Vector3(0, -3f, 0)* Time.deltaTime;}
        if (Input.GetKey(KeyCode.D)) { this.gameObject.transform.position += new Vector3(3f, 0, 0)* Time.deltaTime;}
        
        
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        
        Vector3 movementDirection = new Vector3(hInput, vInput,0).normalized;
        
        this.gameObject.transform.position += movementDirection * velocidad;
        
        Vector3 MovHorizontal = new Vector3(hInput, 0, 0).normalized;
        Vector3 MovVertical = new Vector3(0, vInput, 0).normalized;
        
        if (hInput != 0 || vInput != 0)
        {
            this.gameObject.transform.position += MovHorizontal * (Time.deltaTime * velocidad);
            this.gameObject.transform.position += MovVertical * (Time.deltaTime * velocidad);
        }
        
        
        
    }
}
