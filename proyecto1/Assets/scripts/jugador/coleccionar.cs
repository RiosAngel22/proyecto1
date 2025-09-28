using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> coleccionables;
    [SerializeField] private GameObject bolsa;

    private bool presionado = false;

    private void Awake()
    {
        coleccionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("coleccionable")) { return; }

        GameObject nuevoColisionable = collision.gameObject;
        nuevoColisionable.SetActive(true);

        coleccionables.Add(nuevoColisionable);
        nuevoColisionable.transform.SetParent(bolsa.transform);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (coleccionables.Count == 0) return;

            presionado = !presionado;
            coleccionables[0].SetActive(presionado);
        }
    }
}
