using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake() {
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
