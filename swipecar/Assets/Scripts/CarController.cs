using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // �ӵ� ����
    public float translateSpeed;
    // ��Ŭ���� ��ǥ
    public Vector3 mousePosition1;
    // ��Ŭ���� ��ǥ
    public Vector3 mousePosition2;
    // ��Ŭ�� ��ǥ-��Ŭ�� ��ǥ : ��ǥ ������ �Ÿ�
    public Vector3 swiperate;
    void Start()
    {

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
        }
        // �̵�
        this.transform.Translate(translateSpeed, 0, 0);
        // �̵��ӵ� ����
        translateSpeed *= 0.96f;
    }
}
