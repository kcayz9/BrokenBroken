using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public GameObject[] itemCoin;           //������ ���� �÷����� 
    public Transform[] spawnPoints;         // ������ ��ġ �������ְ� 
    public bool onOff;

    public float maxSpawnLoading;           // �������� �����Ǵ� �ִ� �ε� �ð�
    public float curSpawnLoading;           // �������� �����Ǵ� ���� �ε� �ð�

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
