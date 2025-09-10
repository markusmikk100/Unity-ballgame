using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TMP_Text scoreText;
    public TMP_Text winText;
    public GameObject gate;

    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);


                if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
            if (score >= 5)
            {
                gate.SetActive(true);
            }
        }

        if (other.gameObject.CompareTag("Danger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 10)
        {
            winText.text = "You Win! Press R to Restart";
        }
    }
}
