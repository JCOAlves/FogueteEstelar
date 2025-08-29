using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject estrelasFundo, pontoEstrelas, pontoDestroi;
    public static GameController instance;
    private float interval = 1f;

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
        InvokeRepeating("QuedaEstrelas", 0f, interval);
    }

    private void QuedaEstrelas()
    {
        if (estrelasFundo != null && pontoEstrelas != null)
        {
            Instantiate(
                estrelasFundo,
                pontoEstrelas.transform.position,
                Quaternion.identity
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
