using UnityEngine;
using System.Collections;

public class AmmoCountMngr : MonoBehaviour
{
    #region variables
    public static AmmoCountMngr Instance = null;
    #endregion
    // Use this for initialization
	void Awake () {
        if (Instance == null)
        { Instance = this; }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
