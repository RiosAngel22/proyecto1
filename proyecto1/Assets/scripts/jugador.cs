using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;
    [SerializeField] private TMPro.TMP_Text texto;

    //barra de vida
    [SerializeField] private Image Imagen;
    [SerializeField] private Image Imagen2;

    //puntero
    [SerializeField] private Image puntero;
    [SerializeField] private GameObject meta;


    //pantalla final
    [SerializeField] private GameObject PantallaFinal;
    [SerializeField] private Button boton;


    private void OnEnable()
    {
        var tamaño = Imagen2.transform as RectTransform;
        tamaño.sizeDelta = new Vector2(vida*0.95f, tamaño.sizeDelta.y);
        PantallaFinal.SetActive(false);
    }
    
    public void OnClick()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("SampleScene");
    }

    private void FixedUpdate()
    {
        texto.SetText(vida+"%");
        var tamaño = Imagen.transform as RectTransform;
        tamaño.sizeDelta = new Vector2(vida*0.95f,tamaño.sizeDelta.y);

        float angulo = Mathf.Atan2(meta.transform.position.y - transform.position.y, meta.transform.position.x - transform.position.x);
        float anguloCorregido = angulo * 180 / Mathf.PI;
        puntero.transform.rotation = Quaternion.Euler(0, 0, anguloCorregido);

        if (!vivo())
        {
            PantallaFinal.SetActive(true);
        }
    }

    private bool vivo()
    {
        return vida > 0;
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (!colision.gameObject.CompareTag("Meta")) { return; }

        if (vivo())
        {
            PantallaFinal.SetActive(true);
            PantallaFinal.GetComponent<Image>().color = Color.green;
            PantallaFinal.GetComponentInChildren<TMPro.TMP_Text>().SetText("Victoria");
        }
    }
}
