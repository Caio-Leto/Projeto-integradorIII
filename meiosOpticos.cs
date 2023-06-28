using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class meiosOpticos : MonoBehaviour
{
    public GameObject transparente;
    public GameObject translucido;
    public GameObject opaco;
    private GameObject solidoSelecionado;
    public Light luz;
    private float intensidade;

    void Start()
    {
        intensidade = luz.intensity;
        solidoSelecionado = transparente;
        solidoSelecionado.SetActive(true);
    }

    public void solidoTransparente(){
        luz.intensity = intensidade;
        solidoSelecionado.SetActive(false);
        solidoSelecionado = transparente;
        solidoSelecionado.SetActive(true);
    }

    public void solidoTranslucido(){
        solidoSelecionado.SetActive(false);
        solidoSelecionado = translucido;
        luz.intensity = 6.0f;
        solidoSelecionado.SetActive(true);
    }

    public void solidoOpaco(){
        luz.intensity = intensidade;
        solidoSelecionado.SetActive(false);
        solidoSelecionado = opaco;
        solidoSelecionado.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
