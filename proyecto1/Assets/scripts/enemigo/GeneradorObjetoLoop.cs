using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;

    [SerializeField][Range(0.5f, 5f)] private float tiempoEspera;
    [SerializeField][Range(0.5f, 5f)] private float tiempoIntervalo;

    void Start()
    {
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
    }

    void GenerarObjeto()
    {
        Instantiate(objetoPrefab, transform.position, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke(nameof(GenerarObjeto));
    }

    private void OnBecameVisible()
    {
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
    }
}
