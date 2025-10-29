using System;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    Transition transitionScript;
    [SerializeField] GameObject endPlatform;

    private void Start()
    {
        transitionScript = endPlatform.GetComponent<Transition>();
    }

    private void Update()
    {

    }
}
