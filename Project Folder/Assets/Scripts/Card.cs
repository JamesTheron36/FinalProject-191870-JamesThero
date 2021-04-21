using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public enum Primary
    {
        rock = 1,
        paper = 2,
        scissors = 3
    }
    public enum Secondary
    {
        fire = 1,
        ice = 2,
        water = 3,
        dragon = 4,
        earth = 5
    }
    [SerializeField]
    SpriteRenderer background;
    [SerializeField]
    SpriteRenderer image;
    [SerializeField]
    SpriteRenderer flipped;

    public Primary primary;
    public Secondary secondary;
    //public int cardID;
    [SerializeField] Sprite earthBack;
    [SerializeField] Sprite fireBack;
    [SerializeField] Sprite waterBack;
    [SerializeField] Sprite dragonBack;
    [SerializeField] Sprite iceBack;

    [SerializeField] Sprite earthFlip;
    [SerializeField] Sprite fireFlip;
    [SerializeField] Sprite waterFlip;
    [SerializeField] Sprite dragonFlip;
    [SerializeField] Sprite iceFlip;



    [SerializeField] Sprite rockImage;
    [SerializeField] Sprite sciImage;
    [SerializeField] Sprite paperImage;




    public bool played = false;
    public bool oppCard = false;
    int primaryCode;
    int secondaryCode;

    // Start is called before the first frame update
    void Start()
    {
        PrimaryImageIni();
        BackgroundIni();
        FlippedIni();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void PlayCardPlayer()
    {
        float startTime = Time.time;

        // Calculate the journey length.
        //float journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        
    }
    void PrimaryImageIni()
    {
        if(primary == Primary.rock)
        {
            image.sprite = rockImage;
            primaryCode = 1;
            
        }
        else if(primary == Primary.paper)
        {
            image.sprite = paperImage;
            primaryCode = 2;
        }
        else if(primary == Primary.scissors)
        {
            image.sprite = sciImage;
            primaryCode = 3;
        }       
    }

    void BackgroundIni()
    {
        FlippedIni();
        int num = (int)secondary;
        switch (num)
        {
            case 1:
                background.sprite = fireBack;
                secondaryCode = 1;
                break;
            case 2:
                background.sprite = iceBack;
                secondaryCode = 2;
                break;
            case 3:
                background.sprite = waterBack;
                secondaryCode = 3;
                break;
            case 4:
                background.sprite = dragonBack;
                secondaryCode = 4;
                break;
            case 5:
                background.sprite = earthBack;
                secondaryCode = 5;
                break;

        }
    }
    public void FlippedIni()
    {
        if (secondary == Secondary.fire)
        {

            flipped.sprite = fireFlip;
        }
        else if (secondary == Secondary.water)
        {
            flipped.sprite = waterFlip;
        }
        else if (secondary == Secondary.ice)
        {
            flipped.sprite = iceFlip;
        }
        else if (secondary == Secondary.earth)
        {
            flipped.sprite = earthFlip;
        }
        else if (secondary == Secondary.dragon)
        {
            flipped.sprite = dragonFlip;
        }
    }

    public int getPrimaryCode()
    {
        return primaryCode;
    }

    public int getSecondaryCode()
    {
        return secondaryCode;
    }

    public void ShowCard()
    {
        background.enabled = true;
        image.enabled = true;
        flipped.enabled = false;
    }
    public void HideCard()
    {
        background.enabled = false;
        image.enabled = false;
        flipped.enabled = true;
    }

    public bool CounterSecondary(Card def)
    {
        int n = (int)secondary;
        bool b = false;
        switch (n)
        {
            case 1:
                if(def.secondary == Secondary.ice || def.secondary == Secondary.earth)
                {
                    b = true;
                }
                break;
            case 2:
                if (def.secondary == Secondary.water || def.secondary == Secondary.dragon)
                {
                    b = true;
                }
                break;
            case 3:
                if (def.secondary == Secondary.fire || def.secondary == Secondary.dragon)
                {
                    b = true;
                }
                break;
            case 4:
                if (def.secondary == Secondary.fire || def.secondary == Secondary.earth)
                {
                    b = true;
                }
                break;
            case 5:
                if (def.secondary == Secondary.ice || def.secondary == Secondary.water)
                {
                    b = true;
                }
                break;

        }

        return b;
        

    }
    public bool CounterPrimary(Card c)
    {
        if(primary == Primary.rock && c.primary == Primary.scissors)
        {
            return true;
        }
        else if (primary == Primary.paper && c.primary == Primary.rock)
        {
            return true;
        }
        else if (primary == Primary.scissors && c.primary == Primary.paper)
        {
            return true;
        }

        else if(primary == c.primary)
        {
            if (CounterSecondary(c))
            {
                return true;
            }
        }
        return false;
    }
    public bool SameCard(Card c)
    {
        if(primary == c.primary && secondary == c.secondary)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Change(Card c)
    {
        primary = c.primary;
        secondary = c.secondary;
        BackgroundIni();
        PrimaryImageIni();

    }
    public void SetEqual(Card c)
    {
        primary = c.primary;
        secondary = c.secondary;

    }

    public bool Equals(Card c)
    {
        if(primary == c.primary && secondary == c.secondary)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public bool CounterPlayer(Player p)
    {
        int pType = p.GetType();
        bool ret = false;
        switch (pType)
        {
            case 1:
                if(secondary == Secondary.water || secondary == Secondary.dragon)
                {
                    ret = true;
                }
                break;
            case 2:
                if (secondary == Secondary.fire || secondary == Secondary.earth)
                {
                    ret = true;
                }
                break;
            case 3:
                if (secondary == Secondary.ice || secondary == Secondary.earth)
                {
                    ret = true;
                }
                break;
            case 4:
                if (secondary == Secondary.ice || secondary == Secondary.water)
                {
                    ret = true;
                }
                break;
            case 5:
                if (secondary == Secondary.dragon || secondary == Secondary.fire)
                {
                    ret = true;
                }
                break;
        }
        return ret;
    }
    public void Magnify()
    {
        transform.localScale = new Vector3(1.35f, 1.35f, 1);
    }
    public void DeMagnify()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }


    public void SetPosition(Transform t)
    {
        transform.position = t.position;
    }

    public void PlayCard()
    {
        background.enabled = false;
        image.enabled = false;
        flipped.enabled = false;
        played = true;
    }

    public int GetPrimaryCode()
    {
        return primaryCode;
    }
    
    public int GetSecondaryCode()
    {
        return secondaryCode;
    }
    public void Change(int pri, int sec)
    {
        switch (pri)
        {
            case 1:
                primary = Primary.rock;
                break;
            case 2:
                primary = Primary.paper;
                break;
            case 3:
                primary = Primary.scissors;
                break;
        }
        switch (sec)
        {
            case 1:
                secondary = Secondary.fire;
                break;
            case 2:
                secondary = Secondary.ice;
                break;
            case 3:
                secondary = Secondary.water;
                break;
            case 4:
                secondary = Secondary.dragon;
                break;
            case 5:
                secondary = Secondary.earth;
                break;
        }
        BackgroundIni();
        PrimaryImageIni();
    }
    public new int GetType()
    {
        return (int)secondary;
    }
}
