using UnityEngine;
using System.Collections;

public class RightHandManeger : MonoBehaviour
{

    
    #region Variables

    public GameObject RghtHndMlee=null;
    public GameObject RghtHndRnge = null;

    #endregion
    #region methodes
    void Start()
    {
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnMlee_EQUIP,EquipMlee);
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnRng_EQUIP, EquipRng);

    }

    private void EquipMlee(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        if (RghtHndMlee.transform.childCount > 0)
       {
           for (int i = 0; i < RghtHndMlee.transform.childCount; i++)
           {
               DestroyImmediate(RghtHndMlee.transform.GetChild(i).gameObject);
           }
       }
        
        
    }
    private void EquipRng(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        if (RghtHndRnge.transform.childCount > 0)
        {
            for (int i = 0; i < RghtHndRnge.transform.childCount; i++)
            {
                DestroyImmediate(RghtHndRnge.transform.GetChild(i).gameObject);
            }
        }
    }
   
    #endregion
}
