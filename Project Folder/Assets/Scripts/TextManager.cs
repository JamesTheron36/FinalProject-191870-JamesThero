using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameObject superEff;
    public GameObject critHit;

    public GameObject pWin;
    public GameObject oWin;
    public PlayerManager pm;

    public Text lvl;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //int nextLevel = pm.NextLvl();
        lvl.text = "Level " + PlayerManager.lvl.ToString();
        //nextExp.text = PlayerManager.exp.ToString() + " / " + nextLevel.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuperEffective()
    {
        superEff.SetActive(true);
        StartCoroutine(SuperEffDelay());
    }
    public void Crit()
    {
        critHit.SetActive(true);
        StartCoroutine(CritDelay());
    }


    public void SetLvl()
    {
        int Lvl = pm.GetLvl();
        lvl.text = "Level " + Lvl.ToString();
    }
    public void PlayerWins()
    {
        pWin.SetActive(true);
        StartCoroutine(PlayerWinDelay());
    }
    public void OppWins()
    {
        oWin.SetActive(true);
        StartCoroutine(OppWinDelay());
    }
    IEnumerator PlayerWinDelay()
    {
        yield return new WaitForSeconds(1.5f);
        pWin.SetActive(false);
    }
    IEnumerator OppWinDelay()
    {
        yield return new WaitForSeconds(1.5f);
        oWin.SetActive(false);
    }
    IEnumerator SuperEffDelay()
    {
        yield return new WaitForSeconds(1.5f);
        superEff.SetActive(false);
    }
    IEnumerator CritDelay()
    {
        yield return new WaitForSeconds(1.5f);
        critHit.SetActive(false);
    }
}
