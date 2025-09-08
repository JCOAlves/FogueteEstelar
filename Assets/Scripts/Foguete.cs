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
            Debug.Log("Para Direita");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(
                transform.position.x - deslocamentoX,
                transform.position.y
            );
            Debug.Log("Para Esquerda");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }
}
