using UnityEngine;
using System.Collections;

public class PlyrHlthCre : HlthCr {

	// Use this for initialization
	void Start () {
        NewVentoryManeger.Instance.AddListener(EVENT_TYPE.POTION_USE, HlthPotionUse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void HlthPotionUse(EVENT_TYPE Event_Type, Component Sender, object param = null)
    {

        //Debug.Log(Sender.gameObject.GetComponent<HlthPtnNvntry>().Hlth);
        _health += Sender.gameObject.GetComponent<HlthPtnNvntry>().Hlth;
        NewVentory.Instance.RmvPshd();
    }
	
}
