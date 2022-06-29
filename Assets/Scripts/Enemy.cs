using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string type;
    Rigidbody2D rigid;
    public float speed;
    public GameObject player;
    public int dmg;
   

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;      // 
    }

}

