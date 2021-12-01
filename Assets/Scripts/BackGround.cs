using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;
    public float yCheck;

    float viewHeight;           //카메라 위치 조정 

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    void Update()
    {
        Move();
        Scrolling();
    }
    void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }
    void Scrolling()
    {
        yCheck = sprites[endIndex].position.y;
        if (sprites[endIndex].position.y < viewHeight * (-1))
        {
            
            //#.Sprite ReUse 
            Vector3 backSpritesPos = sprites[startIndex].localPosition;
            Vector3 frontSpritesPos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritesPos + Vector3.up * viewHeight;

            //#.Cursor Index Change 
            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave -1 == -1) ? sprites.Length - 1 : startIndexSave - 1;      //배열을 넘어가지 않도록 예외 처리
                                        //     끝점으로 가시고 아니면 그대로 해달라
        }

    }
}
