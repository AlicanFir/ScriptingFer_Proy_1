using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
    [SerializeField] private int nextScene;
    
    
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene(nextScene);
    }    
    
    public void OnClickQuitButton()
    {
        Application.Quit();
    }
    
    
    
    
    
}
