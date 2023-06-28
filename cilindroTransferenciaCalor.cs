using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cilindroTransferenciaCalor : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetDisable(bool controle){
        gameObject.SetActive(controle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
