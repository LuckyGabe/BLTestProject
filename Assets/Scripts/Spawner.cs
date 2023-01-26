using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    protected GameManager gameManager;


    [SerializeField]
    private GameObject[] enemyPlanesPrefabs;

    [SerializeField]
    private float spawnTime; // co jaki okres czasu spawnuje przeciwników

    protected bool bIsSpawning; // zmienna zapobiegająca nakładaniu się na siebie coroutine

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());

    }

    private IEnumerator Spawn()
    {
        if (!bIsSpawning) //jeżeli aktualnie nie spawnuje
        {
            //zaznacz że jest podczas spawnowania
            bIsSpawning = true;

            // losuj ilość respionych samolotów
            int numberOfPlanes = Random.Range(2, 5);

            // losuj na ilu torach zrespić przeciwników
            int numberOfTracks = Random.Range(1, 5);
            for (int y = 0; y < numberOfTracks; y++)
            {
                //losuj pozycję samolotów
                int randomSpawnPoint = Random.Range(0, gameManager.spawnPoints.Length);

                for (int i = 0; i <= numberOfPlanes; i++)
                {
                    //losuj rodzaj (kolor) przeciwnika
                    int planeType = Random.Range(0, enemyPlanesPrefabs.Length);
                    //stwórz kopię przeciwnika
                    GameObject planeGO = Instantiate<GameObject>(enemyPlanesPrefabs[planeType]);
                    //ustaw przeciwnika na pozycji
                    planeGO.transform.position = gameManager.spawnPoints[randomSpawnPoint].transform.position;
                    //poczekaj przed zrespieniem następnego przeciwnika
                    yield return new WaitForSeconds(0.7f);

                }
            }
            //poczekaj przed zrespieniem kolejnej serii przeciwników
            yield return new WaitForSeconds(spawnTime);

            bIsSpawning = false;


        }
    }



}

