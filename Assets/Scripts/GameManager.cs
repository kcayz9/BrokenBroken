using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public GameObject[] itemCoin;           //아이템 코인 올려놓고 
    public Transform[] spawnPoints;         // 아이템 위치 선정해주고 

    public float maxSpawnLoading;           // 아이템이 생성되는 최대 로딩 시간
    public float curSpawnLoading;           // 아이템이 생성되는 현재 로딩 시간


    void Update()
    {
      curSpawnLoading += Time.deltaTime;
   
      if (curSpawnLoading > maxSpawnLoading)
      {
          SpawnItem();
          maxSpawnLoading = Random.Range(0.5f, 3f);
          curSpawnLoading = 0; 
      }
        
    }

    void SpawnItem()
    {
        int ranCoin = Random.Range(0, 1);
        int ranCoinPoint = Random.Range(0, 35);

        Instantiate(itemCoin[ranCoin], spawnPoints[ranCoinPoint].position, spawnPoints[ranCoinPoint].rotation);
    }
}
