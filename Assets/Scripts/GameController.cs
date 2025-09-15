using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pontoAsteroides, pontoDestroi;
    [SerializeField] private GameObject mensagemInicial, botaoStart, setasIndicativas;
    [SerializeField] private GameObject AsteroideVerde, AsteroideAmarelo, AsteroideVermelho;
    public static GameController instance;
    private bool started;
    [SerializeField] private float intervalo;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroi outras instacias com Gamecontroller. Só pode haver um objeto GameController.
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        IniciacaoJogo();
    }
    private void IniciacaoJogo()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !started)
        {
            if (mensagemInicial.activeSelf || botaoStart.activeSelf || setasIndicativas.activeSelf) //activeSelf verifica se o objeto estar na cena.
            {
                mensagemInicial.SetActive(false); //Retira o elemento da cena, mas não o destroi
                botaoStart.SetActive(false);
                setasIndicativas.SetActive(false);
            }
            started = true;
            Debug.Log("Foguete Estelar Iniciado!");

            //InvokeRepeating([nome da função entre aspas], [tempo em segundos para começar a função], [intevalo de repetição em segundos]);
            InvokeRepeating("Asteroides", 1f, intervalo); 
        }
    }

    private void Asteroides()
    {
        List<string> listaAsteroides = new List<string> { "Verde", "Amarelo", "Vermelho" };
        int posicaoAsteroide = Random.Range(0, 3);
        string AsteroideEscolhido = listaAsteroides[posicaoAsteroide];
        float posicaoX = Random.Range(-10f, 10f);
        float posicaoY = pontoAsteroides.transform.position.y;
        //intervalo = intervalo - 0.1f;

        //FAZER OS ASTEROIDES APARECEREM MAIS DE UM EM UM COM LOOP
        switch (AsteroideEscolhido)
        {
            case "Verde":
                Instantiate(
                    AsteroideVerde, //Instancia do asteroide
                    new Vector2(posicaoX, posicaoY), //Na posição (posicaoX, posicaoY)
                    Quaternion.identity  //Com rotação padrão (sem rotação, identidade)
                );
                Debug.Log("Asteroide Verde");
                break;
            case "Amarelo":
                Instantiate(
                    AsteroideAmarelo,
                    new Vector2(posicaoX, posicaoY),
                    Quaternion.identity
                );
                Debug.Log("Asteroide Amarelo");
                break;
            case "Vermelho":
                Instantiate(
                    AsteroideVermelho,
                    new Vector2(posicaoX, posicaoY),
                    Quaternion.identity
                );
                Debug.Log("Asteroide Vermelho");
                break;
        }
    }

    private void ReniciacaoJogo()
    {
        if (Input.GetKeyDown(KeyCode.R) && !started)
        {
            if (!mensagemInicial.activeSelf || !botaoStart.activeSelf || !setasIndicativas.activeSelf)
            {
                mensagemInicial.SetActive(true);
                botaoStart.SetActive(true);
                setasIndicativas.SetActive(true);
            }
            started = true;
            Debug.Log("Foguete Estelar Reiniciado!");
        }
    }
}