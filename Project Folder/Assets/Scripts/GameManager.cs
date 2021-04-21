using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Card[] playerDeck = new Card[8];
    [SerializeField] Card[] oppDeck = new Card[8];

    [SerializeField] MenuManager mm;

    [SerializeField] Card activeCardPlayer;
    
    [SerializeField] Card activeCardOpponent;

    [SerializeField] Card Temp;

    [SerializeField] Transform[] handCardsPos = new Transform[4];
    
    [SerializeField] Transform[] oppHandPos = new Transform[4];

    [SerializeField] Card[] handCards = new Card[4];
    [SerializeField] Card[] oppCards = new Card[4];

    public Transform deckPos, deckOppPos;
    [SerializeField] SoundManager sm;
    public TextManager tm;

    //[SerializeField]
    public Transform playerPlayedPos;
    //[SerializeField]
    public Transform oppPlayedPos;

    bool played = false;
    
    [SerializeField] Player player;
    [SerializeField] Player opp;

    [SerializeField] PlayerManager pm;



    [SerializeField] float critMod = 0.5f;
    [SerializeField] float atkFractionMod = 0.3f;
    [SerializeField] float defFractionMod = 0.3f;
    [SerializeField] float nerfDefense = 0.2f;
    [SerializeField] float typeFractionMod = 0.3f;
    [SerializeField] float nerfType = 0.35f;
    [SerializeField] float counterMod = 0.4f;

    public SpriteRenderer oppWins;
    public SpriteRenderer youWin;

    bool finished = false;
    int oppTypeIndex;

    
    
    public HealthBar playerHB;
    public HealthBar oppHB;
    bool hovering = false;
    int roundCount = 0;
    [SerializeField] int stage = 1;

    int[] playerNextHand = new int[4];
    int[] oppNextHand = new int[4];
    int set;
    public int[] typeScores = { 1, 1, 1, 1, 1 };
    bool levelUp;
    //int time = 0;
    //public GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        levelUp = false;
        DeckIni();
        set = 0;
        SetHandPositions();
        InstantiateHand();
        InstantiateOpponentCards();
        youWin.enabled = false;
        oppWins.enabled = false;
        int t = TypeMenu.type;
        player.SetType(t);
        playerHB.SetType(t);
        
        switch (stage)
        {
            case 1:
                opp.SetType(1);
                oppHB.SetType(1);
                break;
            case 2:
                opp.SetType(4);
                oppHB.SetType(4);
                break;
            case 3:
                opp.SetType(5);
                oppHB.SetType(5);
                break;

        }
        
        roundCount = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            opp.health = 0;
        }
        //time += time.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(roundCount == 4)
        {
            set++;
            if(set%2 == 1)
            {
                InsantiateNextHand();
                roundCount = 0;
                ReversePlayed();
            }
            else
            {
                InstantiateHand();
                InstantiateOpponentCards();
                roundCount = 0;
                ReversePlayed();
            }
            
        }
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.name == "Card Place Holder 1" && !handCards[0].played && !hovering)
            {
                sm.PlayClick();
                hovering = true;
            }
            if (hit.transform.name == "Card Place Holder 2" && !handCards[1].played && !hovering)
            {
                sm.PlayClick();
                hovering = true;
            }
            if (hit.transform.name == "Card Place Holder 3" && !handCards[2].played && !hovering)
            {
                sm.PlayClick();
                hovering = true;
            }
            if (hit.transform.name == "Card Place Holder 4" && !handCards[3].played && !hovering)
            {
                sm.PlayClick();
                hovering = true;
            }


            if (hit.transform.name == "Card Place Holder 1" && !handCards[0].played)
            {
                
                //Debug.Log("hit");
                handCards[0].Magnify();
                if (Input.GetMouseButtonDown(0) && played == false && finished == false )
                {
                    
                    
                    //handCards[0].Magnify();
                    handCards[0].PlayCard();
                    activeCardPlayer.Change(handCards[0]);
                    activeCardPlayer.ShowCard();
                    played = true;
                    roundCount++;
                    Debug.Log("hit");
                    
                    switch (stage)
                    {
                        case 1:
                            Opponent1();
                            break;
                        case 2:
                            Opponent2();
                            break;
                        case 3:
                            Opponent3();
                            break;
                    }
                    activeCardOpponent.ShowCard();
                }

            }
            else
            {
                handCards[0].DeMagnify();
                
            }
            

            if (hit.transform.name == "Card Place Holder 2" && !handCards[1].played)
            {

                
                handCards[1].Magnify();
                if (Input.GetMouseButtonDown(0) && played == false && finished == false)
                {
                    
                    
                    handCards[1].PlayCard();
                    activeCardPlayer.Change(handCards[1]);
                    activeCardPlayer.ShowCard();
                    played = true;
                    roundCount++;
                    //Debug.Log("hit");
                    activeCardOpponent.ShowCard();
                    switch (stage)
                    {
                        case 1:
                            Opponent1();
                            break;
                        case 2:
                            Opponent2();
                            break;
                        case 3:
                            Opponent3();
                            break;
                    }
                }
            }
            else
            {
                handCards[1].DeMagnify();
                
            }

            if (hit.transform.name == "Card Place Holder 3" && !handCards[2].played)
            {
                
                handCards[2].Magnify();
               
                if (Input.GetMouseButtonDown(0) && played == false && finished == false)
                {
                    
                    ;
                    handCards[2].PlayCard();
                    activeCardPlayer.Change(handCards[2]);
                    activeCardPlayer.ShowCard();
                    played = true;
                    roundCount++;
                    //Debug.Log("hit");
                    switch (stage)
                    {
                        case 1:
                            Opponent1();
                            break;
                        case 2:
                            Opponent2();
                            break;
                        case 3:
                            Opponent3();
                            break;
                    }
                    activeCardOpponent.ShowCard();
                }
            }
            else
            {
                handCards[2].DeMagnify();
                
            }

            if (hit.transform.name == "Card Place Holder 4" && !handCards[3].played)
            {
                handCards[3].Magnify();
                
                if (Input.GetMouseButtonDown(0) && played == false && finished == false)
                {
                    
                    
                    handCards[3].PlayCard();
                    activeCardPlayer.Change(handCards[3]);
                    activeCardPlayer.ShowCard();
                    played = true;
                    roundCount++;
                    //Debug.Log("hit");
                    switch (stage)
                    {
                        case 1:
                            Opponent1();
                            break;
                        case 2:
                            Opponent2();
                            break;
                        case 3:
                            Opponent3();
                            break;
                    }
                    activeCardOpponent.ShowCard();
                }
            }
            else
            {
                handCards[3].DeMagnify();
                
            }

        }
        else
        {
            ReverseMagnify();
            hovering = false;
        }
        if(played == true)
        {
            CommenceTurn();
            played = false;
        }
        if(player.health < 1)
        {
            
            youWin.enabled = false;
            oppWins.enabled = true;
            finished = true;
            
            StartCoroutine(GameOverDelay());
            

        }
        if (opp.health < 1)
        {
            youWin.enabled = true;
            oppWins.enabled = false;
            finished = true;
            
            if (!levelUp)
            {
                pm.LvlUp(typeScores[0], typeScores[1], typeScores[2], typeScores[3], typeScores[4]);
                tm.SetLvl();
                levelUp = true;
            }
            
            //StartCoroutine(ResetDelay());
            
            
        }

    }

    

    
    void ReversePlayed()
    {
        foreach(Card element in handCards)
        {
            element.played = false;
        }
        foreach (Card element in oppCards)
        {
            element.played = false;
        }
    }
    
    void PlayCardOpp(Card c)
    {
        //c.transform.position = oppPlayedPos.position;
        activeCardOpponent.Change(c);
    }
    void HideOppDeck()
    {
        for (int loop = oppDeck.Length - handCardsPos.Length; loop < oppDeck.Length; loop++)
        {
            oppDeck[loop].HideCard();
            oppDeck[loop].transform.position = deckOppPos.position;
            //Debug.Log(loop);
        }
    }


    public float CalculateDmg(Card cAtk, Card cDef, Player att, Player df)
    {
        float dmg;
        float counterBonus = 1;
        float baseDmg;
        float atkTypeDmg = 0;
        float typeDmg = 1;
        int cardType = cAtk.GetType();
        float typeNum = Random.Range(4, 8);

        float max = (float) att.GetAtk() + (atkFractionMod * (float) att.GetAtk());
        float min = (float) att.GetAtk() + (atkFractionMod * (float) att.GetAtk());
        float minDef = (float) df.GetDef() - ((float) df.GetDef() * defFractionMod);
        baseDmg = Random.Range(min, max) - (nerfDefense * Random.Range(minDef, (float)df.GetDef()));
        
        switch (cardType)
        {
            case 1:
                min = (float) att.GetFire() - ((float) att.GetFire() * typeFractionMod);
                max = (float) att.GetFire() + ((float) att.GetFire() * typeFractionMod);
                typeDmg = nerfType * Random.Range(min , max);
                break;
            case 2:
                min = (float)att.GetIce() - ((float)att.GetIce() * typeFractionMod);
                max = (float)att.GetFire() + ((float)att.GetFire() * typeFractionMod);
                typeDmg = nerfType * Random.Range(min, max);
                break;
            case 3:
                min = (float)att.GetWater() - ((float)att.GetWater() * typeFractionMod);
                max = (float)att.GetWater() + ((float)att.GetWater() * typeFractionMod);
                typeDmg = nerfType * Random.Range(min, max);
                break;
            case 4:
                min = (float)att.GetDra() - ((float)att.GetDra() * typeFractionMod);
                max = (float)att.GetDra() + ((float)att.GetDra() * typeFractionMod);
                typeDmg = nerfType * Random.Range(min, max);
                break;
            case 5:
                min = (float)att.GetEarth() - ((float)att.GetEarth() * typeFractionMod);
                max = (float)att.GetEarth() + ((float)att.GetEarth() * typeFractionMod);
                typeDmg = nerfType * Random.Range(min, max);
                break;
        }

        if (cAtk.CounterPlayer(df))
        {
            counterBonus = counterMod * baseDmg;
            tm.SuperEffective();
        }
        float crit = 0;
        int critRoll = 1;
        if(df.health < 8)
        {
            critRoll = Random.Range(0, 25);
        }
        else
        {
            critRoll = Random.Range(0, 50);
        }
        

        if(critRoll <= att.GetAcc())
        {
            crit = critMod * baseDmg;
            tm.Crit();
        }
        if (att.MatchingType(cAtk))
        {
            atkTypeDmg = nerfType * typeDmg;

        }

        


        dmg = baseDmg + crit + atkTypeDmg + counterBonus + typeDmg;
        Debug.Log(dmg);
        return dmg;

        
    }
   
    
    

    void CommenceTurn()
    {
        if (activeCardPlayer.CounterPrimary(activeCardOpponent))
        {
            tm.PlayerWins();
            Debug.Log("player win");
            int type = activeCardPlayer.GetType();
            typeScores[type - 1]+=2;
            float dmg = CalculateDmg(activeCardPlayer, activeCardOpponent, player, opp);
            opp.TakeDamage(dmg);
            oppHB.BackgroundFlash();
            opp.UpdateHealthBar();
            activeCardPlayer.DeMagnify();
            played = false;
        }
        else if (activeCardOpponent.CounterPrimary(activeCardPlayer))
        {
            tm.OppWins();
            Debug.Log("opponent win");
            float dmg = CalculateDmg(activeCardOpponent, activeCardPlayer, opp, player);
            player.TakeDamage(dmg);
            playerHB.BackgroundFlash();
            player.UpdateHealthBar();
            activeCardOpponent.DeMagnify();
            played = false;
        }
        else if (activeCardPlayer.SameCard(activeCardOpponent) && activeCardOpponent.SameCard(activeCardPlayer))
        {
            Debug.Log("same card");
            played = false;
        }
        
    }
    IEnumerator DamageDelay()
    {
        yield return new WaitForSeconds(2);
        CommenceTurn();

    }
    IEnumerator HideDelay()
    {
        yield return new WaitForSeconds(2.5f);
        activeCardOpponent.HideCard();
        activeCardPlayer.HideCard();
    }
    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(2);
        mm.LoadGame();
    }

    
    
    IEnumerator FlashOn(GameObject go)
    {
        yield return new WaitForSeconds(0.5f);
        go.SetActive(true);
    }
    IEnumerator FlashOff(GameObject go)
    {
        yield return new WaitForSeconds(1);
        go.SetActive(false);
    }
    void ReverseMagnify()
    {
        foreach(Card element in handCards)
        {
            element.DeMagnify();
        }
    }
    
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1);
        mm.Menu();
    }

    void InstantiateHand() 
    {
        int count = 0;
        List<int> nums = new List<int>();
        foreach(Card element in handCards)
        {
            int num = Random.Range(0, 8);
            while (nums.Contains(num))
            {
                num = Random.Range(0, 8);
            }
            nums.Add(num);
            element.Change(playerDeck[num]);
            element.ShowCard();
            count++;

        }

        int k = 0;
        for(int loop = 0; loop < 8; loop++)
        {
            if (!nums.Contains(loop))
            {
                playerNextHand[k] = loop;
                k++;
            }
        }
    }
    void InstantiateOpponentCards()
    {
        int count = 0;
        List<int> nums = new List<int>();
        foreach (Card element in oppCards)
        {
            int num = Random.Range(0, oppDeck.Length);
            
            while (nums.Contains(num))
            {
                num = Random.Range(0, oppDeck.Length);
            }
            nums.Add(num);
            element.Change(oppDeck[num]);
            element.HideCard();
            count++;
        }


        int k = 0;
        for (int loop = 0; loop < 8; loop++)
        {
            if (!nums.Contains(loop))
            {
                oppNextHand[k] = loop;
                k++;
            }
        }
    }
    void SetHandPositions()
    {
        int count = 0;
        foreach(Card element in handCards)
        {
            element.SetPosition(handCardsPos[count]);
            count++;
        }
        count = 0;

        foreach (Card element in oppCards)
        {
            element.SetPosition(oppHandPos[count]);
            count++;
        }
    }
    void Opponent1()
    {
        bool hasPlayed = false;
        foreach(Card element in oppCards)
        {
            if(element.GetPrimaryCode() == 1 && element.GetSecondaryCode() == 1 && element.played ==  false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if(element.GetPrimaryCode() == 2 && element.GetSecondaryCode() == 1 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 3 && element.GetSecondaryCode() == 1 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if(element.GetPrimaryCode() == 1 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }

        }
        if (!hasPlayed)
        {
            foreach(Card element in oppCards)
            {
                if(element.played == false)
                {
                    activeCardOpponent.Change(element);
                    element.PlayCard();
                    hasPlayed = true;
                    break;
                }
            }
        }
    }
    void Opponent2()
    {
        bool hasPlayed = false;
        foreach (Card element in oppCards)
        {
            if (element.GetPrimaryCode() == 2 && element.GetSecondaryCode() == 4 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 3 && element.GetSecondaryCode() == 4 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 1 && element.GetSecondaryCode() == 4 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 2 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }

        }
        if (!hasPlayed)
        {
            foreach (Card element in oppCards)
            {
                if (element.played == false)
                {
                    activeCardOpponent.Change(element);
                    element.PlayCard();
                    hasPlayed = true;
                    break;
                }
            }
        }
    }
    void Opponent3()
    {
        bool hasPlayed = false;
        foreach (Card element in oppCards)
        {
            if (element.GetPrimaryCode() == 3 && element.GetSecondaryCode() == 5 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 1 && element.GetSecondaryCode() == 5 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 2 && element.GetSecondaryCode() == 5 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }
            else if (element.GetPrimaryCode() == 3 && element.played == false)
            {
                activeCardOpponent.Change(element);
                element.PlayCard();
                hasPlayed = true;
                break;
            }

        }
        if (!hasPlayed)
        {
            foreach (Card element in oppCards)
            {
                if (element.played == false)
                {
                    activeCardOpponent.Change(element);
                    element.PlayCard();
                    hasPlayed = true;
                    break;
                }
            }
        }
    }

    void InsantiateNextHand()
    {
        int p = 0;
        int o = 0;
        foreach(Card element in handCards)
        {
            int num = playerNextHand[p];
            element.Change(playerDeck[num]);
            element.ShowCard();
            p++;
        }
        foreach (Card element in oppCards)
        {
            int num = oppNextHand[o];
            element.Change(oppDeck[num]);
            element.HideCard();
            o++;
        }
    }

    void DeckIni()
    {
        int num = 0;
        foreach(Card element in playerDeck)
        {
            int pri = DeckManager.primary[num]; 
            int sec = DeckManager.secondary[num];
            element.Change(pri, sec);
            num++;
        }
    }
    
}
