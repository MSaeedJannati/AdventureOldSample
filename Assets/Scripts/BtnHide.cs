using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnHide : MonoBehaviour {
    public Button btn = null;
	// Use this for initialization
	void Start () {
        btn.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    { 
    if(other.gameObject.tag=="Player")
    {
        btn.gameObject.SetActive(true);
    }
    
    }
    void OnTriggerExit(Collider other)
    {
        btn.gameObject.SetActive(false);
    }
}
