using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // 게임오브젝트 타입 변수 선언
    private GameObject carGo;
    // 벡터3 타입의 좌표 변수, 이동속도 변수 선언
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    public Vector3 MoveSpeed;
    // 게임오브젝트 내부의 컴포넌트로 있는 스크립트 CarController 클래스 타입의 변수 선언
    private CarController carController;
    // 오디오 소스 컴포넌트를 저장할 변수 선언
    public AudioSource AudioSource;

    void Start()
    {
        // 스크립트가 컴포넌트화되어있는 게임오브젝트 받음
        carGo = GameObject.Find("car");
        // 컴포넌트로 있는 스크립트 받음
        carController = carGo.GetComponent<CarController>();
        // 오디오 소스 컴포넌트 가져오기
        AudioSource = carGo.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 이동 완료시 호출할 식람다 형태의 익명메서드
        carController.onMoveCompleted = () => { Debug.Log("이동이 완료되었습니다."); };
        // bool 변슈 좌클릭 우클릭시
        bool isDown = Input.GetMouseButtonDown(0);
        bool isUp = Input.GetMouseButtonUp(0);
        // 좌클릭시 좌표 저장
        if (isDown)
        {
            leftPosition = Input.mousePosition;
            Debug.Log(leftPosition);
        }
        // 우클릭시 좌표 저장 및 좌표사이의 거리, 속도 저장
        else if (isUp)
        {
            rightPosition = Input.mousePosition;
            Debug.Log(rightPosition);
            MoveSpeed = (rightPosition-leftPosition)*0.002f;
            // 소리 내기
            AudioSource.Play();
            Debug.Log($"부릉");
        }
    }
}
