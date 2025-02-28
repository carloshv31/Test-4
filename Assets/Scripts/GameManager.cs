using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isGameOver;
    //public bool isPaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void PauseGame()
    //{

    //    isPaused = !isPaused;

    //    if (isPaused)
    //    {
    //        Time.timeScale = 0;
    //    }

    //    else
    //    {
    //        Time.timeScale = 1;
    //    }
    //}

    public void GameOver()
    {
        isGameOver = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isGameOver = false;
    }

    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        isGameOver = false;
    }
}
