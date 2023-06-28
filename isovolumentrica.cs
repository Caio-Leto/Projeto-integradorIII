using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isovolumentrica : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshPro _pressao_txt;
    public float _pressao_value = 0;
    public float _Time_For_Add;
    public TextMeshPro _temperatura_txt;
    // public bool aquecer = false;
    public float _temperatura_value = 0;
    public bool upButton = false;
    public bool downButton = false;
    public bool _Save_State_Up_Button;
    public bool _Save_State_Down_Button;
    private mudandoCor _botao_aquecer;
    public float ControlIncrementDecrement;
    public string callAddorRemove;
    private bool rodar = true;
    // Start is called before the first frame update
    void Start()
    {
        // _botao_aquecer = GameObject.FindWithTag("Buttons").GetComponent<mudandoCor>();
    }

    void refresh_text()
    {
        // Debug.Log("chegou");
        // Debug.Log("pressão" + _pressao_value);
        // Debug.Log("ta indo: " + (_pressao_value <= 1.07257f && _pressao_value >= 1f));
        if (_pressao_value <= 1.07257f && _pressao_value >= 0.99999f)
        {
            // Debug.Log("passou");
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

            if (ControlIncrementDecrement == 1f && _pressao_value >= 1.069271f)
            {
                rodar = false;
            }
            else if (ControlIncrementDecrement == -1f && _pressao_value <= 1f)
            {
                rodar = false;
            }
            // Debug.Log(ControlIncrementDecrement);
            // Debug.Log(rodar);
            if (rodar)
            {
                _pressao_value = calculo_isovolumetrico(_pressao_value, _temperatura_value, (_temperatura_value + ControlIncrementDecrement));
                _temperatura_value += ControlIncrementDecrement;
                _pressao_txt.text = " " + _pressao_value.ToString("F") + " atm";
                _temperatura_txt.text = " " + _temperatura_value.ToString("f") + " k";
                Invoke(callAddorRemove, _Time_For_Add);
            }

        }
        // else{
        //     _botao_aquecer.SetMaterial();
        //     // Debug.Log(_botao_aquecer);
        // }
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
    public void Remove(bool adding)
    {
        downButton = adding;
        _Save_State_Down_Button = adding;
    }
    void Refresh_Scale_For_Add()
    {
        upButton = _Save_State_Up_Button;
    }
    void Refresh_Scale_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }

    float calculo_isovolumetrico(float p1, float t1, float t2)
    {
        float p2 = p1 * t2 / t1;
        return p2;
    }
}
