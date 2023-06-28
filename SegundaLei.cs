using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundaLei : MonoBehaviour
{
   public float _Forca_1;
    public float _Time_For_Add;
    public float _Multiplier;

    public bool upButton = false;
    public bool downButton = false;

    public bool _Save_State_Up_Button;
    public bool _Save_State_Down_Button;

    public Transform _Pistao_Esquerda;
    // public Transform _Pistao_Direita;

    public void Update()
    {

        if (upButton)
        {
            if (_Pistao_Esquerda.transform.localPosition.y > 0.14f)
            {
                Expand_Forca_1();
                upButton = false;
            }
        }

        if (downButton)
        {
            if (_Pistao_Esquerda.transform.localPosition.y < 0.98f)
            {
                Delete_Forca_1();
                downButton = false;
            }
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

    void Expand_Forca_1()
    {

        _Pistao_Esquerda.transform.position = new Vector3(_Pistao_Esquerda.transform.position.x, _Pistao_Esquerda.transform.position.y + _Multiplier, _Pistao_Esquerda.transform.position.z);
        // _Pistao_Direita.transform.position = new Vector3(_Pistao_Direita.transform.position.x, _Pistao_Direita.transform.position.y - (_Multiplier / 6), _Pistao_Direita.transform.position.z);

        Invoke("Refresh_Forca_1_For_Add", _Time_For_Add);

    }

    void Refresh_Forca_1_For_Add()
    {
        upButton = _Save_State_Up_Button;
    }

    void Delete_Forca_1()
    {

        _Pistao_Esquerda.transform.position = new Vector3(_Pistao_Esquerda.transform.position.x, _Pistao_Esquerda.transform.position.y - _Multiplier, _Pistao_Esquerda.transform.position.z);
        // _Pistao_Direita.transform.position = new Vector3(_Pistao_Direita.transform.position.x, _Pistao_Direita.transform.position.y - (-_Multiplier / 6), _Pistao_Direita.transform.position.z);

        Invoke("Refresh_Forca_1_For_Remove", _Time_For_Add);
    }

    void Refresh_Forca_1_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }

}
