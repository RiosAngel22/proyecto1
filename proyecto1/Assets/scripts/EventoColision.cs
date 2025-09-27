using UnityEngine;
using UnityEngine.Events;

public class palanca : MonoBehaviour
{

    [SerializeField] private UnityEvent OnPalancaTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPalancaTriggered.Invoke();
        }
    }
}
