using UnityEngine;

public class Mover : MonoBehaviour
{

    private jugador jugador;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion = Vector2.zero;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;

    private SpriteRenderer miSprite;

    private void Awake()
    {
        jugador = GetComponent<jugador>();
    }

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);

        if (direccion.x > 0f)
        {
            miSprite.flipX = true;
        }
        else if (direccion.x < 0f)
        {
            miSprite.flipX = false;
        }


    }
    private void FixedUpdate()
    {

        miRigidbody2D.AddForce(direccion * jugador.PerfilJugador.Velocidad);
    }
}