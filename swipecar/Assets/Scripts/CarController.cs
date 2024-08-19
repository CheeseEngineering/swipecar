using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // 속도 변수
    public float translateSpeed;
    // 좌클릭시 좌표
    public Vector3 mousePosition1;
    // 우클릭시 좌표
    public Vector3 mousePosition2;
    // 우클릭 좌표-좌클릭 좌표 : 좌표 사이의 거리
    public Vector3 swiperate;
    void Start()
    {

    }


    void Update()
    {
        // bool 변슈 좌클릭 우클릭시
        bool isDown = Input.GetMouseButtonDown(0);
        bool isUp = Input.GetMouseButtonUp(0);
        // 좌클릭시 좌표 저장
        if (isDown)
        {
            mousePosition1 = Input.mousePosition;
            Debug.Log(mousePosition1);
        }
        // 우클릭시 좌표 저장 및 좌표사이의 거리, 속도 저장
        else if (isUp)
        {
            mousePosition2 = Input.mousePosition;
            Debug.Log(mousePosition2);
            swiperate = mousePosition2 - mousePosition1;
            translateSpeed = swiperate.x * 0.002f;
        }
        // 이동
        this.transform.Translate(translateSpeed, 0, 0);
        // 이동속도 감소
        translateSpeed *= 0.96f;
    }
}
