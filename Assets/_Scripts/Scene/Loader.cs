
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    private int currentScene = 0;
    public static Loader Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void LoadNextLevel()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

}