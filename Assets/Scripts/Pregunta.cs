using UnityEngine;

public class Pregunta 
{
    public string enunciado;
    public string[] opciones;
    public int indiceCorrecto;

    public Pregunta(string enunciado, string[] opciones, int indiceCorrecto)
    {
        this.enunciado = enunciado;
        this.opciones = opciones;
        this.indiceCorrecto = indiceCorrecto;
    }
}
