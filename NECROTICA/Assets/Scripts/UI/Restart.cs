using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    /*public GameObject loadingScreen; // UI ����� ��������
    public float timer = 10f; // ������ ��� ��������� ��������
    private bool isChecking = false; // ����, ����� ������ �������� ����� �������

    public RoomTemplates roomTemplates; // ������ �� RoomTemplates

    private void Start()
    {
        if (loadingScreen != null)
        {
            loadingScreen.SetActive(true); // ���������� ����� �������� ��� ������
        }
    }

    private void Update()
    {
        // ����������� ������
        if (!isChecking)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isChecking = true; // ���������� ��������, ����� ������ ����
            }
        }

        // ��������� �������� ������ ����� ��������� �������
        if (isChecking)
        {
            CheckConditionsAndRestart();
        }
    }

    // ����� �������� ������� � �������� ������
    private void CheckConditionsAndRestart()
    {
        bool hasEnoughRooms = roomTemplates.rooms.Count >= 14;
        bool bossExists = GameObject.Find("Boss(Clone)") != null;
        //bool keykeeperExists = GameObject.Find("keykeeper(Clone)") != null;

        // ���� ������� �� �����������, ������������� �����
        if (!hasEnoughRooms || !bossExists )
        {
            RestartLevel();
        }
        else if (loadingScreen != null)
        {
            loadingScreen.SetActive(false); // ������������ ����� ��������, ���� �� ��
            isChecking = false; // ������������� ��������
        }
    }

    // ����� ��� ����������� ������
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}
