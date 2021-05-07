using UnityEngine;
using System.Collections;

public class PstlMngr : MonoBehaviour
{
    #region Varibles
    public bool loaded=true;
    RaycastHit hit;
    public GameObject prefab=null;
    //GameObject a = null;
    public int dmg = 110;
    public string htNm = null;
    #endregion

    // Use this for initialization
	void Start () {
        hit = new RaycastHit();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Shoot()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PstlAnmtr"))
        {
            if (loaded)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Shoot");
                gameObject.GetComponentInChildren<ParticleSystem>().gameObject.transform.parent.gameObject.GetComponent<ShotBlast>().fire = true;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
                {
                    //a = (GameObject)Instantiate(prefab);
                    //a.transform.position = hit.point;
                    htNm = hit.transform.gameObject.name;
                    if (hit.transform.gameObject.GetComponent<HlthCr>())
                    {
                        hit.transform.gameObject.GetComponent<HlthCr>()._health -= dmg;
                    }
                    //hit.transform.gameObject.GetComponent<HlthCr>()._health -= dmg;
                }
 
                   
                loaded = false;
            }
            else 
            {
                if (NewVentory.ammo > 0)
                {
                    gameObject.GetComponent<Animator>().SetTrigger("Reload");
                    loaded = true;
                    NewVentory.ammo--;
                    NewVentory.Instance.ammoChng();
                }
            }
        }
    
    }
    void FixedUpdate()
    {
        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PstlAnmtr") && !loaded )
        { if(NewVentory.ammo>0)
          {
            gameObject.GetComponent<Animator>().SetTrigger("Reload");
            NewVentory.ammo--;
            NewVentory.Instance.ammoChng();
            loaded = true;
          }
        }
    }

}
