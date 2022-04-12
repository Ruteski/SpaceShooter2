using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private float tempoEspera = 5f;

    private int pontos = 0;
    private int level = 1;
    private float esperaInimigo = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
    }

    private void GeraInimigos() {
        if (esperaInimigo > 0) {
            esperaInimigo -= Time.deltaTime;
        }

        if (esperaInimigo <= 0f) {
            esperaInimigo = tempoEspera;
        }
    }
}
