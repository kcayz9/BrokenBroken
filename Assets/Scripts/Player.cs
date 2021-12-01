using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isTouchTop;
    public bool isTouchBottom;
    public bool isTouchRight;
    public bool isTouchLeft;

    public int speed;
    public int power;
    public int score;
    public float maxShotLoading;
    public float curShotLoading;
    public float rotateSpeed;

    public GameObject bulletObj;
    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        // �׳� ������ 
        float h = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed, Space.Self);   // ���ڰ� �ӵ���ŭ ������ �����̴� �� 
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        Vector3 curPos = transform.position;       // ���� 
        Vector3 nexPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        // ������� ����� ���� �����      //�̹� Ű��� !! �Ѹ�ó�� ����� ��ƸԴ´� // Ȳ�ݾ� ���� 
        transform.position = curPos + nexPos;
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;

       // if (curShotLoading < maxShotLoading)
         //   return;

        GameObject bullet = Instantiate(bulletObj, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
 
    }

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
        
        if(other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            item.type = "Coin";
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
    
