using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject goTiro;
    [SerializeField] private GameObject goTiro2;
    [SerializeField] private Transform posTiro;
    [SerializeField] private int vida = 3;
    [SerializeField] private GameObject goExplosao;
    [SerializeField] private float velocidadeTiro = 6f;
    [SerializeField] private int levelTiro = 1;
    [SerializeField] private GameObject goEscudo;
    [SerializeField] private Text textoVida;
    [SerializeField] private Text textoEscudo;

    [SerializeField] private float xLimite = 8.3f;
    [SerializeField] private float yLimite = 4.4f;

    private Vector2 minhaVelocidade;
    private float horizontal;
    private float vertical;
    private GameObject escudoAtual;
    private readonly float escudoTimer = 6.2f;
    private int totalEscudo = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        textoVida.text = vida.ToString();
        textoEscudo.text = totalEscudo.ToString();
    }

    // Update is called once per frame
    void Update() {
        minhaVelocidade = Direcao();

        Atirando();
        Escudo();
    }

    private void FixedUpdate() {
        Movendo();
    }

    private void Movendo() {
        //passando a minha velocidade para o rb
        meuRB.velocity = minhaVelocidade * velocidade;

        //limitando a posicao da tela
        //funcao Clamp
        float meuX = Mathf.Clamp(transform.position.x, -xLimite, xLimite);
        float meuY = Mathf.Clamp(transform.position.y, -yLimite, yLimite);

        //aplicando minha posicao X
        transform.position = new Vector3(meuX, meuY);
    }

    private Vector2 Direcao() {
        //pegando o input horizontal
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //normalizando para que a velocidade diagonal seja a msm da velocidade nos eixos
        minhaVelocidade.Normalize();
        return minhaVelocidade;
    }

    private void Escudo() {
        if (Input.GetButtonDown("Shield") && !escudoAtual && totalEscudo > 0) {
            escudoAtual = Instantiate(goEscudo, transform.position, transform.rotation);
            Destroy(escudoAtual, escudoTimer);

            totalEscudo--;
            textoEscudo.text = totalEscudo.ToString();
        }

        if (escudoAtual) {
            escudoAtual.transform.position = transform.position;
        }
        
    }

    private void Atirando() {
        if (Input.GetButtonDown("Fire1")) {
            switch (levelTiro) {
                case 1:
                    CriaTiro(goTiro, posTiro.position);
                    break;
                case 2:
                    Vector3 posicao = new Vector3(posTiro.position.x - 0.45f, posTiro.position.y + 0.1f);
                    CriaTiro(goTiro2, posicao);

                    posicao = new Vector3(posTiro.position.x + 0.45f, posTiro.position.y + 0.1f);
                    CriaTiro(goTiro2, posicao);
                    break;
                case 3:
                    CriaTiro(goTiro, posTiro.position);
                    
                    posicao = new Vector3(posTiro.position.x - 0.45f, posTiro.position.y + 0.1f);
                    CriaTiro(goTiro2, posicao);

                    posicao = new Vector3(posTiro.position.x + 0.45f, posTiro.position.y + 0.1f);
                    CriaTiro(goTiro2, posicao);
                    break;
            }
        }
    }

    private void CriaTiro(GameObject tiroCriado, Vector3 posicao) {
        GameObject tiro = Instantiate(tiroCriado, posicao, transform.rotation);

        //dar direcao e velocidade para o rb do tiro
        tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
    }

    public void PerdeVida(int dano) {
        vida -= dano;
        textoVida.text = vida.ToString();

        if (vida <= 0) { 
            Destroy(gameObject);
            Instantiate(goExplosao, transform.position, transform.rotation);

            var gameManager = FindObjectOfType<GameManager>();

            if (gameManager) {
                gameManager.TelaInicio();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject go = collision.gameObject;

        if (go.CompareTag("PowerUp")) {
            if (levelTiro < 3) {
                levelTiro++;
            }

            Destroy(go);
        }
    }
}
