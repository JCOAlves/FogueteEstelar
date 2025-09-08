using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject estrelasFundo, pontoEstrelas, pontoDestroi;
    [SerializeField] private GameObject mensagemInicial, botaoStart, setasIndicativas;
    public static GameController instance;
    private bool started;

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
        IniciacaoJogo();
    }


    // Update is called once per frame
    void Update()
    {
        IniciacaoJogo();
        ReniciacaoJogo();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("estrelasFundo"))
        {
            Debug.Log("Estrelas destruidas.");
            Destroy(gameObject);
        }
    }
}

/*
ANOTAÇÕES PARA FUNÇÕES:

float randomY = Random.Range(-2f, 2f);
transform.position = new Vector2(transform.position.x, randomY);

yVariable = Random.Range(-1, 5) < 0; //Probabilidade de oscilar os pilares
if (yVariable)
{
    OscilateY();
}

*/
