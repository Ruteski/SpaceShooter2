using System.Collections;
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

    IEnumerator PrimeiraCena() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }

    public void IniciaJogo() {
        SceneManager.LoadScene("Jogo");
    }

    public void TelaInicio() {
        StartCoroutine(PrimeiraCena());
    }

    public void Sair() {
        Application.Quit(); 
    }
}
