using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenuObj;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject defeatScreen;
    [SerializeField] private TextMeshProUGUI moneyLabel;
    [SerializeField] private int rewardMoney;
    [SerializeField] private int rewardMoneyForVictory;
    private int money;
    public int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }

    public int RewardMoney
    {
        get
        {
            return rewardMoney;
        }
    }

    public void StartTheGame()
    {
        startMenuObj.SetActive(false);
        PlayerManager.PlayerManagerInstance.gameState = true;
        PlayerManager.PlayerManagerInstance.menu = this;
        money = PlayerPrefs.GetInt("money");
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.SetActive(true);
        money += rewardMoneyForVictory;
    }
    public void ShowDefeatScreen()
    {
        defeatScreen.SetActive(true);
    }

    public void RestartGame()
    {
        PlayerPrefs.SetInt("money", money);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartTheGame();
    }

    private void Update()
    {
        moneyLabel.text = money.ToString();
    }
}
