using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player2D;
    Rigidbody2D rigid;

    float walkSpeed = 10.0f;
    float jumpForce = 680.0f;

    Vector3 movement;
    public int creatureType;
    public int score;
  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Creature")
        {
            SceneManager.LoadScene("GameScene");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player2D = GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.player2D.AddForce(transform.up * this.jumpForce);
        }


        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            player2D.AddForce(transform.right * -1 * walkSpeed);
           transform.localScale = new Vector3(-1.0f, 1.0f, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            player2D.AddForce(transform.right * walkSpeed);
            transform.localScale = new Vector3(1.0f, 1.0f, 1);
        }

        
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }

    }

    
       
}

