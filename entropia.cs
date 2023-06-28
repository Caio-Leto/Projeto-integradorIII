using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class entropia : MonoBehaviour
{
     public TextMeshPro _corpo_A_txt;
    public float _corpo_A_value = 0;
    public float _Time_For_Add;
    public TextMeshPro _corpo_B_txt;
    // public bool aquecer = false;
    public float _corpo_B_value = 0;
    public bool AquecerButton = false;
    public bool entropiaButton = false;
    public bool _Save_State_Aquecer_Button;  
    public bool _Save_State_Entropia_Button;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void refresh_text_Aquecer(){
        // if(_volume_value <= 45){
            _corpo_A_value += 1f;
            // _corpo_B_value += 1f;
            _corpo_A_txt.text = " " + _corpo_A_value + " K";
            // _corpo_B_txt.text = " " + _corpo_B_value + " K";
            Invoke("Refresh_Scale_For_Add_Aquecer", _Time_For_Add);
        // }
        // _pressao_value -= 0.4f; //0.133 p/s     
    }

    void refresh_text_Entropia(){
        
        if(_corpo_A_value != _corpo_B_value){ 
            if(_corpo_A_value != _corpo_B_value + 1f){
                _corpo_A_value -= 1f;
            }
            _corpo_B_value += 1f;
            _corpo_A_txt.text = " " + _corpo_A_value + " K";
            _corpo_B_txt.text = " " + _corpo_B_value + " K";
            Invoke("Refresh_Scale_For_Add_Entropia", _Time_For_Add);
        }
        // _pressao_value -= 0.4f; //0.133 p/s     
    }
    // Update is called once per frame
    void Update()
    {
        if(AquecerButton){
            refresh_text_Aquecer();
            AquecerButton = false;
        }
        if(entropiaButton){
            refresh_text_Entropia();
            entropiaButton = false;
        }
        
    }
    public void Add(bool adding)
    {
        AquecerButton = adding;
        _Save_State_Aquecer_Button = adding;
    }

    public void AddEntropia(bool adding)
    {
        entropiaButton = adding;
        _Save_State_Entropia_Button = adding;
    }
    void Refresh_Scale_For_Add_Aquecer()
    {
        AquecerButton = _Save_State_Aquecer_Button;
    }
    void Refresh_Scale_For_Add_Entropia()
    {
        entropiaButton = _Save_State_Entropia_Button;
    }
    
}
