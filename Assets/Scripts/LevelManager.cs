using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

    public void StartMenu()
    {
        SceneManager.LoadScene("Start");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void LevelZero()
    {
        SceneManager.LoadScene("Level 0");
    }
    public void LevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void LevelFour()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void EndLevel()
    {
        SceneManager.LoadScene("EndGame");
    }
}
