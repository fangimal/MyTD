using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameStatus { next, play, gameover, win }
public class DataGame : MonoBehaviour
{
    gameStatus currentStatus = gameStatus.play;

    public int totalWaves = 10;

    int currentWave; //Тукущая волна
    int totalMoney = 10;
    int waveNumber = 0;

    UIManager uIManager;

    public int TotalWaves
    {
        get { return totalWaves; }
    }
    public int TotalMoney
    {
        get { return totalMoney; }
        set
        {
            totalMoney = value;
            //uIManager.totalMoneyLable.text = TotalMoney.ToString();
        }
    }
    void Start()
    {
        //uIManager = GameObject.FindObjectOfType<UIManager>();
    }

    
    void Update()
    {
        
    }
}
