using System;
using UnityEngine;

public class Skip_Menu : MonoBehaviour
{ 
    [SerializeField] Transition transitionScript;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transitionScript.LoadNextLevel();
        }
    }
}
