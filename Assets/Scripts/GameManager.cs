using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening; 

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject playerPrefab;
    [HideInInspector] public PlayerManager player;

    [Header("Tutorial Prompts")]
    public bool interaction;
    public bool toggle;
    public bool dash;

    [Header("UI Elements")]
    public GameObject _finishAlert; 

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

    public void EndGame(){
        GameObject m_finishAlert = Instantiate(_finishAlert, new Vector3(0,250,0), Quaternion.identity) as GameObject;
        m_finishAlert.transform.SetParent (GameObject.Find ("Canvas").transform, false);
        m_finishAlert.transform.localPosition = new Vector3 (0, 250, 0);
        m_finishAlert.transform.DOLocalMove(new Vector3(0,0,0), 1.0f); 
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
