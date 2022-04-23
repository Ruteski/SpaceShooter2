using UnityEngine;
using UnityEngine.UI;

public class GeradorInimigos : MonoBehaviour
{
    [SerializeField] private GameObject[] inimigos;
    [SerializeField] private float tempoEspera = 2f;
    [SerializeField] private int level = 1;
    [SerializeField] private int pontos = 0;
    [SerializeField] private int baseLevel = 100;
    [SerializeField] private int qtdInimigos = 0;
    [SerializeField] private float esperaInimigo = 2f;
    [SerializeField] private GameObject bossAnimation;
    [SerializeField] private Text textoPontuacao;

    private bool animacaoBoss = false;

    private void Start() {
        textoPontuacao.text = pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (level < 10) { 
            GeraInimigos();
        } else if (qtdInimigos <= 0 && tempoEspera > 0){
            tempoEspera -= Time.deltaTime;

            if (tempoEspera <= 0f){
                GeraBoss();
            }
        }
    }

    private void GeraBoss() {
        if (!animacaoBoss) {
            GameObject anim = Instantiate(bossAnimation, Vector3.zero, transform.rotation);
            Destroy(anim, 6.3f);
            animacaoBoss = true;
        }
    }

    public void GanhaPontos(int pontos) {
        this.pontos += pontos * level;
        textoPontuacao.text = this.pontos.ToString();

        //ganhando level se os pontos forem maior que a base do level * o level
        if (this.pontos > baseLevel) {
            level++;

            //dobrando a quantidade de pontos necessarios para o proximo level
            baseLevel *= 2;
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
