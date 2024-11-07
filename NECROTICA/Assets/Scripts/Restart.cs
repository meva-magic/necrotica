using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    private void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}