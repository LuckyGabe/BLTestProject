using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    private TextMeshProUGUI lastScoreText;
    private TextMeshProUGUI topScoreText;

    // Start is called before the first frame update
    void Start()
    {

        SetUp();

    }

    // Update is called once per frame
    void Update()
    {
        // Jeżeli jakikolwiek klawisz/przycisk (oprócz lewego przycisku myszki aby można było wcisnąć przycisk wyjścia)
        if (Input.anyKey && !Input.GetMouseButton(0))
        {
            // Przejdź do gry
            SceneManager.LoadScene("Game");

        }
    }

    //znajdz i przypisz zmienne
    protected void SetUp()
    {

        topScoreText = GameObject.Find("TopScoreText").GetComponent<TextMeshProUGUI>();
        topScoreText.text = "Najlepszy wynik: " + PlayerPrefs.GetInt("TopScore");
        lastScoreText = GameObject.Find("LastScoreText").GetComponent<TextMeshProUGUI>();
        lastScoreText.text = "Ostatni wynik podczas sesji: " + PlayerPrefs.GetInt("LastScore");

    }

    //zamknij grę
    public void ExitGame()
    {
        //zresetuj ostatni wynik podczas sesji
        PlayerPrefs.SetInt("LastScore", 0);

        Debug.Log("Quit");
        Application.Quit();

    }
}
