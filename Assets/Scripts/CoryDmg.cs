using UnityEngine;
using System.Collections;

public class CoryDmg : MonoBehaviour {
    public Collider col;
    public GameObject FPChrctr;
    public GameObject ObjCanvas;
    public int cryDmg = 20;
	// Use this for initialization
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        
        
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FPChrctr.GetComponent<HlthCr>().health -= cryDmg;
            if (FPChrctr.GetComponent<HlthCr>().health < 0)
            {
                ObjCanvas.GetComponent<Sn1UIMngr>().youDied();
            }

        }
    }
}
