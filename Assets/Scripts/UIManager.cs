using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    Button playGameBtn;

    [SerializeField]
    Text playGameBtnLable;

    public Text totalMoneyLable;

    public Text currentWave;

    [SerializeField]
    Text totalEscapedLable;

    [SerializeField]
    Text totalWaveLable;

    [SerializeField]
    Text playBtnLable;

    //[SerializeField]
    //Text EnemyInWave;

    //int currentWave; //Тукущая волна

    EnemyManager enemyManager;
    DataGame dataGame;
    void Start()
    {
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        playGameBtn.gameObject.SetActive (false);
        //EnemyInWave.text = enemyManager.totalEnemies.ToString();
        dataGame = GameObject.FindObjectOfType<DataGame>();
        totalWaveLable.text = "/ " + dataGame.TotalWaves.ToString();
        totalMoneyLable.text = dataGame.TotalMoney.ToString();
    }


    void Update()
    {

    }
}
