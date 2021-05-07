using UnityEngine;
using System.Collections;

public class RghtHndRngAnmtrMngr : StateMachineBehaviour {
    public GameObject obj=null;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
    void Start()
    {
        obj = GameObject.Find("RightHandRange");
    }
    void Awake()
    {
        obj = GameObject.Find("RightHandRange");
    }
    void OnStateEnter()
    {
        
        if (obj.transform.childCount>0)
        {
        if (!obj.transform.GetChild(0).gameObject.GetComponent<PstlMngr>().loaded)
        {
            obj.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Reload");
        }
        }
    }
	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
