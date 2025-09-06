using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    [SerializeField] private TMPro.TMP_Text texto;
    [SerializeField] private Image Imagen;
    [SerializeField] private Image Imagen2;

    [SerializeField] private Image puntero;
    [SerializeField] private GameObject meta;

    private void OnEnable()
    {
        var tamaño = Imagen2.transform as RectTransform;
        tamaño.sizeDelta = new Vector2(vida, tamaño.sizeDelta.y);
    }

    private void FixedUpdate()
    {
        texto.SetText(vida+"%");
        var tamaño = Imagen.transform as RectTransform;
        tamaño.sizeDelta = new Vector2(vida,tamaño.sizeDelta.y);

        float angulo = Mathf.Atan2(meta.transform.position.y - transform.position.y, meta.transform.position.x - transform.position.x);
        float anguloCorregido = angulo * 180 / Mathf.PI;
        puntero.transform.rotation = Quaternion.Euler(0, 0, anguloCorregido);
    }


    public void ModificarVida(float puntos)
    {
        vida += puntos;
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (!colision.gameObject.CompareTag("Meta")) { return; }
        Debug.Log("GANASTE");
    }
}
