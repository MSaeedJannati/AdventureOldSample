using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItensInChest : MonoBehaviour
{

    #region varibles
    public NewVentoryItm[] itms = null;
   
    public Animator SndghAnmtr = null;
    public Button btn = null;
    #endregion
    // Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void pshd()
    {
        if (itms.Length > 0)
            NewVentory.Instance.AddNewItem(itms);
        SndghAnmtr.SetBool("flag",true);
        btn.interactable = false;

    }
}
