using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatSetTest : MonoBehaviour {

    
    public Color color;

    private MeshRenderer mr;
    private Color startColor;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        startColor = mr.sharedMaterial.GetColor("_Color");
    }

    void Update()
    {
        mr.sharedMaterial.SetColor("_Color", color);
    }

    private void OnDisable()
    {
        //if you don't do this, color set during play will stay
        //yes, even after I warned you about things set in play not staying!
        mr.sharedMaterial.SetColor("_Color", startColor);
    }
}
