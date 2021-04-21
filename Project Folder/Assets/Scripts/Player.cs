using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public enum Type
    {
        fire = 1,
        ice = 2,
        water = 3,
        dragon = 4,
        earth = 5
        
        
    }

    [SerializeField] int dra = 1;
    [SerializeField] int ice = 1;
    [SerializeField] int fire = 1;
    [SerializeField] int earth = 1;
    [SerializeField] int water = 1;
    [SerializeField] int atk = 3;
    [SerializeField] int def = 5;
    [SerializeField] int acc = 4;
    [SerializeField] Type type;
    [SerializeField] GameObject healthBar;
    [SerializeField] GameObject healthBack;
    [SerializeField] HealthBar hb;

    public float health = 100;
    public Vector3 currHealth = new Vector3(1, 1, 1);
    public Vector3 newHealth = new Vector3(1,1,1);
    public float spd = 0.5f;
    float totalHealth;
    





    
    // Start is called before the first frame update
    void Start()
    {
        totalHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.transform.localScale = Vector3.MoveTowards(currHealth, newHealth, spd);
        if(health < 0)
        {
            healthBar.SetActive(false);
        }

        

        //healthBar.transform.localScale = Vector3.Lerp(currHealth, newHealth, spd);

        
    }
    public int GetAtk()
    {
        return atk;
    }
    public int GetDef()
    {
        return def;
    }
    public int GetAcc()
    {
        return acc;
    }
    public int GetDra()
    {
        return dra;
    }
    public int GetIce()
    {
        return ice;
    }
    public int GetFire()
    {
        return fire;
    }
    public int GetWater()
    {
        return water;
    }
    public int GetEarth()
    {
        return earth;
    }
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public bool MatchingType(Card c)
    {
        bool b = false;
        if(c.secondary == Card.Secondary.dragon && type == Type.dragon)
        {
            b = true;
        }
        else if(c.secondary == Card.Secondary.fire && type == Type.fire)
        {
            b = true;
        }
        else if (c.secondary == Card.Secondary.water && type == Type.water)
        {
            b = true;
        }
        else if (c.secondary == Card.Secondary.ice && type == Type.ice)
        {
            b = true;
        }
        else if (c.secondary == Card.Secondary.earth && type == Type.earth)
        {
            b = true;
        }
        return b;
    }
    public void UpdateHealthBar() {
        float ratio = health / totalHealth;
        Vector3 vec = new Vector3(ratio, 1, 1);

        healthBar.transform.localScale = vec;
    }

    void Flash(GameObject go, int times)
    {
        go.SetActive(false);
        StartCoroutine(FlashOn(go));
    }
    IEnumerator FlashOn(GameObject go)
    {
        yield return new WaitForSeconds(0.35f);
        go.SetActive(true);
    }
    IEnumerator FlashOff(GameObject go)
    {
        yield return new WaitForSeconds(0.2f);
        go.SetActive(false);
    }

    public void SetType(int num)
    {
        if(num == 1)
        {
            type = Type.fire;
        }
        else if(num == 2)
        {
            type = Type.ice;
        }
        else if (num == 3)
        {
            type = Type.water;
        }
        else if (num == 4)
        {
            type = Type.dragon;
        }
        else if (num == 5)
        {
            type = Type.earth;
        }
    }
    public void IncreaseAtk(int num)
    {
        atk += num;
    }
    public void IncreaseDef(int num)
    {
        def += num;
    }
    public void IncreaseAcc(int num)
    {
        acc += num;
    }
    public void IncreaseDra(int num)
    {
        dra += num;
    }
    public void IncreaseFire(int num)
    {
        fire += num;
    }
    public void IncreaseWater(int num)
    {
        water += num;
    }
    public void IncreaseEarth(int num)
    {
        earth += num;
    }
    public void IncreaseIce(int num)
    {
        ice += num;
    }
    public new int GetType()
    {
        int num = (int)type;
        return num;
    }
}
