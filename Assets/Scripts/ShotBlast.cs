using UnityEngine;
using System.Collections;

public class ShotBlast : MonoBehaviour
{
    #region variables
    public bool fire = false;
    public GameObject[] particles;
    #endregion
    // Use this for initialization
	void Start () {
        /*if (particles.Length > 0) 
        {
            foreach (GameObject i in particles)
            {
                i.GetComponent<ParticleSystem>().Stop();
            }
        }*/
	}
	
	// Update is called once per frame
	void Update () {
	if(fire)
    {
        foreach (GameObject i in particles)
        {
            i.GetComponent<ParticleSystem>().Play();       
        }
        fire = false;
    
    }
	}
}
