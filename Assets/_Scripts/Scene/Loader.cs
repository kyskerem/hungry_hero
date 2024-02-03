
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
        if (currentScene == 4)
        {
            StartCoroutine(nameof(HandleLastScene));
        }
        SceneManager.LoadScene(currentScene);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
    IEnumerator HandleLastScene()
    {

        SceneManager.LoadScene(currentScene);
        yield return new WaitForSeconds(4f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}