using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public static int [] primary = new int [8];
    public static int[] secondary = new int[8];
    public Card[] deckVis = new Card[8];

    public enum CardType
    {
        icePaper,
        iceRock,
        iceScissors,
        firePaper,
        fireRock,
        fireScissors,
        waterPaper,
        waterRock,
        waterScissors,
    }
    [SerializeField] Transform icePaper;
    [SerializeField] Transform draPaper;
    [SerializeField] Transform firePaper;
    [SerializeField] Transform waterPaper;
    [SerializeField] Transform earthPaper;
    [SerializeField] Transform iceRock;
    [SerializeField] Transform draRock;
    [SerializeField] Transform fireRock;
    [SerializeField] Transform waterRock;
    [SerializeField] Transform earthRock;
    [SerializeField] Transform iceSci;
    [SerializeField] Transform draSci;
    [SerializeField] Transform fireSci;
    [SerializeField] Transform waterSci;
    [SerializeField] Transform earthSci;

    [SerializeField] SpriteRenderer [] highlight = new SpriteRenderer [8]; 
    int count = 0;

    [SerializeField] GameObject confirmButton;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        HighlightCard(count);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            
            string card = hit.transform.name;
            if(hit.collider.tag == "cardShow" && Input.GetMouseButtonDown(0))
            {
                
                switch (card)
                {
                    case "Card Select0":
                        count = 0;
                        HighlightCard(count);
                        break;
                    case "Card Select1":
                        count = 1;
                        HighlightCard(count);
                        break;
                    case "Card Select2":
                        count = 2;
                        HighlightCard(count);
                        break;
                    case "Card Select3":
                        count = 3;
                        HighlightCard(count);
                        break;
                    case "Card Select4":
                        count = 4;
                        HighlightCard(count);
                        break;
                    case "Card Select5":
                        count = 5;
                        HighlightCard(count);
                        break;
                    case "Card Select6":
                        count = 6;
                        HighlightCard(count);
                        break;
                    case "Card Select7":
                        count = 7;
                        HighlightCard(count);
                        break;
                }
            }
            else 
            {
                Maginify(hit.collider.transform);
                if (Input.GetMouseButtonDown(0))
                {
                    switch (card)
                    {
                        case "Fire_Paper":
                            ReverseMagnify();
                            deckVis[count].Change(2, 1);
                            deckVis[count].ShowCard();
                            primary[count] = 2;
                            secondary[count] = 1;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Fire_Rock":
                            ReverseMagnify();
                            deckVis[count].Change(1, 1);
                            deckVis[count].ShowCard();
                            primary[count] = 1;
                            secondary[count] = 1;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Fire_Scissors":
                            ReverseMagnify();
                            deckVis[count].Change(3, 1);
                            deckVis[count].ShowCard();
                            primary[count] = 3;
                            secondary[count] = 1;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Ice_Rock":
                            ReverseMagnify();
                            deckVis[count].Change(1, 2);
                            deckVis[count].ShowCard();
                            primary[count] = 1;
                            secondary[count] = 2;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Ice_Paper":
                            ReverseMagnify();
                            deckVis[count].Change(2, 2);
                            deckVis[count].ShowCard();
                            primary[count] = 2;
                            secondary[count] = 2;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Ice_Scissors":
                            ReverseMagnify();
                            deckVis[count].Change(3, 2);
                            deckVis[count].ShowCard();
                            primary[count] = 3;
                            secondary[count] = 2;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Water_Rock":
                            ReverseMagnify();
                            deckVis[count].Change(1, 3);
                            deckVis[count].ShowCard();
                            primary[count] = 1;
                            secondary[count] = 3;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Water_Paper":
                            ReverseMagnify();
                            deckVis[count].Change(2, 3);
                            deckVis[count].ShowCard();
                            primary[count] = 2;
                            secondary[count] = 3;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Water_Scissors":
                            ReverseMagnify();
                            deckVis[count].Change(3, 3);
                            deckVis[count].ShowCard();
                            primary[count] = 3;
                            secondary[count] = 3;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Dragon_Rock":
                            ReverseMagnify();
                            deckVis[count].Change(1, 4);
                            deckVis[count].ShowCard();
                            primary[count] = 1;
                            secondary[count] = 4;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Dragon_Paper":
                            ReverseMagnify();
                            deckVis[count].Change(2, 4);
                            deckVis[count].ShowCard();
                            primary[count] = 2;
                            secondary[count] = 4;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Dragon_Scissors":
                            ReverseMagnify();
                            deckVis[count].Change(3, 4);
                            deckVis[count].ShowCard();
                            primary[count] = 3;
                            secondary[count] = 4;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Earth_Rock":
                            ReverseMagnify();
                            deckVis[count].Change(1, 5);
                            deckVis[count].ShowCard();
                            primary[count] = 1;
                            secondary[count] = 5;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Earth_Paper":
                            ReverseMagnify();
                            deckVis[count].Change(2, 5);
                            deckVis[count].ShowCard();
                            primary[count] = 2;
                            secondary[count] = 5;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;
                        case "Earth_Scissors":
                            ReverseMagnify();
                            deckVis[count].Change(3, 5);
                            deckVis[count].ShowCard();
                            primary[count] = 3;
                            secondary[count] = 5;
                            count++;
                            if (count == 8)
                            {
                                count = 7;
                                confirmButton.SetActive(true);
                            }
                            HighlightCard(count);
                            break;

                    }
                }
                    
            }
            

        }
        else
        {
            ReverseMagnify();
        }
    }

    public void HighlightCard(int index)
    {
        int count = 0;
        foreach(var element in highlight)
        {
            if(count == index)
            {
                element.enabled = true;
            }
            else
            {
                element.enabled = false;
            }
            count++;
        }
    }
    public void Maginify(Transform t)
    {
        t.localScale = new Vector3(0.25f, 0.25f, 1);
    }
    public void Demaginify(Transform t)
    {
        t.localScale = new Vector3(0.2f, 0.2f, 1);
    }
    void ReverseMagnify()
    {
        Demaginify(icePaper);
        Demaginify(draPaper);
        Demaginify(firePaper);
        Demaginify(waterPaper);
        Demaginify(earthPaper);
        Demaginify(iceRock);
        Demaginify(draRock);
        Demaginify(fireRock);
        Demaginify(waterRock);
        Demaginify(earthRock);
        Demaginify(iceSci);
        Demaginify(draSci);
        Demaginify(fireSci);
        Demaginify(waterSci);
        Demaginify(earthSci);
    }
}
