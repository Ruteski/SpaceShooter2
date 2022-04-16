using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private float tempoEspera = 5f;
    [SerializeField] private int level = 1;

    private int pontos = 0;
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
            //criando varios inimigos por vez
            int quantidade = level * 4;
            int qtdInimigos = 0;

            while (qtdInimigos < quantidade) {
                GameObject inimigoCriado;

                //descidindo qual inimigo vai ser criado com base no level
                float chance = Random.Range(0f, level);

                if (chance > 2f) {
                    inimigoCriado = inimigos[1];
                } else {
                    inimigoCriado = inimigos[0];
                }

                Vector3 posicao = new Vector3(Random.Range(-8f, 9f), Random.Range(6f, 17f), 0f);
                Instantiate(inimigoCriado, posicao, transform.rotation);
                
                qtdInimigos++;

                esperaInimigo = tempoEspera;
            }
        }
    }
}
