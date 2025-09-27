using UnityEngine;
using TMPro;
using UnityEditor;
using Unity.VisualScripting;

public class TextoDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject ContenedorDeVidas;

    public void setTexto(string texto)
    {
        miTexto.text = texto;
    }

    public void actualizarVidasHud(int vidas)
    {
        if (estaVacioContenedor())
        {
            CargarVidas(vidas);
            return;
        }

        if (cargarContenedorVidas() > vidas)
        {
            eliminarUltimoIcono();
        }
        else
        {
            crearIcono();
        }
    }

    private void eliminarUltimoIcono()
    {
        Transform contenedor = ContenedorDeVidas.transform;
        Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private int cargarContenedorVidas()
    {
        return ContenedorDeVidas.transform.childCount;
    }

    private bool estaVacioContenedor()
    {
        return ContenedorDeVidas.transform.childCount == 0;
    }

    private void CargarVidas(int vidas)
    {
        for (int i = 0; i < vidas; i++)
        {
            crearIcono();
        }
    }

    private void crearIcono()
    {
        Instantiate(iconoVida, ContenedorDeVidas.transform);
    }
}
