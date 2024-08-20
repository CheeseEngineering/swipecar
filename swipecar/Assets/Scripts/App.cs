using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // ∫§≈Õ¿« ª¨º¿¿ª ø¨Ω¿
    // « µÂ∏¶ ∏∏µÈ¿⁄ A,B(GameObject
    public GameObject AGo;
    public GameObject BGo;

    Vector3 Apos;
    Vector3 Bpos;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 a = AGo.transform.position;
        Vector3 b = BGo.transform.position;

        Debug.Log(a);
        Debug.Log(b);
        // b - a = c
        Vector3 c = b - a;
        Debug.Log(c); // πÊ«‚ ∫§≈Õ

        DrawArrow.ForDebug(a, c, 100, Color.yellow, ArrowType.Solid);

        
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Apos = Input.mousePosition;
            Debug.Log(Apos);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Bpos = Input.mousePosition;
            Debug.Log(Bpos);
            Vector3 Cpos = Bpos - Apos;
            Debug.Log(Cpos);
            DrawArrow.ForDebug(Apos, Cpos, 100, Color.yellow, ArrowType.Solid);
        }
    }
}
