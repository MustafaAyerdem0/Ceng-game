using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float timeCountDown;
    public static GameManager instance;
    public bool startGame;

    public GameObject startGamePanel;

    public TMP_Text cdUi;


    private void Awake() {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        cdUi.text = ((int)timeCountDown).ToString();
        if(timeCountDown>0) timeCountDown-= Time.deltaTime;
        else if(!startGame && timeCountDown <= 0) {startGamePanel.SetActive(false); startGame=true;}
    }
}
