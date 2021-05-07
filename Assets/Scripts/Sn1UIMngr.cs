using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sn1UIMngr : MonoBehaviour
{
    #region Variables
    public bool MnFlg = false;
    public GameObject YDiedPnl=null;
    public GameObject MnPnl=null;
    public GameObject UIGrp=null;
    #endregion
    void Start()
    {
        Time.timeScale = 1;
       if(YDiedPnl !=null) YDiedPnl.SetActive(false);
        MnFlg = false;
       if(MnPnl!=null) MnPnl.SetActive(false);
    }
    public void MenuPushed()
    {
        MnFlg = !MnFlg;
        rndrMn(MnFlg);
    }
    void Update()
    {
        //rndrMn(MnFlg);
    
    }
    void rndrMn(bool flg)
    {
        if (flg)
        {
            UIGrp.SetActive(false);
            MnPnl.SetActive(true);
            Time.timeScale = 0;

        }
        else
        {
            UIGrp.SetActive(true);
            MnPnl.SetActive(false);
            Time.timeScale = 1;
        }
    
    }
    public void ExtPshd()
    {
        Application.Quit();
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void youDied()
    {
        Time.timeScale = 0;
        UIGrp.SetActive(false);
        MnPnl.SetActive(false);
        YDiedPnl.SetActive(true);

    }
}
