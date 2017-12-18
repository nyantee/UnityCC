using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDrawer : MonoBehaviour {

    public Vector3 vector;
    [Range(0,100)]
    public float scale = 20;
    public Color color = Color.white;


    private void OnDrawGizmos()
    {
        vector = transform.forward * scale;
        Gizmos.color = color;
        Gizmos.DrawLine(transform.position, 
            transform.position + vector);
    }
}
