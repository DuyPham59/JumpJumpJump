using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  bool gameOver;
    public float speed;
    private Vector3 upDown;
    private Vector3 posPlayerTarget;
    private List<string> highOrLow = new List<string>();
    public AudioClip jump;
    public AudioClip death;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3.5f;
        highOrLow = new List<string>();
        posPlayerTarget = transform.position;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveLeftRight();
        MoveTopDown();
    }
    void MoveLeftRight()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerAudio.PlayOneShot(jump, 1f);
                posPlayerTarget = posPlayerTarget + new Vector3(5, 0, 0);
                if (posPlayerTarget.x > 5)
                {
                    posPlayerTarget = posPlayerTarget - new Vector3(5, 0, 0);                   
                }
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerAudio.PlayOneShot(jump, 1f);
                posPlayerTarget = posPlayerTarget - new Vector3(5, 0, 0);
                if (posPlayerTarget.x < -5)
                {
                    posPlayerTarget = posPlayerTarget + new Vector3(5, 0, 0);                  
                }
            }
            if ((transform.position.x + speed * 2 * Time.deltaTime) <= posPlayerTarget.x)
            {
                transform.Translate(Vector3.right * speed * 2 * Time.deltaTime);
            }
            else if ((transform.position.x - speed * 2 * Time.deltaTime) >= posPlayerTarget.x)
            {
                transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
            }
        }
    }
    void MoveTopDown()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                highOrLow.Add("Low");
                playerAudio.PlayOneShot(jump, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                highOrLow.Add("High");
                playerAudio.PlayOneShot(jump, 1f);
            }
            if (highOrLow.Count == 0)
            {
                if (transform.position.y <= 0.5)
                {
                    upDown = Vector3.up;
                }
                else if (transform.position.y >= 2.5)
                {
                    upDown = Vector3.down;
                }
            }
            else if (highOrLow.Count != 0)
            {
                if (transform.position.y <= 0.5)
                {
                    upDown = Vector3.up;
                }
                else if (highOrLow[0] == "Low" && transform.position.y >= 1.5 && upDown == Vector3.up)
                {
                    highOrLow.RemoveAt(0);
                    upDown = Vector3.down;
                }
                else if (highOrLow[0] == "High" && transform.position.y >= 4.5 && upDown == Vector3.up)
                {
                    highOrLow.RemoveAt(0);
                    upDown = Vector3.down;
                }
            }
            transform.Translate(upDown * speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            gameOver = true;
            playerAudio.PlayOneShot(death, 1f);
        }
    }
}
