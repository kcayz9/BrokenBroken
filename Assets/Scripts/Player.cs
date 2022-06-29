using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public int score;       //스코어 만들 준비 
    public int speed;
    public int power;
    public int health;
    
    public float maxShotLoading;
    public float curShotLoading;
    public float rotateSpeed;

    public GameObject bulletObj;

    public bool[] joyControl;
    public bool isControl;

    void Update()
    {
        Move();
       // Fire();
    }
    public void JoyPanel(int type)
    {
        for (int index = 0; index < 9; index++)
        {
            joyControl[index] = index == type;
        }
    }

    public void JoyDown()
    {
        isControl = true;
    }

    public void JoyUp()
    {
        isControl = false;
    }

    void Move()
    {
        //#.Keyboard Control Value
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //#.Joy Control Value
        if (joyControl[0]) { h = -1; v = 1; }   // 방향 버튼 변수에 따라 수평, 수직 값 적용 
        if (joyControl[1]) { h = 0; v = 1; }
        if (joyControl[2]) { h = 1; v = 1; }
        if (joyControl[3]) { h = -1; v = 0; }
        if (joyControl[4]) { h = 0; v = 0; }
        if (joyControl[5]) { h = 1; v = 0; }
        if (joyControl[6]) { h = -1; v = -1; }
        if (joyControl[7]) { h = 0; v = -1; }
        if (joyControl[8]) { h = 1; v = -1; }

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1) || !isControl)  //방향 Down 변수 조건을 추가형 UI 누른 상태에서만 작동 
            h = 0;


        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1) || !isControl)  //방향 Down 변수 조건을 추가형 UI 누른 상태에서만 작동 
            v = 0;

        Vector3 curPos = transform.position;       // 현재 
        Vector3 nexPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        // 순서대로 만드는 것을 적어라      //미믹 키우기 !! 팩맨처럼 사람을 잡아먹는다 // 황금알 깨기 
        transform.position = curPos + nexPos;
    }

         //void Fire()
         //{
         //    if (!Input.GetButton("Fire1"))
         //        return;
         //
         //   // if (curShotLoading < maxShotLoading)
         //     //   return;
         //
         //    GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation);
         //    Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
         //    rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
         //   
         //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
        
        else if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            switch (enemy.type)
            {
        
                case "Mud":
                    score-=1;
                    health -=1;
                    break;

                case "Bone":
                    score-=2;
                    health -= 2;
                    break;

                case "Rocks":
                    score-=3;
                    health -= 3;
                    break;

                case "BrokenTree":
                    score-=4;
                    health -= 4;
                    break;

                case "BrokenTree2":
                    score-=4;
                    health -= 5;
                    break;

            }
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    score += 5;
                    break;
            }
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            switch (other.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }

    }
}
    
