using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //prędkość poruszania się tła
    public float scrollingSpeed;

    [SerializeField]
    private Renderer backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //obracaj teksturę tła na materiale
        backgroundRenderer.material.mainTextureOffset += new Vector2(scrollingSpeed * Time.deltaTime, 0);

    }
}
