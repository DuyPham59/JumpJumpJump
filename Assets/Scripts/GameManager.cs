using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player playerScript;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "ScenePlay")
        {
            playerScript = GameObject.Find("Player").GetComponent<Player>();
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ScenePlay" && playerScript.gameOver)
        {
            gameOver.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
