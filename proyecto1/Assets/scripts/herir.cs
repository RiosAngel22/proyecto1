using UnityEngine;


public class Herir : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] int puntos = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador Jugador = collision.gameObject.GetComponent<jugador>();
            Jugador.ModificarVida(-puntos);
        }
    }
}