using UnityEngine;
using System.Collections;

public class Sang : MonoBehaviour {
    public GameObject[] Sangs;
	
	
	// Update is called once per frame
	void FixedUpdate () {
	foreach (GameObject sang in Sangs)
    {
        sang.GetComponent<CharacterController>().Move (new Vector3(0,-10*Time.deltaTime,0));
    }
	}
}
