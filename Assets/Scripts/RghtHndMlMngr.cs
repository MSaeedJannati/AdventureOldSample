using UnityEngine;
using System.Collections;

public class RghtHndMlMngr : MonoBehaviour {
    #region variables
    GameObject a = null;
    public static GameObject b = null;
    GameObject c = null;
    GameObject d = null;
    //GameObject e = null;
    bool h = false;
    #endregion
    #region Methodes
    // Use this for initialization
	void Start () {
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnMlee_EQUIP, Equip);
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.Wpn_REMOVE, Remove);
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnRng_EQUIP, EquipRnge);
	}

    private void EquipRnge(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        if(gameObject.transform.childCount>0)
        {
            DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
        }
    }

    private void Remove(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        if(((NewVentory)Sender).EquipedItm.transform.childCount>0)
         {
          c = ((NewVentory)Sender).EquipedItm.transform.GetChild(0).gameObject; ;
          d = ((NewVentory)Sender).SlctdItm.transform.GetChild(0).gameObject;
          h = (c.GetComponent<NewVentoryItm>().ItmKind == d.GetComponent<NewVentoryItm>().ItmKind);
          if (b && h)
          { DestroyImmediate(b); }
        }
    }
    private void Equip(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        a = Sender.gameObject;
        b = (GameObject)Instantiate(a.GetComponent<NvntryMlWpn>().wpnPrfb, gameObject.transform, false);
        b.transform.localPosition = Vector3.zero;
    }
   
    #endregion

}
