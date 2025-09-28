using UnityEngine;

public class Saltar : MonoBehaviour
{
    private jugador jugador;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;

    private void Awake()
    {
        jugador = GetComponent<jugador>();
    }

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * jugador.PerfilJugador.FuerzaSalto, ForceMode2D.Impulse);
            saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
        saltando = false;
    }

    //Arreglamos el doble salto en trampolin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trampolin"))
        {
            puedoSaltar = true;
            saltando = false;
        }
    }

}