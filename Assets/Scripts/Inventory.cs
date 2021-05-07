using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{

    
    #region Variables
    
    public ArrayList Itms=new ArrayList();
    
    public float itmHeight = 30f;
    public float itmWdth = 30f;
    public float fsleItms = 8;
    public  GameObject slctdPnl = null;
    public GameObject eqpdPnl = null;
    public GameObject rghtHndMlee = null;
    public GameObject rghtHndRange = null;
    public GameObject UseBtn = null;
    GameObject SlctdItmInList,SlctdItmInSlctPnl;

   
    #endregion
    void Awake()
    {
        SlctdItmInList = null;
        SlctdItmInSlctPnl = null;
         
        
        slctdPnl = GameObject.FindGameObjectWithTag("slctdPnl");
    }
    public void AddItm(InventoryItem itm)
    {
       /* bool flag = false;
       
      
       for(int i=0;i<Itms.Count;i++)
       {
           if(Itms[i]==null )
           {
               Itms[i] = (GameObject)Instantiate(itm.itmImg, (-new Vector3(-100, 50 + (i) * (itmHeight + fsleItms), 0)) + transform.position, Quaternion.identity, transform);
               flag = true;
               return;
           }
         }
       if (!flag)
       {
           Itms.Add((GameObject)Instantiate(itm.itmImg, (-new Vector3(-100, 50 + (Itms.Count) * (itmHeight + fsleItms), 0)) + transform.position, Quaternion.identity, transform));
           
       }*/
        
        Itms.Add((GameObject)Instantiate(itm.itmImg, (-new Vector3(-100, 50 + (Itms.Count) * (itmHeight + fsleItms), 0)) + transform.position, Quaternion.identity, transform));
        

    
    }
  
    public void AddItm(InventoryItem[] itms)
    {
        for (int i = 0; i < itms.Length;i++ )
        {
            Itms.Add((GameObject)Instantiate(itms[i].itmImg, (-new Vector3(-100, 50 + (Itms.Count) * (itmHeight + fsleItms), 0)) + transform.position, Quaternion.identity, transform));
        }
    }

   public void RmvObjct()
   {
       
       if (!SlctdItmInSlctPnl) { return; }
       if (eqpdPnl.transform.childCount == 1 )
       {
           if (SlctdItmInSlctPnl.GetComponent<EquipAble>())
           {
           if (eqpdPnl.transform.GetChild(0).gameObject.GetComponent<EquipAble>().weaponPrefab == SlctdItmInSlctPnl.GetComponent<EquipAble>().weaponPrefab)
           {
               DestroyImmediate(eqpdPnl.transform.GetChild(0).gameObject);
               if (rghtHndMlee.transform.childCount > 0)
               {
                   DestroyImmediate(rghtHndMlee.transform.GetChild(0).gameObject);
               }
               else if (rghtHndRange.transform.childCount > 0)
               {
                   DestroyImmediate(rghtHndRange.transform.GetChild(0).gameObject);
               }
           }
           }
       
       }
       int rty=Itms.IndexOf(SlctdItmInList);
       Itms[rty] = null;
       
       GameObject.DestroyImmediate(SlctdItmInList);
       GameObject.DestroyImmediate(SlctdItmInSlctPnl);
       
      
   
   }
   public void ItmSlctd(GameObject obj)
   {
      SlctdItmInList = obj;
       
       //SlctdItmInList = obj.GetComponent<InventoryItem>().itmImg;
       //SlctdItmInList.transform.SetParent(slctdPnl.transform, false);
       if(slctdPnl.transform.childCount ==1  ){GameObject.DestroyImmediate(slctdPnl.transform.GetChild(0).gameObject);}
       SlctdItmInSlctPnl = (GameObject)Instantiate(obj, slctdPnl.transform, false);
       //SlctdItmInSlctPnl = (GameObject)Instantiate(SlctdItmInList, slctdPnl.transform, false);
       //SlctdItmInSlctPnl= (GameObject)Instantiate(obj.gameObject.GetComponent<InventoryItem>().itmImg.gameObject, slctdPnl.transform, false);
       SlctdItmInSlctPnl.transform.localPosition = Vector3.zero;
       SlctdItmInSlctPnl.GetComponent<Button>().interactable = false;
       if (!obj.GetComponent<InventoryItem>().useable && !obj.GetComponent<InventoryItem>().equipable)
       {
           UseBtn.GetComponent<Button>().interactable = false;
       }
       else
       {
           UseBtn.GetComponent<Button>().interactable = true;
       }


   }

   

}
