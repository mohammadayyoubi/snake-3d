
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Text pauseText;

    void Start()
    {
        pauseText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseTheGame();

        }
    }

    public void pauseTheGame()
    {
        if (Time.timeScale == 1)
        {
            // Pause the game
            Time.timeScale = 0;
            pauseText.gameObject.SetActive(true);
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
        }
    }
            if (Time.timeScale == 1)
            {
                // Game not paused
                Time.timeScale = 0; // Pause the game
                pauseText.gameObject.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                // Game is paused
                Time.timeScale = 1; // Resume the game
                pauseText.gameObject.SetActive(false);
            }

        }
    }

    public void pauseTheGame()
    {
        if (Time.timeScale == 1)
        {
            // Pause the game
            Time.timeScale = 0;
            pauseText.gameObject.SetActive(true);
        }
        else
        {
            // Resume the game
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
        }
    }
}
