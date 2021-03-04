using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorPlayer : MonoBehaviour
{
    public float JumpFoce = 10f;
    public float PlatformJump = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public GameObject deathParticel;
    public string newLevel;

    public string currentColor;

    public Color colorCyan;
    public Color colorYelow;
    public Color colorMagenta;
    public Color colorPink;
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            rb.velocity = Vector2.up * JumpFoce;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            
            return;
        }
        else if (col.tag == "Platform")
        {
            
            rb.velocity = Vector2.up * PlatformJump;
            return;
        }
        else if (col.tag == "WinPoint")
        {
            LevelControlScript.instance.youWin ();
            Debug.Log("You Win");
        }
        else if (col.tag == "EndPoint")
        {
            SceneManager.LoadScene(newLevel);
        }

        if (col.tag != currentColor)
        {
            LevelControlScript.instance.youLose();
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Instantiate(deathParticel, transform.position,Quaternion.identity);
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 3);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yelow";
                sr.color = colorYelow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}

