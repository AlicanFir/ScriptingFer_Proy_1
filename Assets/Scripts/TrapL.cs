using UnityEngine;
using System.Collections;

public class TrapL : MonoBehaviour
{
    //VARIABLES
    
    //escritura
    [SerializeField] private float velocidad = 0;
    [SerializeField] private Vector3 direccionHorizontal = new Vector3(1,0,0);
    [SerializeField] private Vector3 direccionVertical = new Vector3(0, 1,0);
    
    [SerializeField] private float rango = 1.6f;

    
    //lectura
    private Vector3 direccionHorizontalActual;
    private Vector3 direccionVerticalActual;
    private float timerHorizontal = 0;
    private float timerVertical = 0;
    private float timerGeneral = 0;
    
    private bool isVertical = false;
    
    void Start()
    {
       direccionHorizontalActual = direccionHorizontal; 
       direccionVerticalActual = direccionVertical;
    }
    
    void Update()
    {
        timerGeneral += Time.deltaTime;
        if (timerGeneral >= rango)
        {
            isVertical = !isVertical;
            timerGeneral = 0;
        }
        
        if (isVertical)
        {
            MovimientoVertical();
        }
        else if (!isVertical)
        {
            MovimientoHorizontal();
        }
    }

    private void MovimientoHorizontal()
    {
        timerHorizontal+= Time.deltaTime;
        transform.Translate(direccionHorizontalActual * (velocidad * Time.deltaTime));

        if (timerHorizontal >= rango)
        {
            MovimientoVertical();
            direccionHorizontalActual *= -1;
            timerHorizontal = 0;
        }
    }

    private void MovimientoVertical()
    {
        timerVertical += Time.deltaTime;
        transform.Translate(direccionVerticalActual * (velocidad * Time.deltaTime));
        if (timerVertical >= rango)
        {
            direccionVerticalActual *= -1;
            timerVertical = 0;
        }
    }
    
}
