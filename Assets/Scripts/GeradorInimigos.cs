using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private float tempoEspera = 5f;
    [SerializeField] private int level = 1;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int baseLevel = 100;
    [SerializeField] private int qtdInimigos = 0;
    [SerializeField] private float esperaInimigo = 2f;

    // Update is called once per frame
    void Update()
    {
        GeraInimigos();
    }

    public void GanhaPontos(int pontos) {
        this.pontos += pontos;

        //ganhando level se os pontos forem maior que a base do level * o level
        if (this.pontos > (baseLevel * level)) {
            level++;
        }
    }

    //diminui a quantidade de inimigos
    public void DiminuiQuantidade() {
        qtdInimigos--;
    }

    private void GeraInimigos() {
        if (esperaInimigo > 0) {
            esperaInimigo -= Time.deltaTime;
        }

        if (esperaInimigo <= 0f && qtdInimigos <= 0) {
            //criando varios inimigos por vez
            int quantidade = level * 4;

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
