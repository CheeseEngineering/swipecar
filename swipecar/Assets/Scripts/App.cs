using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // ���ӿ�����Ʈ Ÿ�� ���� ����
    private GameObject carGo;
    // ����3 Ÿ���� ��ǥ ����, �̵��ӵ� ���� ����
    private Vector3 leftPosition;
    private Vector3 rightPosition;
    public Vector3 MoveSpeed;
    // ���ӿ�����Ʈ ������ ������Ʈ�� �ִ� ��ũ��Ʈ CarController Ŭ���� Ÿ���� ���� ����
    private CarController carController;
    // ����� �ҽ� ������Ʈ�� ������ ���� ����
    public AudioSource AudioSource;

    void Start()
    {
        // ��ũ��Ʈ�� ������Ʈȭ�Ǿ��ִ� ���ӿ�����Ʈ ����
        carGo = GameObject.Find("car");
        // ������Ʈ�� �ִ� ��ũ��Ʈ ����
        carController = carGo.GetComponent<CarController>();
        // ����� �ҽ� ������Ʈ ��������
        AudioSource = carGo.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // �̵� �Ϸ�� ȣ���� �Ķ��� ������ �͸�޼���
        carController.onMoveCompleted = () => { Debug.Log("�̵��� �Ϸ�Ǿ����ϴ�."); };
        // bool ���� ��Ŭ�� ��Ŭ����
        bool isDown = Input.GetMouseButtonDown(0);
        bool isUp = Input.GetMouseButtonUp(0);
        // ��Ŭ���� ��ǥ ����
        if (isDown)
        {
            leftPosition = Input.mousePosition;
            Debug.Log(leftPosition);
        }
        // ��Ŭ���� ��ǥ ���� �� ��ǥ������ �Ÿ�, �ӵ� ����
        else if (isUp)
        {
            rightPosition = Input.mousePosition;
            Debug.Log(rightPosition);
            MoveSpeed = (rightPosition-leftPosition)*0.002f;
            // �Ҹ� ����
            AudioSource.Play();
            Debug.Log($"�θ�");
        }
    }
}
