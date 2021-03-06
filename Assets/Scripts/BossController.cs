using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : InimigoPai
{
    private const int _vida = 50;

    [Header("Info Basicas")]
    [SerializeField] private string estado = "estado1";
    [SerializeField] private string[] estados;
    [SerializeField] private GameObject goAnimacaoMorte;
    [SerializeField] private Image barraVida;
    [SerializeField] private int vidaMaxima = _vida;
    private float esperaEstado = 10f;

    [Header("Info Tiro")]
    [SerializeField] private GameObject goTiro2;
    [SerializeField] private Transform posTiro;
    [SerializeField] private Transform posTiro2;
    private float delayTiro = 1f;

    private Rigidbody2D rb;
    private bool direita = false;
    private readonly float limiteHorizontal = 6f;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        // vida inicial
        vida = vidaMaxima;

        //avisando para o meu canvas que a camera dele ? a camera atual do jogo
        //pegando o canvas do boss - aviasndo qual ? a camera
        //passando a camera do jogo
        //GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        AumentaDificuldade();
        TrocaEstado();

        switch (estado) {
            case "estado1":
                Estado1();
                Tiro1();
                break;

            case "estado2":
                Estado2();
                break ;

            case "estado3":
                Estado3();  
                break;
        }

        barraVida.fillAmount = ((float)vida / (float)vidaMaxima);

        ////muda a cor da barra ao perder vida
        //converte o valor do full amount para alguma coisa entre 0e 255
        //barraVida.color = new Color32(190, (byte)(barraVida.fillAmount * 255), 54, 255);
    }

    private void AumentaDificuldade() {
        if (vida <= (vidaMaxima/3)) {
            delayTiro = 0.7f;
        } else if (vida <= (vidaMaxima/2)) {
            delayTiro = 0.9f;
        }
    }

    private void Estado2() {
        rb.velocity = Vector2.zero;
        Tiro2 ();
    }

    private void Estado3() {
        rb.velocity = Vector2.zero;
        Tiro1();
        Tiro2();
    }

    private void Tiro1() {
        Vector3 posicao1 = new Vector3(posTiro.position.x - 1.6f, posTiro.position.y - 0.3f);
        Vector3 posicao2 = new Vector3(posTiro.position.x + 1.6f, posTiro.position.y - 0.3f);

        esperaTiro -= Time.deltaTime;

        if (esperaTiro < 0f) {
            SomTiro();

            GameObject tiro1 = Instantiate(goTiro, posicao1, transform.rotation);
            tiro1.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);

            GameObject tiro2 = Instantiate(goTiro, posicao2, transform.rotation);
            tiro2.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -velocidadeTiro);

            esperaTiro = delayTiro;
        }
    }

    private void Tiro2() {
        // encontrando o player na cena
        var player = FindObjectOfType<PlayerController>();

        if (player) {
            //diminui tempo de espera para atirar
            esperaTiro -= Time.deltaTime;

            if (esperaTiro < 0f) {
                SomTiro();

                //instanciando o tiro
                GameObject tiro = Instantiate(goTiro2, posTiro2.position, transform.rotation);

                // encontrando a direcao do player
                Vector2 direcao = player.transform.position - tiro.transform.position;

                //normalizando a velocidade dele
                direcao.Normalize();

                tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                //dando o angulo que o tiro tem que estar(a conta do angulo ? padrao)
                /*float angulo = Mathf.Atan2(direcao.y, direcao.x);// retorna o valor em radiano
                angulo = angulo * Mathf.Rad2Deg; // converte radianos em graus*/

                float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;

                //passando o angulo para o a sprite do tiro
                tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f);

                esperaTiro = delayTiro / 2;
            }
        }

    }

    private void Estado1() {
        if (direita) {
            rb.velocity = new Vector3(velocidade, 0f);

            if (transform.position.x >= limiteHorizontal) {
                direita = false;
            }
        } else {
            rb.velocity = new Vector3(-velocidade, 0f);

            if (transform.position.x <= -limiteHorizontal) {
                direita = true;
            }
        }
    }

    private void TrocaEstado() {
        if (esperaEstado <= 0f) {
            int indiceEstado = Random.Range(0, estados.Length);

            estado = estados[indiceEstado];

            esperaEstado = 2f;
        } else {
            esperaEstado -= Time.deltaTime;
        }
    }

    private void OnDestroy() {
        GameObject _anim = Instantiate(goAnimacaoMorte, transform.position, transform.rotation);
        Destroy(_anim, 4.1f);
    }
}
