using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] itemCoin;           //������ ���� �÷����� 
    public Transform[] spawnPoints;         // ������ ��ġ �������ְ�

    public string enemyName;
    public int enemyScore;
    public float speed;
    public int health;
    public Sprite[] sprites;        // �Ѿ� �¾��� �� �׸� ��ȭ�� ������ �ϴ� �� 

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject bulletC;
    public GameObject bulletD;
    public GameObject bulletE;

    public GameObject player;
    public ObjectManager objectManager;
    public GameManager gameManager;

    Animator anim;

    public int patternNumber;        //���� 
    public int curPatternNumber;
    public int[] MaxpatternNumber;


    void Awake()
    {
        anim = GetComponent<Animator>();    
    }

    void OnEnable()
    {
        health = 1000;
        Invoke("Stop", 2);
    }

    void Stop()
    {
        if (!gameObject.activeSelf)
            return;
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.zero;

        Invoke("Think", 2);
    }

    void Think()
    {
        patternNumber = patternNumber == 4 ? 0 : patternNumber + 1;
        curPatternNumber = 0;

        switch (patternNumber)
        {
            case 0:
                PatternA();
                break;

            case 1:
                PatternB();
                break;

            case 2:
                PatternC();
                break;

            case 3:
                PatternD();
                break;

            case 4:
                PatternE();
                break;
        }
    }

    void PatternA()
    {
        //GameObject bullet = Instantiate(bulletA, transform.position, transform.rotation);
    }

    void PatternB()
    {
    
    }

    void PatternC()
    {

    }

    void PatternD()
    {

    }

    void PatternE()
    {

    }


}
