using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float health = 10f;
    int powerUpLeft;
    public float speed = 5f;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        //Forward Movment
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Left Movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Backward Movement
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        //Right Movement
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //Press Space Death
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health--;
            Text.GetComponent<Text>().text = ("Gamescore: " + health);
            if (health == 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
        PowerUpLeft();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            health++;
            powerUpLeft--;
            Text.GetComponent<Text>().text = ("Gamescore: " + health);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            health = 0;
            if (health == 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
    private void PowerUpLeft()
    {
        powerUpLeft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total: " + powerUpLeft.ToString());

        if (powerUpLeft == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
