using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float translateSpeed;
    public Vector3 mousePosition1;
    public Vector3 mousePosition2;
    public Vector3 swiperate;
    void Start()
    {

    }


    void Update()
    {

        bool isDown = Input.GetMouseButtonDown(0);
        bool isUp = Input.GetMouseButtonUp(0);
        if (isDown)
        {
            mousePosition1 = Input.mousePosition;
            Debug.Log(mousePosition1);
        }
        else if (isUp)
        {
            mousePosition2 = Input.mousePosition;
            Debug.Log(mousePosition2);
            swiperate = mousePosition2 - mousePosition1;
            translateSpeed = swiperate.x * 0.002f;
        }
        this.transform.Translate(translateSpeed, 0, 0);
        translateSpeed *= 0.96f;
    }
}
