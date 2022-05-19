using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public int numberPapers;
    public GameObject menuInicial;
    public GameObject menuReinicio;
    public GameObject menuWin;

    public KeyCode startGame;

    void Start()
    {
           Time.timeScale = 0;
    }

  
    void Update()
    {           
        HideUi();
        Win();       
    }
  

public void HideUi()
{
     if(Input.GetKeyDown(startGame))
    {
    Time.timeScale = 1;
    menuInicial.SetActive (false);
    }
}


public void AwakeUi()
{
    menuReinicio.SetActive(true);
    Time.timeScale = 0;
}
public void RestartGame()
{
    SceneManager.LoadScene(0);
}
public void Win()
{
    if (numberPapers == 5)
    {
        menuWin.SetActive(true);
        Time.timeScale = 0;
        Application.Quit();
}
}
}
