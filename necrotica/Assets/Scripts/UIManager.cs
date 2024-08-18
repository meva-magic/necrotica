using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;

    public void EnableGameOver()
    {
        gameOver.SetActive(true);
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOver;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
}
