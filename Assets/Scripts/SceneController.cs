using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("FinalLevel");
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
