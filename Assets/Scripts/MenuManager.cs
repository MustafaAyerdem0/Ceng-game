using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
   
    public GameObject settingUi;

    public static MenuManager instance; // Singleton

    public int money = 0;

    public TMP_Text moneyText;

    public int difficult;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }

        difficult = 10;
    }


    void Start()
    {
        // Oyun başladığında kaydedilmiş para miktarını yükle
        money = PlayerPrefs.GetInt("money", 0);
        moneyText.text = money.ToString();

    }

    public void AddMoney(int value){
        money += value;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.Save();
        moneyText.text = money.ToString();
    }


    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void OpenSetting(){
        settingUi.SetActive(!settingUi.activeSelf);
    }

    public void QuitGame(){
        Application.Quit();
    }


}
