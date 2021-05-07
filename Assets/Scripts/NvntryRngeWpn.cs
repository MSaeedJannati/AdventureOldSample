using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NvntryRngeWpn :NewVentoryItm
{
    #region variables
    public int Dmg = 60;
    public int ammo = 0;
    public GameObject wpnPrfb = null;
    public GameObject rghtHndrng = null;
    #endregion
    // Use this for initialization
	void Awake() {
        useAble = false;
        equipAble = true;
        cntTxt.GetComponent<Text>().text = ItmCount.ToString();
        
	}

   public void Equip()
    {
        NewVentoryManeger.Instance.PostNotification(EVENT_TYPE.WpnRng_EQUIP,this);
    }

 
   
}
