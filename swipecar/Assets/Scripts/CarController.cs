using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject flagGo;
    // �ӵ� ����
    public float translateSpeed;
    // ��Ŭ���� ��ǥ
    public Vector3 mousePosition1;
    // ��Ŭ���� ��ǥ
    public Vector3 mousePosition2;
    // ��Ŭ�� ��ǥ-��Ŭ�� ��ǥ : ��ǥ ������ �Ÿ�
    public Vector3 swiperate;

    public float flagDistance;
    void Start()
    {
      flagGo =   GameObject.Find("flag");
     
    }


    void Update()
    {
        // bool ���� ��Ŭ�� ��Ŭ����
        bool isDown = Input.GetMouseButtonDown(0);
        bool isUp = Input.GetMouseButtonUp(0);
        // ��Ŭ���� ��ǥ ����
        if (isDown)
        {
            mousePosition1 = Input.mousePosition;
            Debug.Log(mousePosition1);
        }
        // ��Ŭ���� ��ǥ ���� �� ��ǥ������ �Ÿ�, �ӵ� ����
        else if (isUp)
        {
            mousePosition2 = Input.mousePosition;
            Debug.Log(mousePosition2);
            swiperate = mousePosition2 - mousePosition1;
            translateSpeed = swiperate.x * 0.002f;
            Debug.Log($"�̵� �Ÿ� : {Mathf.Abs(swiperate.x)}");
        }
        // �̵�
        this.transform.Translate(translateSpeed, 0, 0);
        float distance = flagGo.transform.position.x - this.transform.position.x;
        Debug.Log($"��߱����� �Ÿ� : {Mathf.Abs(distance)}M");


        // �̵��ӵ� ����
        translateSpeed *= 0.96f;
    }
}
