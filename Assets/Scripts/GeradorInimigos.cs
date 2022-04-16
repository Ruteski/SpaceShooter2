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

    //metodo para checar se a posica esta liver
    private Collider2D ChecaPosicao(Vector3 posicao, Vector3 size) {
        //checando se na posicao passada existe algum colider2d
        Collider2D hit = Physics2D.OverlapBox(posicao, size, 0f);

        //se o hit é null nao houve colisao
        return hit;
    }

    private void GeraInimigos() {
        if (esperaInimigo > 0) {
            esperaInimigo -= Time.deltaTime;
        }

        if (esperaInimigo <= 0f && qtdInimigos <= 0) {
            //criando varios inimigos por vez
            int quantidade = level * 4;
            int tentativas = 0;


            while (qtdInimigos < quantidade) {
                tentativas++;

                if (tentativas >= 200) {
                    break;
                }

                GameObject inimigoCriado;

                //descidindo qual inimigo vai ser criado com base no level
                float chance = Random.Range(0f, level);

                if (chance > 2f) {
                    inimigoCriado = inimigos[1];
                } else {
                    inimigoCriado = inimigos[0];
                }

                Vector3 posicao = new Vector3(Random.Range(-8f, 9f), Random.Range(6f, 17f), 0f);

                //checo se a posicao esta livre
                if (ChecaPosicao(posicao, inimigoCriado.transform.localScale) == null) {
                    Instantiate(inimigoCriado, posicao, transform.rotation);
                    qtdInimigos++;
                    esperaInimigo = tempoEspera;
                } else {
                    bool criou = false;

                    while (!criou) {
                        posicao = new Vector3(Random.Range(-8f, 9f), Random.Range(6f, 17f), 0f);

                        if (ChecaPosicao(posicao, inimigoCriado.transform.localScale) == null) {
                            criou = true;

                            Instantiate(inimigoCriado, posicao, transform.rotation);
                            qtdInimigos++;
                            esperaInimigo = tempoEspera;
                        } else {
                            tentativas++;
                            if (tentativas >= 200) {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
