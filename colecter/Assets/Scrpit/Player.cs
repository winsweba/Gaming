using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed;
    public float rotateAmount;
    public int winingPoint = 5;
    float rot;
    int score;
    public GameObject winText;
    public GameObject effect;
    public GameObject deadEffect;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(mousePos.x < 0)
            {
                rot = rotateAmount;
            }
            else
            {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot); 
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "food")
        {
            Destroy(collision.gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            score++;

            if(score >= winingPoint)
            {
                LevelControlScript.instance.youWin();
                print("Levl Complete");
                //winText.SetActive(true);
                
            }
        }
        else if(collision.gameObject.tag == "danger")
        {
            Destroy(gameObject);
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            LevelControlScript.instance.youLose();
        }
    }
}
