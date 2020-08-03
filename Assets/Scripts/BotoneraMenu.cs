using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoneraMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject HelpPanel;
    public void nuevaPartida()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void continuarPartida()
    {
        SceneManager.LoadScene(1);
    }
    public void Ayuda()
    {
        MainMenu.SetActive(false);
        HelpPanel.SetActive(true);
    }
    public void Back()
    {
        HelpPanel.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void salir()
    {
        Application.Quit();
    }
}
