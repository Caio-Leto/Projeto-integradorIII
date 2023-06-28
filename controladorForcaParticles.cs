using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorForcaParticles : MonoBehaviour
{
    public GameObject parent;
    public GameObject child;
    public bool a = true;
    public static bool controlador = false;
    public float _Time_For_Add;
    public bool upButton = false;
    public bool _Save_State_Up_Button; 
    public bool downButton = false;
    public bool _Save_State_Down_Button; 
    // Start is called before the first frame update
    void Start()
    {
        
        // child.;
    }

    public void controladorValue(){
        
    }

    public void Add_Force(){
        for(var i = 0; i <= 44; i++){
            if(parent.transform.GetChild(i) != null){
                parent.transform.GetChild(i).GetComponent<Water_Box_Particle>().Add_Force(1f);
            }
            
        } 
        Invoke("Refresh_Scale_For_Add", _Time_For_Add);
    }
    public void Remove_Force(){
        for(var i = 0; i <= 44; i++){
            if(parent.transform.GetChild(i) != null){
                parent.transform.GetChild(i).GetComponent<Water_Box_Particle>().Remove_Force(1f);
            }
            
        } 
        Invoke("Refresh_Scale_For_Remove", _Time_For_Add);
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
    public void Remove(bool adding)
    {
        downButton = adding;
        _Save_State_Down_Button = adding;
    }
    void Refresh_Scale_For_Remove()
    {
        downButton = _Save_State_Down_Button;
    }
    
    // Update is called once per frame
    void Update()
    { 
        if(upButton){
            Add_Force();
            upButton = false;
        }

        if(downButton){
            Remove_Force();
            downButton = false;
        }
        // parent.transform.GetChild(0).gameObject;
        controlador = a;
    }
    
}
// public void controladorValue(){
    //     foreach (Transform parent in transform) {
    //         child component = parent.GetComponent<MyComponent>();
    //         if(component != null)
    //             component.Add_Force(1f);
    // }
    //     // foreach(var myComponent in parent.GetComponentInChildren<MyComponent>()){
    //     //     myComponent.Add_Force(1f);
    //     // }
    
    // }
