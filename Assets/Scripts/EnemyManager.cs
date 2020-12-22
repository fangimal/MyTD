using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    GameObject spawn; //Точка возрождения врагов


    public Enemy[] enemiesArray; //Массив вариантов врагов

    public int totalEnemies = 5; //Количесвто врагов в этом уровне
    public int enemiesPerSpawn; //Сколько врагов появляются за раз

    public List<Enemy> EnemyList = new List<Enemy>();

    int k; //Враг будет появлятся с этим индексом в имени

    const float spawnDelay = 0.5f; // Скорость появления противников

    int roundEscaped = 0;
    int totalEscaped = 0;
    int totalKilled = 0;
    int enemiesToSpawn = 0;

    public int RoundEscaped
    {
        get { return roundEscaped; }
        set { roundEscaped = value; }
    }
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {

    }
    public void RegisterListEnemy(Enemy enemy) //Добавляет новых врагов в лист EnemyList
    {
        EnemyList.Add(enemy);
    }
    public void UnRegisterListEnemy(Enemy enemy) //Удаляет из EnemyList врага
    {
        EnemyList.Remove(enemy);
    }

    IEnumerator Spawn()
    {
        if (enemiesPerSpawn > 0 && EnemyList.Count < totalEnemies)
        {
            if (EnemyList.Count < totalEnemies)
            {
                Enemy newEnemy = Instantiate(enemiesArray[0]);
                newEnemy.transform.position = spawn.transform.position;

                newEnemy.name = newEnemy + " " + (k + 1);
                k++;
            }
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawn());
    }

    public void IsWaveOver()
    {

    }

}
