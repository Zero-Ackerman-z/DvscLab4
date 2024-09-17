using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI comboScoreText; 
    public TextMeshProUGUI cumulativeScoreText; 

    private int comboScore = 0; 
    private int cumulativeScore = 0; 

    private float comboDisplayTime = 2f; 

    void Start()
    {
        UpdateCumulativeScoreText();
        HideComboScore();
    }

    public void AddScore(int score)
    {
        comboScore = score; // Puntaje del combo actual
        cumulativeScore += comboScore; // Sumar al puntaje acumulativo

        // Mostrar puntaje combo
        comboScoreText.text =  comboScore.ToString() +"X";
        comboScoreText.gameObject.SetActive(true);

        // Actualizar el puntaje acumulativo en pantalla
        UpdateCumulativeScoreText();

        // Desvanecer el puntaje combo después de un tiempo
        Invoke("HideComboScore", comboDisplayTime);
    }

    void UpdateCumulativeScoreText()
    {
        cumulativeScoreText.text =  cumulativeScore.ToString();
    }

    void HideComboScore()
    {
        comboScoreText.gameObject.SetActive(false);
    }
}
