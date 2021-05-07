using UnityEngine;
using System.Collections;

public class AhromDarSangi : MonoBehaviour {

    public Animator Ahrm;
    public void Pushed()
    {

        Ahrm.SetBool("Chng", !Ahrm.GetBool("Chng"));
    }
}
