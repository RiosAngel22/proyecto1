using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;

    [SerializeField][Range(0.5f, 5f)] private float tiempoEspera;

    void Start()
    {
        Invoke(nameof(GenerarObjeto), tiempoEspera);
    }

    void GenerarObjeto()
    {
        Instantiate(objetoPrefab,transform.position,Quaternion.identity);
    }
}
