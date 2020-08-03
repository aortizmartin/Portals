using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NivelCntrl : MonoBehaviour
{
    //Controlador general del juego
    public Text boxTotal;
    public Text boxEncontrados;
    public Text boxNivel;
    public static int encontrados;
    private int totales;
    public static int nivel;
    public static int level;
    public static bool subirNivel;
    private GameObject[] targets;
    public  GameObject[] niveles;
    private int contador;
    public static bool activar = false;
    public int eligeNivel; //variable pensada para jugador un nivel directamente en tiempo de desarrollo
    private bool pararJuego;
    public GameObject panelWait;
    public GameObject minimapa;
    private bool mostrarMiniMapa;

    // Start is called before the first frame update
    void Start()
    {
        contador = niveles.Count();
        resetNivel();
    }

    // Update is called once per frame
    void Update()
    {
        boxTotal.text = "" + totales;
        boxEncontrados.text = "" + encontrados;
        if (totales == encontrados)
        {
            activar = true;
        }
        if (subirNivel)
        {
            if (level < contador)
            {
                StartCoroutine(LevelUp());
                subirNivel = false;
            }
            else
            {
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(2);
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pararJuego) { pararJuego = false; }
            else { pararJuego = true; }
            StartCoroutine(Stop());
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mostrarMiniMapa) { mostrarMiniMapa = false; }
            else { mostrarMiniMapa = true; }
            StartCoroutine(VerMiniMapa());
        }
    }
    public void resetNivel()
    {
        //Carga el nivel a jugar cuando se accede desde el menú
        for (int i = 0; i < contador; i++)
        {
           niveles[i].SetActive(false);
        }
        if (PlayerPrefs.HasKey("Level"))
        {
            nivel = PlayerPrefs.GetInt("Level");
        }else
        {
            nivel = 0;
        }
        if (eligeNivel != 0) { nivel = eligeNivel; }
        niveles[nivel].SetActive(true);       
        targets = GameObject.FindGameObjectsWithTag("Collectible");
        totales = targets.Count();
        boxNivel.text = "" + (nivel + 1);

    }
    public IEnumerator LevelUp()
    {
        //Carga el nivel siguiente

        yield return new WaitForSeconds(1.15f); // Espera a la mitad de la animación de anillos antes de cambiar de nivel
        
        niveles[level].SetActive(true);
        niveles[level-1].SetActive(false);
        encontrados = 0;
        targets = GameObject.FindGameObjectsWithTag("Collectible");
        totales = targets.Count();
        nivel = level;

        boxNivel.text = "" + (nivel + 1);
        PlayerPrefs.SetInt("Level", nivel);
        activar = false;

    }
    public IEnumerator Stop()
    {
        //Control para la tecla esc
        if(pararJuego)
        {
            Time.timeScale = 0;
            panelWait.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            panelWait.SetActive(false);
        }
        yield return new WaitForSeconds(1);
    }
    public IEnumerator VerMiniMapa()
    {
        //Habilita o deshabilita MiniMapa
        if(mostrarMiniMapa)
        {
            minimapa.SetActive(true);
        }
        else
        {
            minimapa.SetActive(false);
        }
        yield return new WaitForSeconds(1);
    }
    

}
