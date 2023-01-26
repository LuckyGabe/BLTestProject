using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject[] spawnPoints;  //miejsca na torach na których spawnują się przeciwnicy
    public int score; //aktualny wynik
    public int currentHealth; //aktualne zdrowie gracza
    private float time = 60f; // maksymalny czas gry
    public float backToMenuTime = 3f; //czas po jakim gra powróci do menu (od wyświetlenia ekranu końca gry)
    public bool bGameOver = false;

    // panel końca gry
    [SerializeField]
    private GameObject gameOverScreen;

    //teksty w UI
    private TextMeshProUGUI scoreText, healthText, timeText;

    void Awake()
    {
        // znajdowanie objektów
        SetUp();
    }

    // Update is called once per frame
    void Update()
    {

        // Aktualizacja licznika
        time -= 1 * Time.deltaTime;

        //jeżeli czas się skończył, zakończ grę
        if (time == 0 || currentHealth == 0) { bGameOver = true; }

        if (bGameOver)
        {
            GameOver();
        }

        //aktualizacja tekstów na ekranie
        timeText.text = "Czas: " + ((int)time).ToString() + "s";
        healthText.text = "Życia: " + currentHealth;
        scoreText.text = "Punkty: " + score;

    }


    private void GameOver()
    {
        //aktualizacja licznika końca gry
        backToMenuTime -= 1 * Time.deltaTime;

        //Pokaż panel końca gry
        gameOverScreen.SetActive(true);

        //jeżeli wynik jest większy od rekordu, zaaktualizuj rekord
        if (score > PlayerPrefs.GetInt("TopScore"))
        {
            PlayerPrefs.SetInt("TopScore", score);
        }

        //zapisz ostatni wynik
        PlayerPrefs.SetInt("LastScore", score);

        //Wróc do menu
        if (backToMenuTime <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }


    // znajdowanie objektów
    protected void SetUp()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();

        healthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();

        timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();

    }
}
