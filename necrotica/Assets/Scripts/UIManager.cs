using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

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
        UnlockCursor();
    }

    private void Start()
    {
        LockCursor();

        AudioManager.instance.Play("Level music");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            AudioManager.instance.Play("Button press");

            RestartLevel();
        }
    }
}
