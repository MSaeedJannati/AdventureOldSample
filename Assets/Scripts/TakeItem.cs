using UnityEngine;
using System.Collections;

public class TakeItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void took()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
