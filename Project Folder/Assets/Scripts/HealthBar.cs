using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject ice;
    public GameObject fire;
    public GameObject water;
    public GameObject dragon;
    public GameObject earth;

    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetType(int num)
    {
        if(num == 1)
        {
            ice.SetActive(false);
            fire.SetActive(true);
            dragon.SetActive(false);
            earth.SetActive(false);
            water.SetActive(false);
        }
        else if (num == 2)
        {
            ice.SetActive(true);
            fire.SetActive(false);
            dragon.SetActive(false);
            earth.SetActive(false);
            water.SetActive(false);
        }
        else if (num == 3)
        {
            ice.SetActive(false);
            fire.SetActive(false);
            dragon.SetActive(false);
            earth.SetActive(false);
            water.SetActive(true);
        }
        else if (num == 4)
        {
            ice.SetActive(false);
            fire.SetActive(false);
            dragon.SetActive(true);
            earth.SetActive(false);
            water.SetActive(false);
        }
        else if (num == 5)
        {
            ice.SetActive(false);
            fire.SetActive(false);
            dragon.SetActive(false);
            earth.SetActive(true);
            water.SetActive(false);
        }
    }

    public void BackgroundFlash()
    {
        background.SetActive(false);
        StartCoroutine(Delay());
        

    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.25f);
        background.SetActive(true);
    }

}
