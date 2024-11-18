using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public RoadScript roadScript;
    public PlayerScript playerScript;
    public Controller controllerScript;

    public Text statusText;        
    public GameObject restartButton;
    public GameObject startPanel;

    public GameObject currentRoad;
    public bool isGameStart;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0;
        isGameStart = false;
    }

    private void Update()
    {
        if (!isGameStart && (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) { 
            isGameStart = true;
            startPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels available!");
        }
    }
}
