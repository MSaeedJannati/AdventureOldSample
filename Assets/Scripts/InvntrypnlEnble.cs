using UnityEngine;
using System.Collections;

public class InvntrypnlEnble : MonoBehaviour {
    public bool flag = true;
	// Use this for initialization
	void Start () {
	
	}
    void awake()
    {
        
    }
	// Update is called once per frame
	void Update () {
        if(flag)
        {
            flag = false;
            gameObject.SetActive(false);
        }
    }
}
