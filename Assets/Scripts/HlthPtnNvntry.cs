using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HlthPtnNvntry : UseAbleNVntry
{
    #region Varibales
    public int Hlth = 50;
    #endregion

    // Use this for initialization
	void Start () {
        ItmKind = _Itm_Kind.Potion;
        cntTxt.GetComponent<Text>().text = ItmCount.ToString();
	}
    
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Use()
    {
        NewVentoryManeger.Instance.PostNotification(EVENT_TYPE.POTION_USE,this);
    }
}
