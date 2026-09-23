using UnityEngine;

public class GiraGira : MonoBehaviour
{

    public float velocidade = 50f;

    private bool girando = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                girando = true;
            }
        }

        // Também permite testar com clique do mouse no computador
        if (Input.GetMouseButtonDown(0))
        {
            girando = true;
        }

        // Faz o modelo girar
        if (girando)
        {
            transform.Rotate(0f, velocidade * Time.deltaTime, 0f);
        }
    }
}

