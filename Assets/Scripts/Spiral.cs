using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Spiral : MonoBehaviour
{
    //no se escribe codigo fuera de las funciones
    //Variables
    [SerializeField] private float velRot;
    [SerializeField] private Vector3 directionRot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionRot = new Vector3(0,0,1);
        transform.Rotate((directionRot*(velRot*Time.deltaTime)), Space.World);
    }
}
