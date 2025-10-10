using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private Color colorNoche;
    [SerializeField] private Light2D luz2d;

    [SerializeField][Range(4, 128)] private int duracionDia;
    [SerializeField][Range(4, 24)] private int dias;



    private Color colorDia;

    void Start()
    {
        colorDia = camara.backgroundColor;
        StartCoroutine(CambiarColor(duracionDia));
    }

    IEnumerator CambiarColor(float tiempo)
    {
        Color colorDestino = camara.backgroundColor == colorDia ? colorNoche : colorDia;
        Color colorDestinoLuz = luz2d.color != Color.white ? Color.white : colorNoche;

        float duracionCiclo = tiempo * 0.06f;
        float duracionCambio = tiempo * 0.04f;

        for (int i = 0; i < dias; i++) {
            yield return new WaitForSeconds(duracionCiclo);

            float tiempoTranscurrido = 0;

            while (tiempoTranscurrido < duracionCambio)
            {
                tiempoTranscurrido += Time.deltaTime;
                float t = tiempoTranscurrido / duracionCambio;

                float SmoothT = Mathf.SmoothStep(0f, 1f, t);
                camara.backgroundColor = Color.Lerp(camara.backgroundColor,colorDestino, SmoothT);
                luz2d.color = Color.Lerp(luz2d.color,colorDestinoLuz,SmoothT);

                yield return null;
            }

            colorDestino = camara.backgroundColor == colorDia ? colorNoche : colorDia;
            colorDestinoLuz = luz2d.color != Color.white ? Color.white : colorNoche;

        }
    }

}
