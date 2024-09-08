using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryUI;
    // Update is called once per frame
    void Update()
    {
        GameObject spawnController = GameObject.FindWithTag("SpawnerController");
        var currentLevel = spawnController.GetComponent<SpawnerControllerScript>().currentLevel;

        if (currentLevel >= 3)
        {
            victoryUI.SetActive(true);
        }    
    }

    public void MainMenu()
    {
        //resumes the game
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("StartingMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
