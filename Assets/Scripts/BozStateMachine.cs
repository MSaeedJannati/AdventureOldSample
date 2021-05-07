using UnityEngine;
using System.Collections;

public class BozStateMachine : MonoBehaviour {
    public Transform[] CheckPoints;
    public UnityEngine.AI.NavMeshAgent bozNvmshAgnt;
    public float runSpeed=15f;
    public float walkSpeed=4f;
    public float Dstnce=10f;
    public int chckPntNm;
    public GameObject chrctr;
    public Animator bzAnmtr;
    public Transform Dest;
    public float fsle;
    public int state = 0;
    public float DetectRange = 10f;
    public float runRange = 6f;
    void Start()
    {
        chckPntNm = CheckPoints.Length;
        Dest = CheckPoints[checkPointChoose()];
    }
    int checkPointChoose()
    {
        return Random.Range(0, chckPntNm);
    }
    void dest()
    {
       
            
                Dest = CheckPoints[checkPointChoose()];
            
            
        
        
    
    }
    bool tahdidCheck()
    {
        
        fsle = Vector3.Distance(gameObject.transform.position,chrctr.transform.position);
        if(fsle<DetectRange)
        {
            if (fsle > runRange)
            {
                state = 1;

            }
            else
            {
                
                state = 3;
            
            }
            return true;
        }
        return false;
    }
    void stateChck()
    {
        if (!tahdidCheck())
        {
            if (Vector3.Distance(gameObject.transform.position, Dest.position) < 7)
            {
                state = 0;
                dest();
            }
            state = 2;

        }
        
        
    
    }
    void speedCheck()
    {
        if (state == 0 ||state == 1)
        {
            bozNvmshAgnt.speed = 0;
        }
        if (state == 2)
        {
            bozNvmshAgnt.speed = walkSpeed;
        
        }
        if (state == 3)
        {
            bozNvmshAgnt.speed = runSpeed;
        }
    }
    void FixedUpdate()
    {
        if (gameObject.transform.childCount == 0)
        {
            GameObject.DestroyImmediate(gameObject);
            GameObject.Destroy(this);
        }
        else
        {
            stateChck();
            speedCheck();
            bzAnmtr.SetInteger("State", state);
            bozNvmshAgnt.SetDestination(Dest.position);
            //bozNvmshAgnt.gameObject.transform.root.transform.LookAt(Dest.position);
            gameObject.transform.LookAt(Dest.position);
        }
    }
 
}
