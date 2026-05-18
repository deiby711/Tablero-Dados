using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPreguntaManager : MonoBehaviour
{
    public static UIPreguntaManager instance { get; private set; }
    public TMP_Text preguntaText;
    public Button[] botonesOpciones;
    public Canvas canvas;
    private Pregunta preguntaActual;

    void Awake()
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

        canvas.gameObject.SetActive(false);
    }
    public void VerificarRespuesta(int index)
    {
        if (index == preguntaActual.indiceCorrecto)
        {
            // Respuesta correcta: sumar puntos y continuar
            PuntosManager.instancia?.AgregarPuntos(10);
            PlayerManager.instancia.mover = true;
            canvas.gameObject.SetActive(false);
        }
        else
        {
            // Respuesta incorrecta: restar puntos, reiniciar posición y continuar
            PuntosManager.instancia?.QuitarPuntos(5);
            PlayerManager.instancia.pasosRestantes = 1;
            PlayerManager.instancia.posicionPunto = 0;
            PlayerManager.instancia.mover = true;
            canvas.gameObject.SetActive(false);
        }
    }

    public void MostrarPregunta(Pregunta pregunta)
    {
        canvas.gameObject.SetActive(true);
        preguntaText.text = pregunta.enunciado;
        preguntaActual = pregunta;

        for (int i = 0; i < botonesOpciones.Length; i++)
        {
            int index = i;
            botonesOpciones[i].GetComponentInChildren<TMP_Text>().text = pregunta.opciones[i];
            botonesOpciones[i].onClick.RemoveAllListeners();
            botonesOpciones[i].onClick.AddListener(() => VerificarRespuesta(index));
        }
    }
}