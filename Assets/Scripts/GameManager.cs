using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    public GameObject[] itemCoin;           //������ ���� �÷����� 
    public Transform[] spawnPoints;         // ������ ��ġ �������ְ� 

    public float maxSpawnLoading;           // �������� �����Ǵ� �ִ� �ε� �ð�
    public float curSpawnLoading;           // �������� �����Ǵ� ���� �ε� �ð�


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
