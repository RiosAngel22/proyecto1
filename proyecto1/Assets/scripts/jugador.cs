using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class jugador : MonoBehaviour
{
    [SerializeField] PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; set => perfilJugador = value; }

    [Header("Configuracion")]
    [SerializeField] private UnityEvent<int> onLifeChanged;
    [SerializeField] private UnityEvent<string> onTextChanged;


    private void OnEnable()
    {
        onLifeChanged.Invoke(perfilJugador.Vida);
        onTextChanged.Invoke(perfilJugador.Vida.ToString());
    }
    
    public void OnClick()
    {
        SceneManager.LoadScene("Escena1");
    }

    private bool vivo()
    {
        return perfilJugador.Vida > 0;
    }

    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        onLifeChanged.Invoke(perfilJugador.Vida);
        onTextChanged.Invoke(perfilJugador.Vida.ToString());
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {

        if (!colision.gameObject.CompareTag("Meta")) { return; }

        Debug.Log("victoria");
    }
}
