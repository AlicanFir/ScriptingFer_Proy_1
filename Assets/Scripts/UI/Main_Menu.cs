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
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);  
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    

}
