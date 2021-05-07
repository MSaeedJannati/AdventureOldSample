using UnityEngine;
using System.Collections;

public class UseEquipScript : MonoBehaviour
{

    #region Variables
    public GameObject slctdPnl;
    //public GameObject eqpdPnl;
    //GameObject eqpdItm = null;
    GameObject slctdItm = null;
    public GameObject rghtHand = null;
    #endregion
    void Start()
    {
        slctdItm = null;
    }
    public void pshd()
    { 
    if(slctdPnl.transform.childCount==1)
    {
        slctdItm = slctdPnl.transform.GetChild(0).gameObject;
   
    if (slctdItm.GetComponent<InventoryItem>().useable)
    { 
     if(slctdItm.GetComponent<InventoryItem>()._itmKind==InventoryItem.itmKind.Potion)
     {
         slctdItm.GetComponent<Potion>().Use();
     }
    }
    if (slctdItm !=null && slctdItm.GetComponent<InventoryItem>().equipable)
    {
        slctdItm.GetComponent<EquipAble>().Equip();
    }
    }
    }

}
