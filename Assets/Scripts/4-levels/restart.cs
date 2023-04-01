using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string menuName;
    
    public void RestartGame()
    {
            SceneManager.LoadScene(sceneName);    // Input can either be a serial number or a name; here we use name.
    }
    public void quitGame(){
        Application.Quit();
    }
    public void menuGame()
    {
            SceneManager.LoadScene(menuName);    // Input can either be a serial number or a name; here we use name.
    }
}
