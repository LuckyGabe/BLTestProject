
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed; // prędkość (i kierunek) poruszania się przeciwników

    // Update is called once per frame
    void Update()
    {
        // przeciwnik przemieszcza się cały czas
        transform.Translate(new Vector3(speed, 0, 0));
    }
}
