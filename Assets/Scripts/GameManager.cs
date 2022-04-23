using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        
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
