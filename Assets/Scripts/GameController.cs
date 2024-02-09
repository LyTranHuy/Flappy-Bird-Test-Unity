using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndgame;
    int gamePoint = 0;

    public GameObject panelEndGame;

    public Text txtEndPoint;
    public Button btnRestart;

    public Text txtPoint;

    bool isStartFirstTime;   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        isEndgame = false;
        panelEndGame.SetActive(false);
        isStartFirstTime=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndgame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }
 
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        isEndgame = true;
        panelEndGame.SetActive(true);
        txtEndPoint.text = "Your Point:\n" + gamePoint.ToString();
        isStartFirstTime = false;
    }

    public void Restart()
    {
        StartGame();
    }

    public void PlusPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }

}
