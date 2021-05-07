using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Potion : InventoryItem
{
    #region Variables
    public int healthRestore = 50;
    public GameObject plyr;
    #endregion
    // Use this for initialization
	void Start () {
        _itmKind = itmKind.Potion;
        useable = true;
        equipable = false;
        plyr = GameObject.FindGameObjectWithTag("Player");
        Content = GameObject.Find("Content");
        itmImg.GetComponent<Button>().targetGraphic = itmPhoto;
	}
    public void Use()
    {
        plyr.GetComponent<HealthCare>().health = Mathf.Clamp(plyr.GetComponent<HealthCare>().health + healthRestore,0,100);
        Content.GetComponent<Inventory>().RmvObjct();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
