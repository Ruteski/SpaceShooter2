using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoController : MonoBehaviour
{
    //pegando o audioclipe
    [SerializeField] private AudioClip meuSom;

    // Start is called before the first frame update
    void Start()
    {
        //tocando o audioclip
        // posicao da camera
        //AudioSource.PlayClipAtPoint(meuSom, new Vector3(0f,0f,-10f));
        AudioSource.PlayClipAtPoint(meuSom, Vector3.zero);
    }

    public void Morrendo() {
        Destroy(gameObject);
    }
}
