using UnityEngine;

public class Trap : MonoBehaviour
{
    //VARIABLES
    
    //escritura
    [SerializeField] private float velocidad = 0;
    [SerializeField] private Vector3 direccionInicial = new Vector3(1,0,0);
    
    //lectura
    private Vector3 direccionActual;

    private float timer = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       direccionActual = direccionInicial; 
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // esto es un temporizador
        transform.Translate(direccionActual * (velocidad * Time.deltaTime));

        if (timer >= 2f)
        {
            direccionActual *= -1;
            timer = 0;
        }
        
        //Debug.Log(timer);
    }
}
