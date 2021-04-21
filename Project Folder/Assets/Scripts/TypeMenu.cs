using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMenu : MonoBehaviour
{
    [SerializeField] SpriteRenderer ice;
    [SerializeField] SpriteRenderer fire;
    [SerializeField] SpriteRenderer dragon;
    [SerializeField] SpriteRenderer water;
    [SerializeField] SpriteRenderer earth;
    public static int type = 1;
    public MenuManager menu;
    // Start is called before the first frame update
    void Start()
    {
        DeselectAll();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.name == "Fire Select")
            {
                fire.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    type = 1;
                    menu.LoadGame();
                }
            }
            else if (hit.transform.name == "Ice Select")
            {
                ice.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    type = 2;
                    menu.LoadGame();
                }
            }
            else if (hit.transform.name == "Water Select")
            {
                water.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    type = 3;
                    menu.LoadGame();
                }
            }
            else if (hit.transform.name == "Dragon Select")
            {
                dragon.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    type = 4;
                    menu.LoadGame();
                }
            }
            else if (hit.transform.name == "Earth Select")
            {

                earth.enabled = true;
                if (Input.GetMouseButtonDown(0))
                {
                    type = 5;
                    menu.LoadGame();
                }
            }
            
        }
        else
        {
            DeselectAll();
        }

    }

    void DeselectAll()
    {
        fire.enabled = false;
        water.enabled = false;
        earth.enabled = false;
        ice.enabled = false;
        dragon.enabled = false;
    }
}
