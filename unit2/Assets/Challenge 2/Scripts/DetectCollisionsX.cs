using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectCollisionsX : MonoBehaviour
{
    private GameObject gameOverText;

    private void Awake()
    {

        gameOverText = GameObject.Find("GameOver");

        if (gameOverText == null)
        {
            Debug.LogWarning("game over not found");
        }
        else
        {
            gameOverText.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
                Debug.Log("Text was shown");
            }

            Time.timeScale = 0f;
            Invoke("ResetScene", 2f);
            Debug.Log("needed log");
        }

        Destroy(gameObject);
        Debug.Log("Object Was Destroyed");
    }

    void ResetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
