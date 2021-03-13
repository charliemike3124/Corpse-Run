using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject playerPrefab;
    [HideInInspector] public PlayerManager player;

    [Header("Tutorial Prompts")]
    public bool interaction;
    public bool toggle;
    public bool dash;
    public bool checkpoint;

    [Header("UI Elements")]
    public GameObject _finishAlert;

    [Header("Checkpoint")]
    public Vector3 _chekpointPos = new Vector3(0,0,0); 

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
        Instance = Instance != null ? null : this;
    }

    public void EndGame(){
        GameObject m_finishAlert = Instantiate(_finishAlert);
        m_finishAlert.GetComponent<Image>().DOFade(0.8f, 1.5f);
        m_finishAlert.transform.Find("Game Over Text").DOScale(1.1f, 1f).OnComplete(() =>
        {
            m_finishAlert.GetComponentInChildren<GameObject>().transform.DOScale(1f, 0.2f);
        });
        m_finishAlert.transform.SetParent (GameObject.Find ("Canvas").transform, false);
        RestartSceneAfterSeconds(3);
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

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    private void LoadActiveScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
