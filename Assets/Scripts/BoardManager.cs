using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager instance;

    void Awake()
    {
        instance = this;
    }

    public bool VerificarCasilla(int posicion)
    {
        switch (posicion)
        {
            case 6:
                Pregunta pregunta = PreguntaManager.instancia
                    .ObtenerPreguntaAleatoria("Matematicas");
                UIPreguntaManager.instance.MostrarPregunta(pregunta);
                return true;
            case 16:
                Pregunta pregunta2 = PreguntaManager.instancia
                    .ObtenerPreguntaAleatoria("Historia");
                UIPreguntaManager.instance.MostrarPregunta(pregunta2);
                return true;
        }
        return false;
    }
}