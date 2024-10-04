using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOver;

    public static UIManager instance;

    void Awake ()
	{
		instance = this;
	}
    

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }



    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    private void OnEnable()
    {
        //PlayerHealth.OnPlayerDeath += EnableGameOver;
    }



    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            //AudioManager.instance.Play("Button press");
            RestartLevel();
        }
    }
}
