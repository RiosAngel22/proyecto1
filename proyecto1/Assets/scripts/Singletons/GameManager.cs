using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance { get; private set; }

    private int score = 1000;

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

    public void AddScore(int puntos)
    {
        score += puntos;

        if (score < 500) {
            AplicationManager.instance.IrAEscenaAnterior();
            resetScore();
        }
    }
    public void resetScore()
    {
        score = 1000;
    }

    public int getScore()
    {
        return score;
    }
}
