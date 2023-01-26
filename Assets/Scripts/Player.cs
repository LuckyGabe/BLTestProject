using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameManager gameManager;

    [SerializeField]
    private int maxHealth = 3; //maksymalne zdrowie gracza

    [SerializeField]
    private GameObject shootPoint; //punkt z którego wyruszy pocisk
    [SerializeField]
    private GameObject projectilePrefab; // prefab pocisku
    private Vector2 screenBounds;
    public float movementSpeed; // prędkość poruszania się gracza (pionowo)

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.currentHealth = maxHealth;

        //znajdź granice ekranu
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.bGameOver) //jeżeli gra sie nie zakończyła
        {

            Move();

            //strzel po naciśnięciu spacji
            if (Input.GetKeyDown(KeyCode.Space)) { Shoot(); }

        }
    }

    private void LateUpdate()
    {
        //Trzymaj gracza w granicach ekranu
        Vector3 visiblePos = transform.position;
        visiblePos.y = Mathf.Clamp(visiblePos.y, (screenBounds.y - 1) * -1, (screenBounds.y - 1));
        transform.position = visiblePos;

    }

    private void Move()
    {
        // po naciśnięciu strzałki w górę, gracz porusza się w górę
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            transform.Translate(new Vector3(0, 1 * movementSpeed, 0));

        }
        // po naciśnięciu strzałki w dół, gracz porusza się w dół
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -1 * movementSpeed, 0));
        }

    }

    private void Shoot()
    {
        //stwórz kopię pocisku
        GameObject projectile = Instantiate<GameObject>(projectilePrefab);
        //zmień pozycję pocisku na pozycję shootpointa
        projectile.transform.position = shootPoint.transform.position;
        //aktywuj pocisk
        projectile.SetActive(true);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jeżeli gracz skolidował z przeciwnikiem
        if (collision.collider.CompareTag("Enemy"))
        {
            //odejmij jedno życie z zasadą że ilość żyć nie może być mniejsza od 0
            gameManager.currentHealth = Mathf.Clamp(gameManager.currentHealth - 1, 0, maxHealth);
        }
    }

}
