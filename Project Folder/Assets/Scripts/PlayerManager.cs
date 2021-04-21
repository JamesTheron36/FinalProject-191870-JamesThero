using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] Player player;
    public static int exp = 0;
    public static int lvl = 1;
    public static int fireBonus = 0;
    public static int iceBonus = 0;
    public static int earthBonus = 0;
    public static int draBonus = 0;
    public static int waterBonus = 0;
    public static int atkBonus = 0;
    public static int defBonus = 0;
    public static int accBonus = 0;
    public static int healthBonus = 0;
    int[] lvls = { 15, 35, 61, 91, 127 };

    [SerializeField] Image dra;
    [SerializeField] Image ice;
    [SerializeField] Image fire;
    [SerializeField] Image water;
    [SerializeField] Image earth;
    [SerializeField] Image atk;
    [SerializeField] Image def;
    [SerializeField] Image acc;

    [SerializeField] Text upDra;
    [SerializeField] Text upFire;
    [SerializeField] Text upIce;
    [SerializeField] Text upEarth;
    [SerializeField] Text upWater;

    [SerializeField] Text upAtk;
    [SerializeField] Text upDef;
    [SerializeField] Text upAcc;

    [SerializeField] GameObject txtDra;
    [SerializeField] GameObject txtFire;
    [SerializeField] GameObject txtIce;
    [SerializeField] GameObject txtEarth;
    [SerializeField] GameObject txtWater;

    [SerializeField] GameObject txtAtk;
    [SerializeField] GameObject txtDef;
    [SerializeField] GameObject txtAcc;
    [SerializeField] GameObject levelUpTxt;

    [SerializeField] GameObject statsPage;
    [SerializeField] GameObject showButton;
    [SerializeField] GameObject hideButton;
    [SerializeField] GameObject nextStage;
    // Start is called before the first frame update
    void Start()
    {
        AddBonus();
        DeactivateBonusTxt();
        HideStats();
        UpdateBars();
        nextStage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddBonus()
    {
        player.IncreaseWater(waterBonus);
        player.IncreaseFire(fireBonus);
        player.IncreaseEarth(earthBonus);
        player.IncreaseIce(iceBonus);
        player.IncreaseDra(draBonus);
        player.IncreaseAtk(atkBonus);
        player.IncreaseDef(defBonus);
        player.IncreaseAcc(atkBonus);
        
    }
    

    public void LvlUp(int fire, int ice, int water, int dra, int earth)
    {
        ShowStats();
        lvl++;
        atkBonus += 1;
        upAtk.text = "+1";
        defBonus += 1;
        upDef.text = "+1";
        accBonus += 1;
        upAcc.text = "+1";
        IncreaseTypeBonus(fire, ice, water, dra, earth);
        AddBonus();
        UpdateBars();
        ActivateBonusTxt();
        nextStage.SetActive(true);
    }
    
    public int NextLvl()
    {
        int num = lvls[lvl - 1];
        return num;
    }

    void IncreaseTypeBonus(int fire, int ice, int water, int dra, int earth)
    {
        if(player.GetType() == 1)
        {
            float fi = (float)fire / 2;
            int f = (int)fi*2;
            fireBonus += f;
            upFire.text = "+" + f.ToString();
        }
        else
        {
            float fi = (float)fire / 2;
            int f = (int)fi;
            fireBonus += f;
            upFire.text = "+" + f.ToString();
        }
        if (player.GetType() == 2)
        {
            float ic = (float)ice / 2;
            int i = (int)ic * 2;
            iceBonus += i;
            upIce.text = "+" + i.ToString();
        }
        else
        {
            float ic = (float)ice / 2;
            int i = (int)ic;
            iceBonus += i;
            upIce.text = "+" + i.ToString();
        }
        if (player.GetType() == 3)
        {
            float wat = (float)water / 2;
            int w = (int)wat*2;
            waterBonus += w;
            upWater.text = "+" + w.ToString();
        }
        else
        {
            float wat = (float)water / 2;
            int w = (int)wat;
            waterBonus += w;
            upWater.text = "+" + w.ToString();
        }
        if (player.GetType() == 4)
        {
            float dr = (float)dra / 2;
            int d = (int)dr * 2;
            draBonus += d;
            upDra.text = "+" + d.ToString();
        }
        else
        {
            float dr = (float)dra / 2;
            int d = (int)dr;
            draBonus += d;
            upDra.text = "+" + d.ToString();
        }
        if (player.GetType() == 5)
        {
            float ea = (float)earth / 2;
            int e = (int)ea * 2;
            earthBonus += e;
            upEarth.text = "+" + e.ToString();
        }
        else
        {
            float ea = (float)earth / 2;
            int e = (int)ea;
            earthBonus += e;
            upEarth.text = "+" + e.ToString();
        }
    }
    public int GetLvl()
    {
        return lvl;
    }
    public void UpdateBars()
    {
        float max = 32f;
        float dragon = (float)player.GetDra();
        float draRatio = dragon / max;
        dra.fillAmount = draRatio;
        float ear = (float)player.GetEarth();
        float earRatio = ear / max;
        earth.fillAmount = earRatio;
        float wat = (float)player.GetWater();
        float waterRatio = wat / max;
        water.fillAmount = waterRatio;
        float fir = (float) player.GetFire();
        float fireRatio = fir / max;
        fire.fillAmount = fireRatio;
        float Ice = (float) player.GetIce();
        float iceRatio = Ice / max;
        ice.fillAmount = iceRatio;
        float attack = (float) player.GetAtk();
        float atkRatio = attack / max;
        atk.fillAmount = atkRatio;
        float defence = (float) player.GetDef();
        float defRatio = defence / max;
        def.fillAmount = defRatio;
        float accuracy = (float) player.GetAcc();
        float accRatio = accuracy / max;
        Debug.Log(accRatio);
        acc.fillAmount = accRatio; 
    }
    void ActivateBonusTxt()
    {
        txtAcc.SetActive(true);
        txtAtk.SetActive(true);
        txtDra.SetActive(true);
        txtWater.SetActive(true);
        txtEarth.SetActive(true);
        txtIce.SetActive(true);
        txtFire.SetActive(true);
        txtDef.SetActive(true);

    }
    void DeactivateBonusTxt()
    {
        txtAcc.SetActive(false);
        txtAtk.SetActive(false);
        txtDra.SetActive(false);
        txtWater.SetActive(false);
        txtEarth.SetActive(false);
        txtIce.SetActive(false);
        txtFire.SetActive(false);
        txtDef.SetActive(false);
        levelUpTxt.SetActive(true);
    }

    public void ShowStats()
    {
        statsPage.SetActive(true);
        showButton.SetActive(false);
        hideButton.SetActive(true);
    }

    public void HideStats()
    {
        statsPage.SetActive(false);
        showButton.SetActive(true);
        hideButton.SetActive(false);
    }
}
