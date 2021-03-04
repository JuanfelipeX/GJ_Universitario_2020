using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_hud : MonoBehaviour
{
    // Cuenta de Tripulante
    public static int numeroTripulante = 0;
    public string nTripulanteString = "Tripulantes : ";
    public Text TextTripulante;


    // Cuenta de Puntaje
    public static int score = 0;
    public string scoreString = "Puntaje : ";
    public Text TextScore;

    public static UI_hud Monetary;

    private void Awake()
    {
        Monetary = this;
    }



    void Update()
    {
        //Agregar al score el puntaje :
       // Score = Game_Controller.score2;

        if (TextTripulante != null)
        {
            TextTripulante.text = nTripulanteString + numeroTripulante.ToString();
        }
        if (TextScore != null)
        {
            TextScore.text = scoreString + score.ToString();
        }
    }
}
