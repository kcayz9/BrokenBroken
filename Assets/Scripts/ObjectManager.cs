using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject mudPrefab;
    public GameObject rocksPrefab;
    public GameObject bTreePrefab;
    public GameObject bTree2Prefab;
    public GameObject bonePrefab;
    public GameObject bulletPlayerPrefab;

    public GameObject[] coin;
    public GameObject[] mud;
    public GameObject[] rocks;
    public GameObject[] bTree;
    public GameObject[] bTree2;
    public GameObject[] bone;

    public GameObject[] targetPool;
    public GameObject[] bulletPlayer;

    void Awake()
    {
        coin = new GameObject[100];
        mud = new GameObject[100];
        rocks = new GameObject[100];
        bTree = new GameObject[100];
        bTree2 = new GameObject[100];
        bone = new GameObject[100];

        bulletPlayer = new GameObject[1000];        //플레이어 총알 보스는 총알이 없음 

        Generate();
    }

    void Generate()
    {
        for (int number = 0; number < coin.Length; number++)
        {
            coin[number] = Instantiate(coinPrefab);
            coin[number].SetActive(false);
        }
        
        for (int number = 0; number < mud.Length; number++)
        {
            mud[number] = Instantiate(mudPrefab);
            mud[number].SetActive(false);
        }

        for (int number = 0; number < rocks.Length; number++)
        {
            rocks[number] = Instantiate(rocksPrefab);
            rocks[number].SetActive(false);
        }

        for (int number = 0; number < bTree.Length; number++)
        {
            bTree[number] = Instantiate(bTreePrefab);
            bTree[number].SetActive(false);
        }

        for (int number = 0; number < bTree2.Length; number++)
        {
            bTree2[number] = Instantiate(bTree2Prefab);
            bTree2[number].SetActive(false);
        }

        for (int number = 0; number < bone.Length; number++)
        {
            bone[number] = Instantiate(bonePrefab);
            bone[number].SetActive(false);
        }
        //#.player bullet 
        for (int number = 0; number < bulletPlayer.Length; number++)
        {
            bulletPlayer[number] = Instantiate(bulletPlayerPrefab);
            bulletPlayer[number].SetActive(false);
        }

    }

    public GameObject MakeObjs (string type)
    { 
        switch(type)
        {
            case "Coin":
                targetPool = coin;
                break;

            case "Mud":
                targetPool = mud;
                break;
      
            case "Rocks":
                targetPool = rocks;
                break;

            case "BTree":
                targetPool = bTree;
                break;

            case "BTree2":
                targetPool = bTree2;
                break;

            case "Bone":
                targetPool = bone;
                break;

            case "BulletPlayer":
                targetPool = bulletPlayer;
                break;

        }

        for (int number = 0; number < targetPool.Length; number++)
        
        {
            if (!targetPool[number].activeSelf)
            {
                targetPool[number].SetActive(true);
                return targetPool[number];
            }

        }
        
        return null;
    }



}
