using UnityEngine;
using System.Collections;

public class CryMngr : MonoBehaviour
{
    #region Vriables
    public Animator cryAnmtr;
    public Transform[] chkPonts;
    public Transform plyr;
    public Transform nstTrnsfrm;
    public float attckCD=4f;
    public int Dmg=20;
    public int Hlth=100;
    public Transform dest;
    public float TahdidDstnc = 10f;
    public float fleeDstnc = 30f;
    public float maxDstncTNest = 60f;
    public float dstTChckpnt = 3f;
    public float attckRng = 4f;
    public float timeInterval=0;
    public UnityEngine.AI.NavMeshAgent cryNvmsh;
    public float runSpeed = 3f;
    public float walkSpeed = 1f;
    #endregion
    void Start()
    { 
    dest=chkPonts[Random.Range(0,chkPonts.Length)];
        timeInterval=0;
        cryNvmsh.speed = 0;
    }
    //mige dest player bashe ya random az check pointa age player bashe check mikone ta nest o flee ham fasele ok bashe bad true mide
    bool ChckDstncTplyr()
    {
        
        if (Vector3.Distance(transform.position, plyr.position) <= TahdidDstnc)
        {
            return true;
        }
        else return false;
    }
    void stDst()
    {
        
        if (dest == plyr && (Vector3.Distance(transform.position, dest.position) > fleeDstnc || Vector3.Distance(transform.position, nstTrnsfrm.position) > maxDstncTNest))
        {
            dest = chkPonts[Random.Range(0, chkPonts.Length)];
        }
        else if (ChckDstncTplyr() && dest != plyr )
        {
            dest = plyr;

        }
        else if(Vector3.Distance(transform.position,dest.position)<5 && dest!=plyr)
        {
            dest = chkPonts[Random.Range(0, chkPonts.Length)];
        }
        if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Halt2") || cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Meditate") || cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("SeePlayer"))
        { dest = transform; }
    
    }
    void stStte()
    {
        if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Halt2") && Time.time>timeInterval+attckCD)
        {
            cryAnmtr.SetBool("Flag",false);
            
            
        }
        if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Meditate"))
        {
            if (ChckDstncTplyr())
            {
                
                cryAnmtr.SetInteger("State",5);
                
                dest = plyr;
            }
        }
        if(dest==plyr && Vector3.Distance(transform.position,plyr.position)<attckRng)
        {
            if (Time.time >= timeInterval + attckCD)
            {
                cryAnmtr.SetInteger("State", 4);
                timeInterval = Time.time;

            }
            else if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            {
                cryAnmtr.SetBool("Flag",true);
                cryAnmtr.SetInteger("State",2);
            }
        }
        if (dest == plyr && Vector3.Distance(transform.position, plyr.position) > attckRng && !cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Meditate"))
        {
            cryAnmtr.SetInteger("State", 2);
            if(cryAnmtr.GetBool("Flag"))
            {
                cryAnmtr.SetBool("Flag",false);
            }
        }
        if(dest !=plyr )
        {
            cryAnmtr.SetInteger("State",3);
        }
    
    }
    void stSpeed()
    {
        if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Walk") || cryAnmtr.GetInteger("State")==3)
        {
            cryNvmsh.speed=walkSpeed;
        }
         if (cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            cryNvmsh.speed = runSpeed;
        }
         if (!(cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run")) && !(cryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Walk")))
        {
            cryNvmsh.speed = 0;
           
        }
       
    }
	
	void FixedUpdate () {
        stDst();
        stStte();
        stSpeed();
        cryNvmsh.SetDestination(dest.position);
        gameObject.transform.LookAt(dest.position);
	}
}
