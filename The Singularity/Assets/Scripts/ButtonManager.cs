using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour

{
    
    public void ReloadCurrentScene()
    {
        
        string currentSceneName = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(currentSceneName);
    }

    
    public void LoadMainMenu()
    {
        
        SceneManager.LoadScene("1");
    }
}


