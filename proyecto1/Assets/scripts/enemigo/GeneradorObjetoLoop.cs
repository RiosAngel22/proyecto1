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
        Debug.Log("El SpriteRenderer deja de ser visible por las camaras de la escena");
        CancelInvoke(nameof(GenerarObjeto));
    }

    private void OnBecameVisible()
    {
        Debug.Log("El SpriteRenderer se vuelve visible para las camaras de la escena");
        InvokeRepeating(nameof(GenerarObjeto), tiempoEspera, tiempoIntervalo);
    }
}
