using UnityEngine;
using System.Collections;

public class LnRndrrMngr : MonoBehaviour {
    public Transform[] trnsfrms;
    public Animator[] anmtrs;
    public LineRenderer LnRendrr;
    public Animator Door;
    public Animator Almas2;
    
    public int rayPos=0;
    public int[] btnCrctPos;
    //public int[] asb= {0,0,0};
    public bool flag = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            /*for (int i = 0; i < 3; i++)
            {
                asb[i] = anmtrs[i].GetInteger("Pos");
            }*/
            if (rayPos > 0)
            {

                for (int i = 0; i <= rayPos; i++)
                {
                    LnRendrr.SetPosition(i, trnsfrms[i].position);

                }
                for (int j = rayPos + 1; j < 6; j++)
                {
                    LnRendrr.SetPosition(j, trnsfrms[rayPos].position + new Vector3(0, 0, .2f));
                }
            }
            if (rayPos == 3)
            {
                for (int i = 0; i <= rayPos + 2; i++)
                {
                    LnRendrr.SetPosition(i, trnsfrms[i].position);

                }
                Door.SetTrigger("Trig");
                Almas2.SetTrigger("Trig");
            }
        }
	
	}
    
    public void BtnPSHD()
    { int b=0;
        for (int i=0; i <=3;i++)
        {
            if (AyneCheck(i))
            {
                b = i;
            }
        }
        rayPos = b;
        
    }
    public bool AyneCheck(int Id)
    { 
    for (int i=0;i<Id;i++)
    {
        if (anmtrs[i].GetInteger("Pos") != btnCrctPos[i])
            return false;
        
    
    }
    return true;
    }
   public void SetFlag()
    {
        flag = true;
    }
}
