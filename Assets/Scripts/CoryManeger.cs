using UnityEngine;
using System.Collections;

public class CoryManeger : MonoBehaviour
{
    
   #region Variables
    public UnityEngine.AI.NavMeshAgent coryNav;
    public Transform[] checkPoints;
    
    public int health = 200;
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public int damage = 30;
    public Transform dest;
    public float detectRange=8f;
    public float fleeRange = 20f;
    public Transform nestTransform;
    public float dstnToNest = 50f;
    public float dstnce;
    public Animator coryAnmtr;
    public float attckRange = 3f;
    public float attckCldwn = 4f;
    public float timeInterval = 0;
    public GameObject FPChrctr;
    public Transform chckpnt;
    public float fasle=4f;
    public float t;
    public float t1;
    public int s;
    
   #endregion
    void Update()
    {
        //t = (float ) coryAnmtr.GetTime();
        s = coryAnmtr.GetInteger("State");
       
    }
    void Start()
    {
        
        ChooseCheckPoint();
        dest=chckpnt;
        timeInterval = Time.time;
    }
    int rndChck()
    {
        return Random.Range(0, checkPoints.Length);
    }
    void ChooseCheckPoint()
    {
        chckpnt = checkPoints[rndChck()];
    
    }
  
    void PlayerClose()
    {
        if (Vector3.Distance(transform.position, FPChrctr.transform.position) < detectRange)
    {
        if (coryAnmtr.GetInteger("State") == 0)
        {
            coryAnmtr.SetInteger("State",5) ;
            
        }
        if (coryAnmtr.GetInteger("State") == 3)
        {
            coryAnmtr.SetInteger("State",2);
        }
        
    }
       
    }
    void Attack()
    {
        if (Time.time > timeInterval + attckCldwn)
        {
            coryAnmtr.SetInteger("State", 4);
            s = 4;

           
            timeInterval = Time.time;
        }
        else if (coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {

            coryAnmtr.SetBool("Flag",true);
            coryNav.speed = 0;
        }
        
       
    }
    public void Dest()
    {
        if (dest == FPChrctr.transform &&Vector3.Distance(transform.position,dest.position)<2 )
        {
            coryAnmtr.SetBool("Flag", true); 
        
        }
        
        else
        {
            coryAnmtr.SetBool("Flag", false);
        if (coryAnmtr.GetInteger("State") == 3)
     {
     if (Vector3.Distance(transform.position,dest.position)<fasle )
      {
        ChooseCheckPoint();
        dest=chckpnt;
      }
      if(Vector3.Distance(transform.position,FPChrctr.transform.position)<detectRange)
      {
      coryAnmtr.SetInteger("State",2);
        dest=FPChrctr.transform;
           }
     }
        if (coryAnmtr.GetInteger("State") == 2) 
     {
         
         if (Vector3.Distance(transform.position, FPChrctr.transform.position) > fleeRange || Vector3.Distance(transform.position, nestTransform.position) > dstnToNest)
         {
             coryAnmtr.SetInteger("State",3) ;
             ChooseCheckPoint();
             dest = chckpnt;
         }
         else
         {
             dest = FPChrctr.transform;
         }
     
     }
        }
    }

    void FixedUpdate () {
        if (coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Halt2") && (Vector3.Distance(transform.position, FPChrctr.transform.position) > detectRange || Time.time > timeInterval + attckCldwn))
       {
           coryAnmtr.SetBool("Flag", false);
           
       }
        if (coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            coryNav.speed = runSpeed;
        }
        if (coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            coryNav.speed = 0;
        }
        if(s==5 && coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run") )
        {
            coryAnmtr.SetInteger("State",2);
        }
        if (s == 4 && coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {
            coryAnmtr.SetInteger("State", 2);
        }
        PlayerClose();
        if (coryAnmtr.GetInteger("State") == 2 && Vector3.Distance(transform.position, FPChrctr.transform.position) < attckRange)
        {
            Attack();
        }
        if (coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Run") || coryAnmtr.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            Dest();
            if (coryAnmtr.GetInteger("State") == 2)
            {
                
                    coryNav.speed = runSpeed;
                    
                
            }
            else
            {
                coryNav.speed = walkSpeed;
            }

            coryNav.SetDestination(dest.position);
            gameObject.transform.LookAt(dest.position);
        }
        
	}
   
}
