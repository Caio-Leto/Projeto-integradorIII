using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class leiZeroOptica : MonoBehaviour
{
    public float _pressao_value = 0;
    public float _Time_For_Add;
    public float eixoX = 0;
    public bool upButton = false;
    public bool downButton = false;
    public bool _Save_State_Up_Button;
    public bool _Save_State_Down_Button;
    public float ControlIncrementDecrement = 0;
    public string callAddorRemove;
    private bool rodar = true;
    public GameObject red;
    public GameObject yelow;
    public GameObject green;
    // Start is called before the first frame update
    void Start()
    {

    }

    void refresh_text()
    {
            eixoX += ControlIncrementDecrement;
            if (_Save_State_Up_Button)
            {
                ControlIncrementDecrement = 1f;
                callAddorRemove = "Refresh_Scale_For_Add";
            }
            else if (_Save_State_Down_Button)
            {
                ControlIncrementDecrement = -1f;
                callAddorRemove = "Refresh_Scale_For_Remove";
            }


            if (ControlIncrementDecrement == 1f && eixoX >= 60)
            {
                rodar = false;
            }else if (ControlIncrementDecrement == -1f && eixoX <= 0)
            {
                rodar = false;
            }

            if (rodar)
            {
                // _pressao_value = calculo_isotermico(_pressao_value, eixoX, (eixoX + ControlIncrementDecrement));
                red.transform.Rotate(ControlIncrementDecrement, 0.0f, 0.0f);
                green.transform.Rotate(ControlIncrementDecrement, 0.0f, 0.0f);
                Invoke(callAddorRemove, _Time_For_Add);
            }
            rodar = true;    
    }
    // Update is called once per frame
    void Update()
    {   
        if (upButton)
        {
            refresh_text();
            upButton = false;
        }

        if (downButton)
        {
            refresh_text();
            downButton = false;
        }
    }
    public void Add(bool adding)
    {
        upButton = adding;
        _Save_State_Up_Button = adding;
    }
    public void Remove(bool removing)
    {   

        downButton = removing;
        _Save_State_Down_Button = removing;
    }
    void Refresh_Scale_For_Add()
    {
        upButton = _Save_State_Up_Button;
    }
    void Refresh_Scale_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }
}
