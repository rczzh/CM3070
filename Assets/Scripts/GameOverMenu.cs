using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    Player playerStats;
    GameObject player;
    public float health;

    public GameObject gameOverUI;
    private bool isPlayerDead = false;


    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        health = playerStats.playerHealth;

        if (health <= 0 && !isPlayerDead)
        {
            isPlayerDead = true;
            gameOverUI.SetActive(true);

            //stop the game
            Time.timeScale = 0f;
        }
    }

    public void Restart()
    {
        //resumes the game
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
