using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // �޾ƿ� ���ӿ�����Ʈ Ÿ�� ���� ����
    private GameObject touchScreenGo;
    // �޾ƿ� ���ӿ�����Ʈ Ÿ�Կ� ������Ʈ�� ���ִ� ��ũ��Ʈ�� ���� ���� ����
    public App app;
    // �븮�� ����
    public Action onMoveCompleted;
    // �̵��ӵ� ���� ����
    private float translateSpeed;
    void Start()
    {
        // App ��ũ��Ʈ�� ������Ʈ�� ���ִ� ���� ������Ʈ �ޱ�
        touchScreenGo = GameObject.Find("touchScreen");
        // ���� ������Ʈ���� ������Ʈȭ �Ǿ��ִ� ��ũ��Ʈ �ν��Ͻ�ȭ
        app = touchScreenGo.GetComponent<App>();
        
    }
    void Update()
    {
        // App ��ũ��Ʈ ������ �̵��ӵ� ���� ������ �̵�
        this.transform.Translate(app.MoveSpeed.x, 0, 0);
        // �̵��ӵ� ����
        app.MoveSpeed.x *= 0.96f;
        // 0.01~0.001 ������ �ӵ��� �� �븮�� ȣ���ϰ� �̵��ӵ��� 0���� ����� �븮�� ���� ȣ�� ����
        if (app.MoveSpeed.x < 0.01 && app.MoveSpeed.x > 0.001) 
        {
            onMoveCompleted();
            app.MoveSpeed.x = 0;
        }
        // ȭ�� �ۿ� �������� �ӵ� 0���� ���� (clamp�� �̿��Ͽ� ī�޶� ���� �ʰ��� �ִ밪, �ּڰ����� x��ǥ ����)
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
