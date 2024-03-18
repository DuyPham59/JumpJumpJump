using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private AudioSource music;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.gameOver)
        {
            music.Stop();
        }       
    }
}
