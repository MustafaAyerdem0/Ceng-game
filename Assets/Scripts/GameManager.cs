using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeCountDown;
    public static GameManager instance;
    public bool startGame;
    public bool finishGame;

    public GameObject startGamePanel;

    public GameObject winPanel;
    public GameObject LosePanel;

    public GameObject retryGameButton;

    public TMP_Text cdUi;

    public int PlayerPosition = 1;


    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        cdUi.text = ((int)timeCountDown).ToString();
        if(timeCountDown>0) timeCountDown-= Time.deltaTime;
        else if(!startGame && timeCountDown <= 0 && !finishGame) {startGamePanel.SetActive(false); startGame=true;}
    }

    public void RetryGame(){

        SceneManager.LoadScene(0);

    }
}
