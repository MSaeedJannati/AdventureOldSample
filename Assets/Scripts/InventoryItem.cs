using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    #region variables
    public string Name ;
    public GameObject itmImg;
    public  Image itmPhoto;
    public GameObject Content;
    //public GameObject prntUIObj;
    public int price=0;
    public bool equipable = false;
    public bool useable = false;
    public itmKind _itmKind = new itmKind();
    public int weight = 1;
    #endregion
    public enum itmKind { Ammo = 0, Potion = 1, Equipable = 2, Key = 3, Junk = 4, pstl = 5, trch = 6, gold = 7 };
    // Use this for initialization
	void Start () {
        Content = GameObject.Find("Content");
        itmImg.GetComponent<Button>().targetGraphic = itmPhoto;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pshd()
    {
        Content.GetComponent<Inventory>().ItmSlctd(gameObject);

    }
}
