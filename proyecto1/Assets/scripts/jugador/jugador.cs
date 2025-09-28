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

    private int vida;

    [Header("Configuracion")]
    [SerializeField] private UnityEvent<int> onLifeChanged;
    [SerializeField] private UnityEvent<string> onTextChanged;


    private void Awake()
    {
        vida = perfilJugador.Vida;
        onLifeChanged.Invoke(vida);
        onTextChanged.Invoke(GameManager.instance.getScore().ToString());
    }

    private bool vivo()
    {
        return perfilJugador.Vida > 0;
    }

    public void ModificarVida(int puntos)
    {
        vida += puntos;
        GameManager.instance.AddScore(puntos * 100);
        onLifeChanged.Invoke(vida);
        onTextChanged.Invoke(GameManager.instance.getScore().ToString());
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {

        if ((!colision.gameObject.CompareTag("Meta")) || !vivo()) { return; }

        Debug.Log("victoria");
    }
}
