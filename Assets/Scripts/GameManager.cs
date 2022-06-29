using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject[] itemCoin;           //아이템 코인 올려놓고 
    public Transform[] spawnPoints;         // 아이템 위치 선정해주고 
    public bool onOff;

    public float maxSpawnLoading;           // 아이템이 생성되는 최대 로딩 시간
    public float curSpawnLoading;           // 아이템이 생성되는 현재 로딩 시간

    public GameObject player;
    public GameObject enemy;

    public Text scoreText;
    public GameObject gameOverSet;

    public ObjectManager objectManager;

    void Update()
    {
      curSpawnLoading += Time.deltaTime;
   
      if (curSpawnLoading > maxSpawnLoading)
      { 
          SpawnEnemy();

          maxSpawnLoading = Random.Range(0.5f, 3f);
          curSpawnLoading = 0; 
      }

        //#.UI Score Update
        Player playerLogic = player.GetComponent<Player>();
        scoreText.text = string.Format("{0:n0}", playerLogic.score);


    }

    public void SpawnEnemy()
    {
       
        int ranObjs = Random.Range(0, 6);
        int ranPoint = Random.Range(0, 35);

        Instantiate(itemCoin[ranObjs], spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnHit();
        }
    }
    void OnHit()
    {
        Enemy enemyLogic = enemy.GetComponent<Enemy>();

        Player playerLogic = player.GetComponent<Player>();
        playerLogic.health -= enemyLogic.dmg;
    }
}
