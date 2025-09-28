using System;
using UnityEngine;
using UnityEngine.Rendering;

public class progresion : MonoBehaviour
{
    private jugador jugador;

    private void Awake()
    {
        jugador = GetComponent<jugador>();
    }

    public void GanarExperiencia(int nuevaExperiencia)
    {
        jugador.PerfilJugador.Experiencia += nuevaExperiencia;

        if (jugador.PerfilJugador.Experiencia >= jugador.PerfilJugador.ExperienciaProximoNivel)
        {
            subirNivel();
        }
    }

    private void subirNivel()
    {
        jugador.PerfilJugador.Nivel++;
        jugador.PerfilJugador.Experiencia -= jugador.PerfilJugador.ExperienciaProximoNivel;
        jugador.PerfilJugador.ExperienciaProximoNivel += jugador.PerfilJugador.EscalarExperiencia;
    }
}
