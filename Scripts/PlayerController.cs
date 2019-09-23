using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText ();
        loseText.text = "";
        SetLivesText ();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    } 

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText ();
        }

        if (count == 8)
        {
            transform.position = new Vector2(40.0f, 60.0f);
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 16)
        {
            winText.text = "Perfect! Game Created by Ethan Wood!";
        }
    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "You lose! Press esc to quit and try again!";
        }
    }
}
