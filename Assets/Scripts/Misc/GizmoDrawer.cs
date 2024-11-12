using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoDrawer : MonoBehaviour
{
    public Color gizmoColor = Color.yellow;
    
    public float gizmoSize = 0.5f;
    
    private void OnDrawGizmos()
    {
        // Set the gizmo color
        Gizmos.color = gizmoColor;
        
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
        
        // Optional: You could use DrawSphere, DrawCube, DrawWireCube, etc., instead
    }
}
