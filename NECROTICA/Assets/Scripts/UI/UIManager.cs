using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject WinGameScreen;
    public GameObject menuScreen;

    private bool inMenu;
    
    public GameObject sword;

    public static UIManager instance;

    void Awake ()
	{
		instance = this;
	}

    private void Start()
    {
        LockCursor();
        Menu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        // Check for space key press to toggle menu
        if (inMenu && Input.GetKeyDown(KeyCode.Space))
        {
            CloseMenu();
        }
    }
    
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void GetSword()
    {
        if (sword == null)
        {
            Debug.LogError("sword is not assigned in UIManager.");
            return;
        }
        sword.SetActive(true);
    }

    public void DisableUI()
    {
        GameObject[] uiElements = GameObject.FindGameObjectsWithTag("UI");

        foreach (GameObject uiElement in uiElements)
        {
            uiElement.SetActive(false);
        }
    }

    public void GameOver()
    {
        DisableUI();
        gameOverScreen.SetActive(true);
        AudioManager.instance.Play("PlayerDeath");
        AudioManager.instance.Stop("LevelMusic");
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        DisableUI();
        WinGameScreen.SetActive(true);
        AudioManager.instance.Play("PlayerWin");
        AudioManager.instance.Stop("LevelMusic");
        Time.timeScale = 0f;
    }

    public void Menu()
    {
        menuScreen.SetActive(true);
        AudioManager.instance.Play("LevelMusic");
        Time.timeScale = 0f;
        inMenu = true;
    }

    private void CloseMenu()
    {
        Time.timeScale = 1f; // Resume the game
        menuScreen.SetActive(false);
        inMenu = false;
    }

    private void OnEnable()
    {
        //PlayerHealth.OnPlayerDeath += EnableGameOver;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
