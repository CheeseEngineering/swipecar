using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    // 받아올 게임오브젝트 타입 변수 선언
    private GameObject textGo;
    private GameObject flagGo;
    private GameObject carGo;
    // 거리를 저장할 변수 선언
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        // 이름으로 게임오브젝트 찾아서 넣기 (필드로 게임 오브젝트를 어사인 하는 것을 추천함)
        flagGo = GameObject.Find("flag");
        textGo = GameObject.Find("Text (Legacy)");
        carGo = GameObject.Find("car");
    }
    void Update()
    {
        // 깃발을 넘어갔을 때 Game Over 출력
        if (distance < 0)
        {
            textGo.GetComponent<Text>().text = $"Game Over";
        }
        // 깃발을 넘어가지 않았을 때 거리 출력
        else
        {
            distance = flagGo.transform.position.x - carGo.transform.position.x;
            textGo.GetComponent<Text>().text = $"깃발까지의 거리 : {Mathf.Abs(distance):0}M";
        }
        
    }
}
