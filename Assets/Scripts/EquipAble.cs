using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EquipAble : InventoryItem
{
    #region Variables
    public int dmg = 20;
    public bool meleeWeapon = false;
    public GameObject weaponPrefab=null;
    public Transform rightHandMlee=null;
    public  Transform rightHandRange=null;
    public GameObject EqpdItm=null;
    GameObject gmObjct;
    GameObject gmObjct1;
    #endregion
    // Use this for initialization
    void Start()
    {
        gmObjct = null;
        gmObjct1 = null;
        equipable = true;
        useable = false;
        _itmKind = itmKind.Equipable;
        if (Camera.main.transform.childCount > 0) 
        { 
            rightHandMlee = Camera.main.transform.Find("RightHandMlee").gameObject.transform;
            rightHandRange = Camera.main.transform.Find("RightHandRange").gameObject.transform;
        }
        Content = GameObject.Find("Content");
        itmImg.GetComponent<Button>().targetGraphic = itmPhoto;
        EqpdItm = GameObject.Find("EquipedItem");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Equip()
    {
        if (rightHandMlee.childCount > 0)
        {
            GameObject.DestroyImmediate(rightHandMlee.GetChild(0).gameObject);


        }
        else if (rightHandRange.childCount > 0)
        {
            GameObject.DestroyImmediate(rightHandRange.GetChild(0).gameObject);
        }
        if (meleeWeapon)
        {
            gmObjct1 = (GameObject)Instantiate(weaponPrefab, rightHandMlee, false);
            gmObjct1.transform.localPosition = Vector3.zero;
        }
        else
        {
            gmObjct1 = (GameObject)Instantiate(weaponPrefab, rightHandRange, false);
            gmObjct1.transform.localPosition = Vector3.zero;
        }
        if(EqpdItm.transform.childCount>0)
        {
           GameObject.DestroyImmediate( EqpdItm.transform.GetChild(0).gameObject);
        }
        gmObjct = (GameObject) Instantiate(itmImg.GetComponent<Button>().gameObject, EqpdItm.transform, false);
        gmObjct.GetComponent<Button>().interactable = false;
    }
}
