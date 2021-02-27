using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("more than one instance of GameManager found.");
            return;
        }
        Instance = this;
    }

    public void RestartSceneAfterSeconds(float time)
    {
        Invoke("LoadActiveScene", time);
    }

    private void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
