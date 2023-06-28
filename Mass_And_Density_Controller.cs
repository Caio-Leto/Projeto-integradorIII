using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Mass_And_Density_Controller : MonoBehaviour
{

    public float _Mercury_Density;
    public float _Mercury_Mass;
    public float _Mercury_Volume;

    public float _Water_Density;
    public float _Water_Mass;
    public float _Water_Volume;

    public float _Multiplier;
    public float _Water_Multiplier;
    public float _Time_For_Add;

    public float _Volum_Percent;

    public TextMeshPro _Mercury_Result;
    public TextMeshPro _Water_Result;
    public TextMeshPro _Mercury_Volume_TXT;
    public TextMeshPro _Water_Volume_TXT;

    public Transform _Water_Height;
    public Transform _Water_Volum_Scale;
    public Transform _Mercury_Height;
    public Transform _Mercury_Volum_Scale;

    public float _Water_Position_Y_Value;
    public float _Mercury_Position_Y_Value;

    public float _Water_Volum_Scale_Z_Value;
    public float _Mercury_Volum_Scale_Z_Value;

    public float _Water_Position_Y_Multiplier;
    public float _Mercury_Position_Y_Multiplier;

    private void Start()
    {

        _Mercury_Volume_TXT.text = "" + _Mercury_Volume;
        _Water_Volume_TXT.text = "" + _Water_Volume;

        _Water_Volum_Scale_Z_Value = _Water_Volum_Scale.transform.localScale.z;
        _Mercury_Volum_Scale_Z_Value = _Mercury_Volum_Scale.transform.localScale.z;


        Refresh_Mercury_Density();
        Refresh_Water_Density();
    }

    public bool upMercury = false;
    public bool downMercury = false;

    public bool upWater = false;
    public bool downWater = false;

    public bool _Save_State_Up_Mercury;
    public bool _Save_State_Down_Mercury;

    public bool _Save_State_Up_Water;
    public bool _Save_State_Down_Water;

    public void Update()
    {

        if (upMercury)
        {
            Add_Mercury_Object();
            upMercury = false;
        }

        if (downMercury)
        {
            Remove_Object();
            downMercury = false;
        }

        if (upWater)
        {
            Add_Water_Object();
            upWater = false;
        }

        if (downWater)
        {
            Remove_Water_Object();
            downWater = false;
        }

    }

    public void AddMercury(bool adding)
    {
        upMercury = adding;
        _Save_State_Up_Mercury = adding;
    }

    public void RemoveMercury(bool adding)
    {
        downMercury = adding;
        _Save_State_Down_Mercury = adding;
    }
    public void AddWater(bool adding)
    {
        upWater = adding;
        _Save_State_Up_Water = adding;
    }

    public void RemoveWater(bool adding)
    {
        downWater = adding;
        _Save_State_Down_Water = adding;
    }

    void Refresh_Mercury_Density()
    {

        _Mercury_Mass = _Mercury_Density * _Mercury_Volume;
        
        _Mercury_Height.transform.localPosition = new Vector3(transform.position.x, _Mercury_Position_Y_Value, transform.position.z);
        _Mercury_Volum_Scale.transform.localScale = new Vector3(_Mercury_Volum_Scale.transform.localScale.x, _Mercury_Volum_Scale.transform.localScale.y, _Mercury_Volum_Scale_Z_Value);
        _Mercury_Result.text = "" + _Mercury_Mass+"g";
        _Mercury_Volume_TXT.text = "" + _Mercury_Volume+"cm³";

    }

    public void Add_Mercury_Object()
    {

        if (_Mercury_Volume < 1000)
        {
            _Mercury_Volume += _Multiplier;
            _Mercury_Position_Y_Value -= _Mercury_Position_Y_Multiplier;
            _Mercury_Volum_Scale_Z_Value -= _Multiplier * _Volum_Percent;
            Refresh_Mercury_Density();
            Invoke("Refresh_Add_Mercury", _Time_For_Add);
        }

    }

    void Refresh_Add_Mercury()
    {
        upMercury = _Save_State_Up_Mercury;
    }

    public void Remove_Object()
    {

        if (_Mercury_Volume > 50)
        {
            _Mercury_Volume -= _Multiplier;
            _Mercury_Position_Y_Value += _Mercury_Position_Y_Multiplier;
            _Mercury_Volum_Scale_Z_Value += _Multiplier * _Volum_Percent;
            Refresh_Mercury_Density();
            Invoke("Refresh_Remove_Mercury", _Time_For_Add);
        }

    }

    void Refresh_Remove_Mercury()
    {
        downMercury = _Save_State_Down_Mercury;
    }

    void Refresh_Water_Density()
    {
        
        _Water_Mass = _Water_Density * _Water_Volume;
        _Water_Height.transform.localPosition = new Vector3(transform.position.x, _Water_Position_Y_Value, transform.position.z);
        _Water_Volum_Scale.transform.localScale = new Vector3(_Water_Volum_Scale.transform.localScale.x, _Water_Volum_Scale.transform.localScale.y, _Water_Volum_Scale_Z_Value);
        _Water_Result.text = "" + _Water_Mass+"g";
        _Water_Volume_TXT.text = "" + _Water_Volume+"cm³";

    }

    public void Add_Water_Object()
    {

        if (_Water_Volume < 3000)
        {
            _Water_Volume += _Water_Multiplier;
            _Water_Position_Y_Value -= _Water_Position_Y_Multiplier;
            _Water_Volum_Scale_Z_Value -= _Water_Multiplier * _Volum_Percent;
            Refresh_Water_Density();
            Invoke("Refresh_Add_Water", _Time_For_Add);
        }

    }

    void Refresh_Add_Water()
    {
        upWater = _Save_State_Up_Water;
    }

    public void Remove_Water_Object()
    {

        if (_Water_Volume > 50)
        {
            _Water_Volume -= _Water_Multiplier;
            _Water_Position_Y_Value += _Water_Position_Y_Multiplier;
            _Water_Volum_Scale_Z_Value += _Water_Multiplier * _Volum_Percent;
            Refresh_Water_Density();
            Invoke("Refresh_Remove_Water", _Time_For_Add);
        }

    }

    void Refresh_Remove_Water()
    {
        downWater = _Save_State_Down_Water;
    }


}

