using UnityEngine;
using UnityEngine.SceneManagement;

public class AplicationManager : MonoBehaviour
{
    public static AplicationManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IrAProximaEscena()
    {
        int EscenaActual = SceneManager.GetActiveScene().buildIndex;
        int ProximaEscena = EscenaActual + 1;

        if (ProximaEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(ProximaEscena);
        }
        else {
            Debug.Log("no hay mas escenas en la build");
        }
    }

    public void IrAEscenaAnterior()
    {
        int EscenaActual = SceneManager.GetActiveScene().buildIndex;
        int EscenaAnterior = EscenaActual - 1;

        if (EscenaAnterior >= 0)
        {
            SceneManager.LoadScene(EscenaAnterior);
        }
        else
        {
            Debug.Log("no hay escena anterior");
        }
    }
}
