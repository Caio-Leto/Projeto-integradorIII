using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class isotermica : MonoBehaviour
{
    public TextMeshPro _pressao_txt;
    public float _pressao_value = 0;
    public float _Time_For_Add;
    public TextMeshPro _volume_txt;
    // public bool aquecer = false;
    public float _volume_value = 0;
    public bool upButton = false;
    public bool downButton = false;
    public bool _Save_State_Up_Button;
    public bool _Save_State_Down_Button;
    public float ControlIncrementDecrement = 0;
    public string callAddorRemove;
    private bool rodar = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    void refresh_text()
    {
        if (_volume_value <= 45 && _volume_value >= 30)
        {
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


            if (ControlIncrementDecrement == 1f && _volume_value == 45)
            {
                rodar = false;
            }else if (ControlIncrementDecrement == -1f && _volume_value == 30)
            {
                rodar = false;
            }

            if (rodar)
            {
                _pressao_value = calculo_isotermico(_pressao_value, _volume_value, (_volume_value + ControlIncrementDecrement));
                _volume_value += ControlIncrementDecrement;
                _pressao_txt.text = " " + _pressao_value.ToString("F") + " atm";
                _volume_txt.text = " " + _volume_value + " cm³";
                Invoke(callAddorRemove, _Time_For_Add);
            }


            rodar = true;
        }
        // _pressao_value -= 0.4f; //0.133 p/s     
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

    float calculo_isotermico(float p1, float v1, float v2)
    {
        float p2 = p1 * v1 / v2;
        return p2;
    }
}
