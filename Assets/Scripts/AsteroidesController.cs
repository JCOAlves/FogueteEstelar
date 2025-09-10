using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AsteroidesController : MonoBehaviour
{
    [SerializeField] private GameObject AsteroideVerde, AsteroideAmarelo, AsteroideVermelho;
    [SerializeField] private GameObject pontoAsteroides;
    [SerializeField] private float intervalo;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating([nome da função entre aspas], [tempo em segundos para começar a função], [intevalo de repetição em segundos]);
        InvokeRepeating("Asteroides", 0f, intervalo);
    }

    private void Asteroides()
    {
        List<string> listaAsteroides = new List<string> { "Verde", "Amarelo", "Vermelho" };
        int posicaoAsteroide = UnityEngine.Random.Range(0, 3);
        float posicaoX = UnityEngine.Random.Range(-15f, 15f);
        float posicaoY = pontoAsteroides.transform.position.y;
        string AsteroideEscolhido = listaAsteroides[posicaoAsteroide];

        switch (AsteroideEscolhido)
        {
            case "Verde":
                Instantiate(
                    AsteroideVerde, //Instancia do asteroide
                    new Vector2(posicaoX, posicaoY), //Na posição (posicaoX, posicaoY)
                    Quaternion.identity  //Com rotação padrão (sem rotação, identidade)
                );
                UnityEngine.Debug.Log("Asteroide Verde");
                break;
            case "Amarelo":
                Instantiate(
                    AsteroideAmarelo,
                    new Vector2(posicaoX, posicaoY),
                    Quaternion.identity  
                );
                UnityEngine.Debug.Log("Asteroide Amarelo");
                break;
            case "Vermelho":
                Instantiate(
                    AsteroideVermelho,
                    new Vector2(posicaoX, posicaoY),
                    Quaternion.identity  
                );
                UnityEngine.Debug.Log("Asteroide Vermelho");
                break;
        }
    }
    //CRIAR FUNÇÃO DE DESTRUIÇÃO DE ASTEROIDES

    // Update is called once per frame
    void Update()
    {
        //Asteroides();
    }
}
