using NUnit.Framework.Internal.Execution;
using UnityEngine;

public class GeneradorObjetoAleatorio : MonoBehaviour
{
    [SerializeField] private GameObject[] objetosPrefabs;

    [SerializeField][Range(0.5f, 5f)] private float tiempoEspera;
    [SerializeField][Range(0.5f, 5f)] private float tiempoIntervalo;

    private ObjectPool objectPool;
    bool HayObjectPool = false;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
        if (objectPool != null) {
            HayObjectPool=true;
        }
    }

    void Start()
    {
        if (!HayObjectPool)
        {

            InvokeRepeating(nameof(GenerarObjetoAleatorioNoPooling), tiempoEspera, tiempoIntervalo);

        }

        else
        {

            InvokeRepeating(nameof(GenerarObjetoPooled), tiempoEspera, tiempoIntervalo);

        }
    }

    void GenerarObjetoAleatorioNoPooling()
    {
        int IndexAleatorio = Random.Range(0,objetosPrefabs.Length);
        GameObject prefabAleatorio = objetosPrefabs[IndexAleatorio];
        Instantiate(prefabAleatorio, transform.position, Quaternion.identity);
    }

    void GenerarObjetoPooled()
    {
        GameObject obj = objectPool.GetPooledObjects();

        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
        }
    }

    private void OnBecameInvisible()
    {
        if (HayObjectPool)
        {
            CancelInvoke(nameof(GenerarObjetoPooled));
        }
        else
        {
            CancelInvoke(nameof(GenerarObjetoAleatorioNoPooling));
        }
    }

    private void OnBecameVisible()
    {
        if (HayObjectPool)
        {
            InvokeRepeating(nameof(GenerarObjetoPooled), tiempoEspera, tiempoIntervalo);
        }
        else
        {
            InvokeRepeating(nameof(GenerarObjetoAleatorioNoPooling), tiempoEspera, tiempoIntervalo);
        }
    }
}
