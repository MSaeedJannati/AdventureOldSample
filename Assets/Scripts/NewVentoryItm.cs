using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewVentoryItm : MonoBehaviour
{
    #region Variables
    public string ItmName = string.Empty;
    public GameObject ItmPrFb = null;
    public Image itmAvatar = null;
    public int price = 0;
    public _Itm_Kind ItmKind = new _Itm_Kind();
    public bool useAble = false;
    public bool equipAble = false;
    public int ItmCount = 1;
    public GameObject cntTxt = null;
    #endregion
    public enum _Itm_Kind { Ammo = 0, Potion = 1, Sword = 2, Key = 3, Junk = 4, pstl = 5, trch = 6, gold = 7 };
    public void ItmSlct(NewVentoryItm itm)
    {
        NewVentory.Instance.SlctItm(itm);
    }

    void Awake()
    {
        cntTxt.GetComponent<Text>().text = ItmCount.ToString();
    }
    public void AddCount(int a)
    {
        ItmCount += a;
        cntTxt.GetComponent<Text>().text = ItmCount.ToString();
    }
}
