using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    #region Variables
    public Slider Objslider=null;
    public Image Fill=null;
    public Color col=Color.white;
    public HlthCr objHealthCare=null;
   // public GameObject plyr = null;
     
    #endregion
    // Use this for initialization
	void Start () {
      //  objHealthCare = plyr.GetComponent<HlthCr>();
	}
	
	// Update is called once per frame
	void Update () {
        Objslider.value = Mathf.Clamp01 (objHealthCare.health / 100f);
        col.b = 0;
        col.g = Mathf.Clamp01(Objslider.value);
        col.r = Mathf.Clamp01(1-Objslider.value);
        col.a = 1;
        
        Fill.color = col;
	}
}
