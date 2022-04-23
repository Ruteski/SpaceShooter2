using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void OnDestroy() {
        Instantiate(boss, transform.position, transform.rotation);
    }

    public void MorreBoss() {
        print("caralha");

        var gameManager = FindObjectOfType<GameManager>();

        if (gameManager) {
            gameManager.TelaInicio(); 
        }
    }
}
