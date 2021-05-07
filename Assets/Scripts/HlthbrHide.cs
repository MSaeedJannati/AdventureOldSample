using UnityEngine;
using System.Collections;

public class HlthbrHide : MonoBehaviour
{
    #region Variables
    public GameObject Creature = null;
    public GameObject Hlthbr = null;
    public HlthCr crtrHlth = null;
    #endregion

    #region Methodes
    // Use this for initialization
    void Start()
    {
        crtrHlth = Creature.GetComponent<HlthCr>();
        StartCoroutine(Hide());
        
    }

    public IEnumerator Hide()
    {
        while (true)
        { 
        if(crtrHlth._health<crtrHlth.maxhealth)
        {
            Hlthbr.SetActive(true);
        }
        else
        {
            Hlthbr.SetActive(false);
        }
        yield return (new WaitForSeconds(1));
        }
    }
      
    #endregion
}
