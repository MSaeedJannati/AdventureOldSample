using UnityEngine;
using System.Collections;

public class Checkpointgizmo : MonoBehaviour {
    public float radius = 5f;
    public Color clr = Color.red;
    void OnDrawGizmos()
    {
        Gizmos.color = clr;
        Gizmos.DrawSphere(gameObject.transform.position, radius);
    }
}
