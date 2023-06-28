using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudandoCor : MonoBehaviour
{
    private Renderer _myRenderer;
    public Material MaterialColor;
    // public TextMeshPro title;
    // Start is called before the first frame update
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMaterial(){
        _myRenderer.material = MaterialColor;
    }
}
