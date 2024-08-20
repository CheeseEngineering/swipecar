using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // �޾ƿ� ���ӿ�����Ʈ Ÿ�� ���� ����
    private GameObject textGo;
    private GameObject flagGo;
    private GameObject carGo;
    // �Ÿ��� ������ ���� ����
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        // �̸����� ���ӿ�����Ʈ ã�Ƽ� �ֱ� (�ʵ�� ���� ������Ʈ�� ����� �ϴ� ���� ��õ��)
        flagGo = GameObject.Find("flag");
        textGo = GameObject.Find("Text (Legacy)");
        carGo = GameObject.Find("car");
    }
    void Update()
    {
        // ����� �Ѿ�� �� Game Over ���
        if (distance < 0)
        {
            textGo.GetComponent<Text>().text = $"Game Over";
        }
        // ����� �Ѿ�� �ʾ��� �� �Ÿ� ���
        else
        {
            distance = flagGo.transform.position.x - carGo.transform.position.x;
            textGo.GetComponent<Text>().text = $"��߱����� �Ÿ� : {Mathf.Abs(distance):0}M";
        }
        
    }
}
