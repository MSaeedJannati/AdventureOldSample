using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Scn0UIMngr : MonoBehaviour {
    public Image wtImg;
    public bool flg = false;
   
    public bool asb = false;
    void start()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        wtImg.gameObject.SetActive(false);
    }
    void awake()
    {
        
    }

   public void strtPshd()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
        
        
        asb = true;
    }
   public void ExtPshd()
    {
        Application.Quit();
    }
   void OnGUI()
   {
     
       if (asb)
       {

           if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("StartingScene"))
           {

               wtImg.gameObject.SetActive(true);
           }
       }
     
   
   }
}
