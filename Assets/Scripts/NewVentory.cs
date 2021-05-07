using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class NewVentory : MonoBehaviour
{

    #region Variables
   // public Dictionary<GameObject, int> ItmCounts = new Dictionary<GameObject, int>();
    public GameObject EquipedItm = null;
    public GameObject SlctdItm = null;
    public GameObject ScrVwCntnt = null;
    public static int gold = 0;
    public static int ammo = 0;
    public int potions = 0;
    public  GameObject goldTxt =null;
    public  GameObject ammoTxt = null;
    public GameObject potionTxt = null;
   // public List<GameObject> ItmsLst = new List<GameObject>();
    private static NewVentory instance = null;
    #endregion
    #region Properties
    public static NewVentory Instance
    {
        get { return instance; }
        set { }
    }
   
    #endregion
    #region Methods
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
        else
        {
            GameObject.DestroyImmediate(this);
        }

    }
    void Start()
    {
        ammoChng();
        gldChng();
        gold = 0;
        ammo = 0;
        //potionTxt.GetComponent<Text>().text = string.Format("Potion:{0}", potions.ToString());
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnRng_EQUIP,RngEquip);
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.WpnMlee_EQUIP,MleeEquip);
    }

    private void MleeEquip(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
        EquipItm(Sender.gameObject.GetComponent<NewVentoryItm>());
    }

    private void RngEquip(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {
       EquipItm( Sender.gameObject.GetComponent<NewVentoryItm>());
    }

    public void ammoChng()
    { 
        ammoTxt.GetComponent<Text>().text = string.Format("Ammo:{0}", ammo.ToString());
     
        AmmoCountMngr.Instance.gameObject.GetComponent<Text>().text = string.Format("Ammo:{0}", ammo.ToString());
        if (ammo < 4)
        {
            AmmoCountMngr.Instance.gameObject.GetComponent<Text>().color = Color.red;
        }
        else if (AmmoCountMngr.Instance.gameObject.GetComponent<Text>().color == Color.red)
        { 
            AmmoCountMngr.Instance.gameObject.GetComponent<Text>().color = new Color32(226, 208, 168,255);
        }
    }
    public void gldChng()
    { goldTxt.GetComponent<Text>().text = string.Format("Gold:{0}", gold.ToString()); }
    public void AddNewItem(NewVentoryItm itm)
    {
        #region deleted
        /*int b = 0;
        if (ItmCounts.TryGetValue(itm.ItmPrFb, out b))
        {
            b += itm.ItmCount;
            //ItmsLst.Add((GameObject)Instantiate(itm.ItmPrFb, ScrVwCntnt.transform));
            Instantiate(itm.ItmPrFb, ScrVwCntnt.transform);
            return;
        }
        ItmCounts.Add(itm.ItmPrFb, itm.ItmCount);
        //ItmsLst.Add((GameObject)Instantiate(itm.ItmPrFb, ScrVwCntnt.transform));*/
        #endregion
        bool flag=true;
        if (itm.GetComponent<NewVentoryItm>().ItmKind == NewVentoryItm._Itm_Kind.Ammo)
        {
            ammo += itm.GetComponent<NewVentoryItm>().ItmCount;
            ammoChng();
            flag=false;
        }
        if (itm.GetComponent<NewVentoryItm>().ItmKind == NewVentoryItm._Itm_Kind.gold && flag )
        {
            gold += itm.GetComponent<NewVentoryItm>().ItmCount;
            gldChng();
            flag = false;
        }
        if(ScrVwCntnt.transform.childCount>0 && flag)
        {
            for (int i = 0; i < ScrVwCntnt.transform.childCount; i++)
            {
                if (itm.ItmKind == ScrVwCntnt.transform.GetChild(i).gameObject.GetComponent<NewVentoryItm>().ItmKind)
                 {
                     ScrVwCntnt.transform.GetChild(i).gameObject.GetComponent<NewVentoryItm>().AddCount(1);
                     flag = false; 
                    break;
                 }
            }
        }
        if(flag)
        Instantiate(itm.ItmPrFb, ScrVwCntnt.transform);
    }

   /* public void removeItem(NewVentoryItm itm)
    {
        int b = 0;
        if (ItmCounts.TryGetValue(itm.ItmPrFb, out b))
        {
            b -= 1;
            if (b <= 0)
            {
                ItmCounts.Remove(itm.ItmPrFb);
            }
        }
    }*/

    public void AddNewItem(NewVentoryItm[] itms)
    { 
     foreach(NewVentoryItm i in itms)
     {
         AddNewItem(i);
     } 
    }

    public void SlctItm(NewVentoryItm itm)
    {
        if (SlctdItm.transform.childCount > 0)
        {
            GameObject.DestroyImmediate(SlctdItm.transform.GetChild(0).transform.gameObject);

        }
        GameObject c=(GameObject)Instantiate(itm.ItmPrFb, SlctdItm.transform, false);
        c.GetComponent<Button>().interactable = false;
    }

    public void EquipItm(NewVentoryItm itm)
    {
        if (EquipedItm.transform.childCount > 0)
        {
            GameObject.DestroyImmediate(EquipedItm.transform.GetChild(0).transform.gameObject);
            NewVentoryManeger.Instance.PostNotification(EVENT_TYPE.Wpn_REMOVE,this);

        }
        GameObject c = (GameObject)Instantiate(itm.ItmPrFb, EquipedItm.transform, false);
        c.GetComponent<Button>().interactable = false;
    }

    public void RmvPshd()
    {
        if (SlctdItm.transform.childCount == 0)
        {
            return;
        }
        GameObject obj = SlctdItm.transform.GetChild(0).gameObject;
        
        #region Remove Equiped
        if (EquipedItm.transform.childCount>0)
        {
            NewVentoryManeger.Instance.PostNotification(EVENT_TYPE.Wpn_REMOVE, this);
        if (SlctdItm.transform.GetChild(0).gameObject.GetComponent<NewVentoryItm>().ItmKind == EquipedItm.transform.GetChild(0).gameObject.GetComponent<NewVentoryItm>().ItmKind)
        {
            DestroyImmediate(EquipedItm.transform.GetChild(0).gameObject);
        }
        }
        #endregion
        #region Remove Selected
        for (int i = 0; i < ScrVwCntnt.transform.childCount;i++ )
        {
            if (ScrVwCntnt.transform.GetChild(i).gameObject.GetComponent<NewVentoryItm>().ItmKind == obj.GetComponent<NewVentoryItm>().ItmKind)
            {
                if (ScrVwCntnt.transform.GetChild(i).gameObject.GetComponent<NewVentoryItm>().ItmCount == 1)
                {
                    DestroyImmediate(ScrVwCntnt.transform.GetChild(i).gameObject);
                    DestroyImmediate(SlctdItm.transform.GetChild(0).gameObject);
                    
                    return;
                }
                else
                {
                    ScrVwCntnt.transform.GetChild(i).gameObject.GetComponent<NewVentoryItm>().AddCount(-1);
                    SlctdItm.transform.GetChild(0).gameObject.GetComponent<NewVentoryItm>().AddCount(-1);
                }
            }
        }
        #endregion
    }

    public void Use()
    {
       
    }
   
    public void UseEqiupPsd()
    {
        if (SlctdItm.transform.childCount == 0)
            return;
        GameObject a = SlctdItm.transform.GetChild(0).gameObject;
        #region Usable
        if(a.GetComponent<NewVentoryItm>().useAble)
        {
        if (a.GetComponent<HlthPtnNvntry>())
        {
            a.GetComponent<HlthPtnNvntry>().Use();
            return;
        }
        //Use(a.GetComponent<NewVentoryItm>());
        }
        #endregion
        #region EquipAble
        if(a.GetComponent<NewVentoryItm>().equipAble)
        {
            if (a.GetComponent<NvntryRngeWpn>())
            {
                a.GetComponent<NvntryRngeWpn>().Equip();
            }
            else if (a.GetComponent<NvntryMlWpn>())
            {
                a.GetComponent<NvntryMlWpn>().Equip();
            }

        }
        #endregion
    }
    #endregion

}
