using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;  // Puntaje acumulativo
    public TextMeshProUGUI scoreText;  // Texto que muestra el puntaje acumulativo
    public TextMeshProUGUI comboScoreText;  // Texto que muestra el puntaje de combo

    private int comboScore = 0;  // Puntaje de combo actual
    public GameObject hitObjectPrefab;  // Prefab del objeto clicable
    public Vector2[] spawnPositions;  // Posiciones donde se instanciarán los objetos

    void Start()
    {
        UpdateScore(0);
        comboScoreText.gameObject.SetActive(false);
        foreach (var position in spawnPositions)
        {
            GameObject newObject = Instantiate(hitObjectPrefab, position, Quaternion.identity);
        }
    }
    // Actualiza el puntaje acumulativo
    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    // Muestra el puntaje de combo y lo desvanece después de un tiempo
    public void ShowComboScore(int points, Vector3 position)
    {
        comboScore = points;
        comboScoreText.transform.position = position;
        comboScoreText.text = "+" + points;
        comboScoreText.gameObject.SetActive(true);
        Invoke("HideComboScore", 1f);  // Desvanece después de 1 segundo
    }

    // Oculta el puntaje de combo
    private void HideComboScore()
    {
        comboScoreText.gameObject.SetActive(false);
    }
}