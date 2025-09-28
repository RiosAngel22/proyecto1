using UnityEngine;

public class GeneradorBalas : MonoBehaviour
{
    [SerializeField][Range(0.5f, 5f)] private float TiempoDeEspera;
    [SerializeField][Range(0.5f, 5f)] private float tiempoIntervalo;

    private ObjectPool objectPool;



    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(generarObjetoLoop), TiempoDeEspera, tiempoIntervalo);
    }

    void generarObjetoLoop()
    {
        GameObject pooledObject = objectPool.GetPooledObjects();

        if (pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = transform.rotation;
            pooledObject.SetActive(true);
        }
    }
}
