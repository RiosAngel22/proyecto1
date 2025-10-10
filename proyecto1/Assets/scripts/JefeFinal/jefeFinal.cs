using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class jefeFinal : MonoBehaviour
{
    [SerializeField] float tiempoEntreDisparos;
    [SerializeField] float tiempoEntreEmbestidas;
    [SerializeField] float tiempoEntreMovimientos;

    [SerializeField] Transform puntoSpawnProyectil;

    private float tiempoActualEspera;
    private int estadoActual;

    private const int DispararProyectil = 0;
    private const int Embestir = 1;
    private const int Mover = 2;

    ObjectPool pool;
    private void Start()
    {
        estadoActual = DispararProyectil;
        StartCoroutine(ComportamientoJefe());
        pool = GetComponent<ObjectPool>();
    }

    private IEnumerator ComportamientoJefe()
    {
        while (true)
        {
            switch (estadoActual)
            {
                case DispararProyectil:
                    StartCoroutine(Disparar());
                    tiempoActualEspera = tiempoEntreDisparos;
                    break;
                case Embestir:
                    StartCoroutine(Embestida());
                    tiempoActualEspera = tiempoEntreEmbestidas;
                    break;
                case Mover:
                    StartCoroutine(Movimiento());
                    tiempoActualEspera = tiempoEntreMovimientos;
                    break;
            }

            Debug.Log(estadoActual);
            yield return new WaitForSeconds(tiempoActualEspera);
            ActualizarEstado();

        }


    }

    private IEnumerator Disparar()
    {
        for (int i = 0; i < pool.Poolsize; i++)
        {
            GameObject pooledObject = pool.GetPooledObjects();

            yield return new WaitForSeconds(0.5f);

            if (pooledObject != null)
            {
                pooledObject.transform.position = transform.position;
                pooledObject.transform.rotation = transform.rotation;
                pooledObject.SetActive(true);
            }
        }
    }

    private IEnumerator Embestida()
    {
        float tiempoEmbestida = 2f;
        float tiempoInicio = Time.time;
        float VelocidadEmbestida = -10f;

        Vector2 PosicionInicial = transform.position;
        Vector2 PosicionObjeto = new Vector2(transform.position.x + VelocidadEmbestida,transform.position.y);

        //mover hacia adelante
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(PosicionInicial, PosicionObjeto, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }

        //mover hacia atras
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(PosicionObjeto, PosicionInicial, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }



    }

    private IEnumerator Movimiento()
    {
        float tiempoMovimiento = 3f;
        float tiempoInicio = Time.time;
        float velocidadMovimiento = 6f;

        Vector2 PosicionInicial = transform.position;
        Vector2 PosicionObjeto = new Vector2(transform.position.x, transform.position.y + velocidadMovimiento);
    
        //mover hacia la posicionObjetivo
        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(PosicionInicial,PosicionObjeto, (Time.time - tiempoInicio) / (tiempoMovimiento/ 2));
            yield return null;
        }

        tiempoInicio = Time.time;

        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(PosicionObjeto, PosicionInicial, (Time.time - tiempoInicio) / (tiempoMovimiento / 2));
            yield return null;
        }

    }

    private void ActualizarEstado()
    {
        estadoActual = UnityEngine.Random.Range(0, 3);
    }
}
