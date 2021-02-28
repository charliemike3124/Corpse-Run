using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject playerPrefab;
    [HideInInspector] public PlayerManager player;

    [Header("Tutorial Prompts")]
    public bool interaction;
    public bool toggle;
    public bool dash;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
        if (Instance != null)
        {
            Debug.LogWarning("more than one instance of GameManager found.");
            return;
        }
        Instance = this;
    }

    private void Update()
    {
        if (player.GetComponent<InputManager>().escape)
        {
            LoadActiveScene();
        }
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
