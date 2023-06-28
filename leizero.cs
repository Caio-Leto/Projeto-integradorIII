using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leizero : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float _Time_For_Add;
    // public bool aquecer = false;
    public float A_value = 0;
    public TextMeshPro A_txt;
    public float B_value = 0;
    public TextMeshPro B_txt;
    public float C_value = 0;
    public TextMeshPro C_txt;
    public bool AquecerButton = false;
    public bool ab_Connect = false;
    public bool bc_Connect = false;
    public bool _Save_State_Aquecer_Button;  
    public bool _Save_State_Entropia_Button;  
    public bool _Save_State_AB_Button;
    public bool _Save_State_BC_Button; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void refresh_text_Aquecer(){
        // if(_volume_value <= 45){
            A_value += 1f;
            // _corpo_B_value += 1f;
            A_txt.text = " " + A_value + " K";
            // _corpo_B_txt.text = " " + _corpo_B_value + " K";
            Invoke("Refresh_Scale_For_Add_Aquecer", _Time_For_Add);
        // }
        // _pressao_value -= 0.4f; //0.133 p/s     
    }

    void refresh_AB(){
        if(A_value > B_value){
            if(A_value != B_value){ 
                if(A_value != B_value + 1f){
                    A_value -= 1f;
                }
            }
            B_value += 1f;
        }else if(B_value > A_value){
            if(A_value != B_value){ 
                if(B_value != A_value + 1f){
                    B_value -= 1f;
                }
            }
            A_value += 1f;
        }
        A_txt.text = " " + A_value + " K";
        B_txt.text = " " + B_value + " K";
        Invoke("Refresh_Scale_For_Add_AB", _Time_For_Add);

        // _pressao_value -= 0.4f; //0.133 p/s     
    }

    void refresh_BC(){
        if(C_value > B_value){
            if(C_value != B_value){ 
                if(C_value != B_value + 1f){
                    C_value -= 1f;
                }    
            }
            B_value += 1f;
        }else if(B_value > C_value){
            if(B_value != C_value){ 
                if(B_value != C_value + 1f){
                    B_value -= 1f;
                }    
            }
            C_value += 1f;
        }        
        C_txt.text = " " + C_value + " K";
        B_txt.text = " " + B_value + " K";
        Invoke("Refresh_Scale_For_Add_BC", _Time_For_Add);
        // _pressao_value -= 0.4f; //0.133 p/s     
    }
    // Update is called once per frame
    
    void Update()
    {
        // if(AquecerButton){
        //     refresh_text_Aquecer();
        //     AquecerButton = false;
        // }
        if(ab_Connect){
            refresh_AB();
            ab_Connect = false;
        }
        if(bc_Connect){
            refresh_BC();
            bc_Connect = false;
        }
    }
    public void Add(bool adding)
    {
        AquecerButton = adding;
        _Save_State_Aquecer_Button = adding;
    }

    public void abConnect(bool adding)
    {
        ab_Connect = adding;
        _Save_State_AB_Button = adding;
    }
    public void bcConnect(bool adding)
    {
        bc_Connect = adding;
        _Save_State_BC_Button = adding;
    }
    void Refresh_Scale_For_Add_Aquecer()
    {
        AquecerButton = _Save_State_Aquecer_Button;
    }
    void Refresh_Scale_For_Add_AB()
    {
        ab_Connect = _Save_State_AB_Button;
    }
    void Refresh_Scale_For_Add_BC()
    {
        bc_Connect = _Save_State_BC_Button;
    }
    
}

