using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text critHit;
    public Text superEff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CritHit()
    {
        critHit.gameObject.SetActive(true);
        StartCoroutine(CritHitDelay());
    }
    public void LoadTut1()
    {
        SceneManager.LoadScene("Tut1");
    }
    public void LoadTut2()
    {
        SceneManager.LoadScene("Tut2");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadGame2()
    {
        SceneManager.LoadScene("Game 2");
    }
    public void LoadGame3()
    {
        SceneManager.LoadScene("Game 3");
    }
    public void LoadTypeSelect()
    {
        SceneManager.LoadScene("TypeSelect");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void DeckBuilder()
    {
        SceneManager.LoadScene("DeckBuilder");
    }
    IEnumerator CritHitDelay()
    {
        yield return new WaitForSeconds(2);
        critHit.gameObject.SetActive(false);

    }
}
