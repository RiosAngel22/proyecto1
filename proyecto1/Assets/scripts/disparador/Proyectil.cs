using UnityEngine;

public class Proyectil : MonoBehaviour
{
    [SerializeField][Range(1f, 30f)] private float velocidad = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Mover();
    }

    private void Mover()
    {
        Vector2 direccion = Vector2.left;
        rb.linearVelocity = direccion * velocidad;
    }
}
