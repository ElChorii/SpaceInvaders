using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;
    
    [HideInInspector] public GameObject currentSpaceship;
    [HideInInspector] public string currentSpaceshipDEBUG;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        //Ship Selector
        
    }

    public void LoadScene(GameObject selectedSpaceship)
    {
        currentSpaceship = selectedSpaceship;
        SceneManager.LoadScene("Game");
    }

    public void LoadSceneDEBUG(string selectedSpaceship)
    {
        currentSpaceshipDEBUG = selectedSpaceship;
        SceneManager.LoadScene("Game");
    }
}
