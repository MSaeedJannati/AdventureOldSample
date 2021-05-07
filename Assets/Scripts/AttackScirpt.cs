using UnityEngine;
using System.Collections;

public class AttackScirpt : MonoBehaviour
{

    #region Methodes

    public void Attack()
    {
        if (RghtHndMlMngr.b)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Trig");
        }
    }
    public void AttackRange()
    {
        if (RghtHndRngMngr.b)
        {
            
            RghtHndRngMngr.b.GetComponent<PstlMngr>().Shoot();
        }
    }

    #endregion
}
