using UnityEngine;
using System.Collections;

public class Door3Manegar : MonoBehaviour {

    public GameObject[] Atishes;
    public Animator drChpPvt;
    public Animator drRstPvt;

   
    public bool[] AtshSts = { false, false, false };
    public int fireCount = 0;
    
    public void btnPshd(int btnNom)
    {
        if (!AtshSts[btnNom])
        {
            Atishes[btnNom].SetActive(true);
            AtshSts[btnNom] = true;
            fireCountChck(btnNom);
            ChckOrdr();

        }
        
    
    }
    void fireCountChck(int btnNom)
    {
        if (btnNom == 0)
        {
            if (AtshSts[1] && AtshSts[2]) fireCount++;
        }
        if (btnNom == 1)
        {
            if (!AtshSts[0] && !AtshSts[2]) fireCount++;
        }
        if (btnNom == 2)
        {
            if (AtshSts[1] && !AtshSts[0]) fireCount++;
        }
    }
    void allDwn()
    {
        for (int i = 0; i<3;i++ )
        {
            Atishes[i].SetActive(false);
            AtshSts[i] = false;
        }
    }
    void ChckOrdr()
    {
        int flag = 0;
        for (int i = 0; i < 3; i++)
        {
            if (AtshSts[i])
            {
                flag++;
            }
        }
        if (flag==3)
        {
            if (fireCount == 3)
            {
                drChpPvt.SetTrigger("Trig");
                drRstPvt.SetTrigger("Trig");
            }
            else 
            {
                flag = 0;
                fireCount = 0;
                allDwn();
            }
        }
    }
}
