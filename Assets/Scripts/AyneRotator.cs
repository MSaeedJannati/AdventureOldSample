using UnityEngine;
using System.Collections;

public class AyneRotator : MonoBehaviour {
    public Animator AyneAnmtr;
    int Pos = 0;
    public void btnPush()
    {
        Pos = AyneAnmtr.GetInteger("Pos");
        Pos++;
        if (Pos > 3)
        {
            Pos = 1;
        }
        AyneAnmtr.SetInteger("Pos",Pos);
    }

}
