using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{

    public GameObject PanelMenu;
    public GameObject PanelIntrucciones;
    public GameObject PanelCreditos;

    public void Juego()
    {
        StartCoroutine(RouInstru(false,true));
        /*PanelMenu.SetActive(false);
        PanelIntrucciones.SetActive(true);*/
    }


    public void Intru_Menu()
    {
        StartCoroutine(RouInstru(true, false));
        /*PanelMenu.SetActive(true);
        PanelIntrucciones.SetActive(false);*/
    }       
    public void Intruciones()
    {
        SceneManager.LoadScene("lvl");
    }
    public void Creditos()
    {
        StartCoroutine(RouCreditos(false, true));
        /*PanelMenu.SetActive(false);
        PanelCreditos.SetActive(true);*/
    }
    
    public void Creditos_Menu()
    {
        StartCoroutine(RouCreditos(true, false));
        /*PanelMenu.SetActive(true);
        PanelCreditos.SetActive(false);*/
    }
    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator RouCreditos(bool primer, bool segun)
    {
        yield return new WaitForSeconds(.5f);
        PanelMenu.SetActive(primer);
        PanelCreditos.SetActive(segun);
    }

    IEnumerator RouInstru(bool primer, bool segun)
    {
        yield return new WaitForSeconds(.5f);
        PanelMenu.SetActive(primer);
        PanelIntrucciones.SetActive(segun);
    }

}
