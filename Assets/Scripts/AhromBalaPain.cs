using UnityEngine;
using System.Collections;

public class AhromBalaPain : MonoBehaviour {
    public Animator[] anmtr;
    public Animator drChpAnmtr;
    public Animator drRstAnmtr;
    public bool[] chngs = { false,false,false};
    public bool khers = false;
	public void  btnPsh(int i)
    {
        
        anmtr[i].SetBool("Chng", !anmtr[i].GetBool("Chng"));

        chckOrdr();
        openDoors();
    }
    /*void Update()
    {
        for (int i = 0; i < 3;i++ )
        {
            chngs[i]=anmtr[i].GetBool("Chng");
        }
    }*/
    void allDown()
    {
        
        for (int i = 0; i < 3; i++)
        {
            anmtr[i].SetBool("Chng", false);
        }
    }
    void chckOrdr()
    {

        if (!anmtr[0].GetBool("Chng"))
        {
            if (anmtr[1].GetBool("Chng") || anmtr[2].GetBool("Chng")) allDown();
        }
        if (anmtr[1].GetBool("Chng"))
        {
            if (!anmtr[0].GetBool("Chng") || !anmtr[2].GetBool("Chng")) allDown();
        }
        /*if (anmtr[2].GetBool("Chng"))
        {
            if (!anmtr[0].GetBool("Chng") || anmtr[1].GetBool("Chng")) allDown();
        }*/
            
        
    }
    void openDoors()
    {
        int j = 0;
        for (int i = 0; i < 3;i++ )
        {
            if (anmtr[i].GetBool("Chng")) j++;
        }
        if (j == 3)
        {
            drChpAnmtr.SetTrigger ("Trig");
            drRstAnmtr.SetTrigger ("Trig");
            allDown();
        }
    }
   
}
