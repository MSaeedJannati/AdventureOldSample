using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NvntryMlWpn : NewVentoryItm {
    #region variables
    public int Dmg = 60;
    
    public GameObject wpnPrfb = null;
    
    #endregion
    #region Methodes
    // Use this for initialization
	void Start () {
        useAble = false;
        equipAble = true;
        cntTxt.GetComponent<Text>().text = ItmCount.ToString();
	}
    public void Equip()
    {
        NewVentoryManeger.Instance.PostNotification(EVENT_TYPE.WpnMlee_EQUIP, this);
    }
    #endregion
}
