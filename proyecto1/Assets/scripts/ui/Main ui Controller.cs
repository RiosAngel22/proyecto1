using UnityEngine;
using UnityEngine.SceneManagement;

public class MainuiController : MonoBehaviour
{
    public void CargarSiguienteEscena()
    {
        AplicationManager.instance.IrAProximaEscena();
    }
}
