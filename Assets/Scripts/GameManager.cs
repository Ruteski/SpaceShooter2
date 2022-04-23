using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake() {
        // garantindo que so exista 1 gamemanger por vez
        int qtd = FindObjectsOfType<GameManager>().Length;  

        if (qtd > 1) {
            Destroy(gameObject);    
        }
 
        // nao serei destruido ao mudar de cena
        DontDestroyOnLoad(gameObject);    
    }

    public void IniciaJogo() {
        SceneManager.LoadScene("Jogo");
    }

    public void TelaInicio() {
        SceneManager.LoadScene(0);
    }

    public void Sair() {
        Application.Quit(); 
    }
}
