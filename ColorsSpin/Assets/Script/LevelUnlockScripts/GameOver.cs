using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool GameIsOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YourGameIsOver(){
        Time.timeScale = 0f; 
        gameOverUI.SetActive(false);
        GameIsOver = true;
    }
}
