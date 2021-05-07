using UnityEngine;
using System.Collections;

public class HlthCr : MonoBehaviour
{
    #region Variables
    public int health = 100;
    public int maxhealth = 100;
    

    #endregion
    #region Properties
    public int _health
    {
        get 
        {
            return health;
        }
        set
        {
            health =value;
            if (die(health))
            {
                GameObject.Destroy(gameObject);
            }
            else
            {
                health = Mathf.Clamp(health, 0, maxhealth);
            }

        }
    }
    #endregion
    void Awake()
    {
        maxhealth = health;
    }
    // Use this for initialization
	void Start () {
        
            
       
        
	}

 
	// Update is called once per frame
	void Update () {
	
	}
    public bool die(int a)
    {
        if (a < 0) return true;
        else return false;
    }
    
}
