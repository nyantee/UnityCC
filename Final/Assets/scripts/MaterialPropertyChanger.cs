using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPropertyChanger : MonoBehaviour {

    public Color targetColor = Color.white;

    public Material material;

    private Color startColor;
    private float startMetallic;
    //public Texture targetTexture;

	// Use this for initialization
	void Start () {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        material = mr.sharedMaterial;
        startColor = material.GetColor("_Color");
        startMetallic = material.GetFloat("_Metallic");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 1)
        {
           // material.SetTexture("_MainTex", targetTexture);
            material.SetColor("_Color", targetColor);
            material.SetFloat("_Metallic", 1);
            Debug.LogWarning("Color should have changed");


        }
	}

    private void OnDisable()
    {
        material.SetColor("_Color", startColor);
        material.SetFloat("_Metallic", startMetallic);
    }
}
