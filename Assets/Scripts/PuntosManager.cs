using TMPro;
using UnityEngine;

public class PuntosManager : MonoBehaviour
{
    public static PuntosManager instancia;
    public TMP_Text puntosText;
    private int puntos;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        puntos = 0;
        ActualizarUI();
    }

    public void AgregarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    public void QuitarPuntos(int cantidad)
    {
        puntos -= cantidad;
        if (puntos < 0) puntos = 0;
        ActualizarUI();
    }

    public void SetPuntos(int cantidad)
    {
        puntos = cantidad;
        if (puntos < 0) puntos = 0;
        ActualizarUI();
    }

    public int GetPuntos()
    {
        return puntos;
    }

    private void ActualizarUI()
    {
        if (puntosText != null)
        {
            puntosText.text = $"Puntos: {puntos}";
        }
    }
}
