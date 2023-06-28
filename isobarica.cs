using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class isobarica : MonoBehaviour
{
    public TextMeshPro _temperatura_txt;
    public float _temperatura_value = 0;
    public float _Time_For_Add;
    public TextMeshPro _volume_txt;
    // public bool aquecer = false;
    public float _volume_value = 0;
    public bool upButton = false;
    public bool _Save_State_Up_Button;
    public bool downButton = false;
    public bool _Save_State_Down_Button;
    public float ControlIncrementDecrement;
    public bool rodar1 = true;
    public string callAddorRemove;
    // Start is called before the first frame update
    void Start()
    {

    }

    void refresh_text()
    {
        if (_volume_value >= 29f && _volume_value <= 33f)
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
            if (ControlIncrementDecrement == 1f && _volume_value >= 32.6f)
            {
                rodar1 = false;
            }
            else if (ControlIncrementDecrement == -1f && _volume_value <= 30f)
            {
                rodar1 = false;
            }
            
            if (rodar1){
                _volume_value = calculo_isobarico(_volume_value, _temperatura_value, (_temperatura_value + ControlIncrementDecrement));
                _temperatura_value += ControlIncrementDecrement;
                _temperatura_txt.text = " " + _temperatura_value.ToString("F") + " k";
                _volume_txt.text = " " + _volume_value.ToString("F") + " cm³";
                Invoke(callAddorRemove, _Time_For_Add);
            }
            
        }
        rodar1 = true;
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
    void Refresh_Scale_For_Add()
    {
        upButton = _Save_State_Up_Button;
    }
    public void Remove(bool removing)
    {
        downButton = removing;
        _Save_State_Down_Button = removing;
    }
    void Refresh_Scale_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }

    float calculo_isobarico(float v1, float t1, float t2)
    {
        float v2 = v1 * t2 / t1;
        return v2;
    }
}