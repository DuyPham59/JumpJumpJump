using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMoveBack : MonoBehaviour
{
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.gameOver)
        {
            transform.Translate(Vector3.back * playerScript.speed * Time.deltaTime);
            if (transform.position.z < -10)
            {
                gameObject.SetActive(false);
            }
        }       
    }
}
