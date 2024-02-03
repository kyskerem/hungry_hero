using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    private bool isPaused;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ToggleMenu()
    {
        if (isPaused)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
            return;
        }

        gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnLevelLoad()
    {
        // Reset the instance reference
        Instance = null;
        // Deactivate the pause menu
        gameObject.SetActive(false);
    }
}


