using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int target = 0; //Цель куда двигаться врагу, индекс в массиве wayPoints
    [SerializeField]
    Transform[] wayPoints; //Массив контрольных точек движения

    [SerializeField]
    Transform finish;

    EnemyManager enemyManager;


    Transform enemy;
    //Collider2D enemyCollider;

    public float moveSpeed; //Скорость движения врага

    void Start()
    {
        enemy = GetComponent<Transform>();
        enemyManager = GameObject.FindObjectOfType<EnemyManager>();
        enemyManager.RegisterListEnemy(this);
        //enemyCollider = GetComponent<Collider2D>();
        //wayPoints = GameObject.FindGameObjectsWithTag("MovingPoint");
    }


    void Update()
    {
        if (wayPoints != null)
        {
            if (target < wayPoints.Length)
            {
                enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, moveSpeed*Time.deltaTime);
            }
            else
            {
                enemy.position = Vector2.MoveTowards(enemy.position, finish.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MovingPoint")
        {
            target ++;
        }
        if (collision.tag == "Finish")
        {
            enemyManager.RoundEscaped++;
            enemyManager.UnRegisterListEnemy(this);
            Destroy(enemy.gameObject);
        }
    }
}
