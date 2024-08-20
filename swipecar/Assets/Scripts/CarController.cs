using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // 받아올 게임오브젝트 타입 변수 선언
    private GameObject touchScreenGo;
    // 받아온 게임오브젝트 타입에 컴포넌트로 들어가있는 스크립트를 받을 변수 선언
    public App app;
    // 대리자 선언
    public Action onMoveCompleted;
    // 이동속도 변수 선언
    private float translateSpeed;
    void Start()
    {
        // App 스크립트가 컴포넌트로 들어가있는 게임 오브젝트 받기
        touchScreenGo = GameObject.Find("touchScreen");
        // 게임 오브젝트에서 컴포넌트화 되어있는 스크립트 인스턴스화
        app = touchScreenGo.GetComponent<App>();
        
    }
    void Update()
    {
        // App 스크립트 내부의 이동속도 변수 가져와 이동
        this.transform.Translate(app.MoveSpeed.x, 0, 0);
        // 이동속도 감소
        app.MoveSpeed.x *= 0.96f;
        // 0.01~0.001 사이의 속도일 시 대리자 호출하고 이동속도를 0으로 만들어 대리자 연속 호출 방지
        if (app.MoveSpeed.x < 0.01 && app.MoveSpeed.x > 0.001) 
        {
            onMoveCompleted();
            app.MoveSpeed.x = 0;
        }
        // 화면 밖에 못나가게 속도 0으로 변경 (clamp를 이용하여 카메라 범위 초과시 최대값, 최솟값으로 x좌표 변경)
        if (this.transform.position.x < -8)
        {
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
            app.MoveSpeed.x = 0;
        }
        else if (this.transform.position.x > 8)
        {
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
            app.MoveSpeed.x = 0;
        }

    }
}
