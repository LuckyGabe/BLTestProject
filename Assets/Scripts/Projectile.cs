using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private float projectileSpeed; //prędkość pocisku


    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // jeśli pocisk jest aktywny, będzie poruszał się poziomo
        transform.Translate(new Vector3(projectileSpeed, 0, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //jeżeli pocisk skoliduje z przeciwnikiem
        if (collision.collider.CompareTag("Enemy"))
        {
            //dodaj punkt
            gameManager.score++;
            //usuń przeciwnika
            Destroy(collision.gameObject);
            //usuń pocisk
            Destroy(this.gameObject);
        }
    }

}
