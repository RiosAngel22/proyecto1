using System;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    [SerializeField] private GameObject bolsa;
    [SerializeField] private Transform padreObjetivos;

    private Queue<GameObject> objetivos;
    private Stack<GameObject> items;
    private Dictionary<string, GameObject> inventario;

    private jugador jugador;
    private progresion progresion;


    private void Awake()
    {
        objetivos = new Queue<GameObject>();
        items = new Stack<GameObject>();
        inventario = new Dictionary<string, GameObject>();

        CargarObjetivo();
        VerObjetivos();

        jugador = GetComponent<jugador>();
        progresion = GetComponent <progresion>();
    }

    private void CargarObjetivo()
    {
        foreach (Transform objetivo in padreObjetivos)
        {
            objetivos.Enqueue(objetivo.gameObject);
        }
    }

    private void VerObjetivos()
    {
        foreach (GameObject objetivo in objetivos)
        {
            Debug.Log(objetivo.name);
        }
    }

    private bool EsObjetivoActual(GameObject objetivoActual, GameObject objetivoReal)
    {
        return objetivoActual == objetivoReal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("coleccionable")) { return; }
        if (objetivos.Count == 0) { return;  }

        GameObject objetivo = objetivos.Peek();

        if (EsObjetivoActual(collision.gameObject, objetivo))
        {

            objetivo.SetActive(false);
            objetivos.Dequeue();

            items.Push(objetivo);
            inventario.Add(objetivo.name,objetivo);

            VerObjetivos();
            objetivo.transform.SetParent(bolsa.transform);

            progresion.GanarExperiencia(10);
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.F1))
        {
            if (items.Count == 0) { return; }

            usarItem();
        }*/

        if ((Input.GetKeyDown(KeyCode.F1)) && inventario.ContainsKey("hongo"))
        {
            UsarInventario(inventario["hongo"]);
            Debug.Log(jugador.PerfilJugador.Nivel);
        }
        if ((Input.GetKeyDown(KeyCode.F2)) && inventario.ContainsKey("diamante")) 
        { 
            UsarInventario(inventario["diamante"]);
            Debug.Log(jugador.PerfilJugador.Nivel);
        }
        if ((Input.GetKeyDown(KeyCode.F3)) && inventario.ContainsKey("HombreDeNieve"))
        {
            UsarInventario(inventario["HombreDeNieve"]);
            Debug.Log(jugador.PerfilJugador.Nivel);
        }

    }

    private void usarItem()
    {
        GameObject item = items.Pop();
        item.transform.SetParent(null);
        item.SetActive(true);
    }

    private void UsarInventario(GameObject item)
    {
        item.transform.SetParent(null);
        item.transform.position = transform.position;
        item.SetActive(true);
    }
}
