using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador" )]

public class PerfilJugador : ScriptableObject
{
    [SerializeField] private int vida = 5;
    public int Vida { get => vida; }


    //movimiento
    [SerializeField] float velocidad = 5f;
    public float Velocidad { get => velocidad;}

    [SerializeField] private float fuerzaSalto = 5f;
    public float FuerzaSalto { get => fuerzaSalto;}
    //movimiento

    //nivelar
    private int nivel;
    public int Nivel { get => nivel; set => nivel = value; }


    private int experiencia;
    public int Experiencia { get => experiencia; set => experiencia = value; }


    [Tooltip("Rango de experiencia necesaria para el proximo nivel 10 a 50")]
    [SerializeField][Range(10, 50)] private int experienciaProximoNivel;
    public int ExperienciaProximoNivel { get => experienciaProximoNivel; set => experienciaProximoNivel = value; }

    [Tooltip("Como aumenta la experiencia nivel a nivel")]
    [SerializeField][Range(10, 2000)] private int escalarExperiencia;
    public int EscalarExperiencia { get => escalarExperiencia; set => escalarExperiencia = value; }
    //nivelar

}
