using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forca : MonoBehaviour
{

    public Water_Box_Particle[] _Particles;

    public float _Force_Value;

    public float _Time_For_Add;

    public float _Area_Calc;
    public float _Pression;

    public float _Area_Multiplier;
    public float _F_Area_Multiplier;
    public float _Scale_X;
    public float _Scale_Y;

    public float _F_Scale = 100;

    public Transform _Force_Area;

    public bool upButton = false;
    public bool downButton = false;

    public bool _Save_State_Up_Button;
    public bool _Save_State_Down_Button;

    public TextMeshPro _Area_TXT;
    public TextMeshPro _Pression_TXT;

    public void Update()
    {

        if (upButton)
        {
            Expand_Area();
            upButton = false;
        }

        if (downButton)
        {
            Delete_Area();
            downButton = false;
        }

    }

    public void AddArea(bool adding)
    {
        upButton = adding;
        _Save_State_Up_Button = adding;
    }

    public void RemoveArea(bool adding)
    {
        downButton = adding;
        _Save_State_Down_Button = adding;
    }

    public void Expand_Area()
    {

        _Scale_X += _Area_Multiplier;
        _Scale_Y += _Area_Multiplier;
        _F_Scale += _F_Area_Multiplier;

        Refresh_Infos();

        if (_Force_Area.transform.localScale.x < 3)
        {
            _Force_Area.transform.localScale = new Vector3(_Scale_X, _Force_Area.localScale.y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.x >= 3)
        {
            _Force_Area.transform.localScale = new Vector3(3, _Force_Area.localScale.y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.y < 3)
        {
            _Force_Area.transform.localScale = new Vector3(_Force_Area.localScale.x, _Scale_Y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.y >= 3)
        {
            _Force_Area.transform.localScale = new Vector3(_Force_Area.localScale.x, 3, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.y < 3 || _Force_Area.transform.localScale.x < 3)
        {

            for (int counter = 0; counter < _Particles.Length; counter++)
            {
                _Particles[counter].Add_Force(_Force_Value);
            }

            Invoke("Refresh_Scale_For_Add", _Time_For_Add);

        }

    }

    void Refresh_Infos()
    {
        _Area_Calc = _Scale_X * _Scale_Y;
        _Area_TXT.text = "" + _F_Scale + " cm²";
        _Pression = 100 / _F_Scale;
        _Pression_TXT.text = "" + _Pression.ToString("F") + " N/cm²";

    }

    void Refresh_Scale_For_Add()
    {
        upButton = _Save_State_Up_Button;
    }

    public void Delete_Area()
    {

        _Scale_X -= _Area_Multiplier;
        _Scale_Y -= _Area_Multiplier;
        _F_Scale -= _F_Area_Multiplier;

        Refresh_Infos();

        if (_Force_Area.transform.localScale.x > 0.1f)
        {
            _Force_Area.transform.localScale = new Vector3(_Scale_X, _Force_Area.localScale.y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.x <= 0.1f)
        {
            _Force_Area.transform.localScale = new Vector3(0.1f, _Force_Area.localScale.y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.y > 0.1f)
        {
            _Force_Area.transform.localScale = new Vector3(_Force_Area.localScale.x, _Scale_Y, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.y <= 0.1f)
        {
            _Force_Area.transform.localScale = new Vector3(_Force_Area.localScale.x, 0.1f, _Force_Area.localScale.z);
        }

        if (_Force_Area.transform.localScale.x > 0.1f || _Force_Area.transform.localScale.y > 0.1f)
        {

            for (int counter = 0; counter < _Particles.Length; counter++)
            {
                _Particles[counter].Remove_Force(_Force_Value);
            }

            Invoke("Refresh_Scale_For_Remove", _Time_For_Add);

        }

    }

    void Refresh_Scale_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }

}
