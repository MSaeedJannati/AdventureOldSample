using UnityEngine;
using System.Collections;

public class MleeAttack : MonoBehaviour {

    void OnTriggerEnter(Collider Other)
    {
        Debug.Log(Other.gameObject);
        if (Other.gameObject.tag == "Player" ||Other.gameObject.tag =="MainCamera" )
            return;
        if (Other.gameObject.GetComponent<HlthCr>())

        {
            Debug.Log(Other.gameObject);
            Other.gameObject.GetComponent<HlthCr>()._health -= NewVentory.Instance.EquipedItm.transform.GetChild(0).gameObject.GetComponent<NvntryMlWpn>().Dmg;
        }
    }
}
