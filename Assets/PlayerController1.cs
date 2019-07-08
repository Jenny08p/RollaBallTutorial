using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText ();
        SetScoreText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
       
        if (Input.GetKey("escape"))
     Application.Quit();

    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count +1;
            SetCountText ();
        }

          if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            score = score +5;
            SetScoreText ();
        }

        if (other.gameObject.CompareTag ( "Pick Bad"))
        {
            other.gameObject.SetActive (false);
            score = score -5;
            SetScoreText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 6)
        {
            winText.text = "You Win!";
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
         }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString ();
    }
}
