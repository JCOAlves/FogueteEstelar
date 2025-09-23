using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foguete : MonoBehaviour
{
    [SerializeField] private float deslocamentoX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Movimentacao()
    {
        //Movimentação do Foguete
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(
                transform.position.x + deslocamentoX,
                transform.position.y
            );
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(
                transform.position.x - deslocamentoX,
                transform.position.y
            );
        }
    }
    //CRIAR FUNÇÃO PARA COLISÃO COM FOGUETE
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AsteroideVerde"))
        {
            Debug.Log("Asteroide Verde destruido");
            //Destroy(gameObject);
        }
        else if (other.CompareTag("AsteroideAmarelo"))
        {
            Debug.Log("Asteroide Amarelo destruido");
        }
        else if (other.CompareTag("AsteroideVermelho")) {
            Debug.Log("Asteroide Vermelho destruido");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
}
