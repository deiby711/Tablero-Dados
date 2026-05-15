using System.Collections.Generic;
using UnityEngine;

public class PreguntaManager 
{
    public static PreguntaManager instancia = new PreguntaManager();
    private Dictionary<string, List<Pregunta>> preguntas = new Dictionary<string, List<Pregunta>>();

    public PreguntaManager()
    {
        instancia = this;
        preguntas["Matematicas"] = new List<Pregunta>();
        preguntas["Historia"] = new List<Pregunta>();
        PreguntaAdd();
    }

    public void PreguntaAdd()
    {
        preguntas["Matematicas"].Add(new Pregunta("La suma de 5+5 es:",
            new string[] { "15", "10", "25" }, 1));
        preguntas["Matematicas"].Add(new Pregunta("El resultado de la división 25 / 5",
            new string[] { "5", "6", "4" }, 0));
        preguntas["Matematicas"].Add(new Pregunta("El resultado de multiplicar 7 * 7",
            new string[] { "42", "35", "49" }, 2));

        //Ciencias sociales
        preguntas["Historia"].Add(new Pregunta("¿Quién fue el primer presidente de los Estados Unidos?",
            new string[] { "George Washington", "Abraham Lincoln", "Thomas Jefferson" }, 0));
        preguntas["Historia"].Add(new Pregunta("¿En qué año comenzó la Segunda Guerra Mundial?",
            new string[] { "1939", "1941", "1945" }, 0));
        preguntas["Historia"].Add(new Pregunta("¿Cuál fue la civilización que construyó las pirámides de Egipto?",
            new string[] { "Los romanos", "Los egipcios", "Los griegos" }, 1));
    }

    public Pregunta ObtenerPreguntaAleatoria(string index)
    {
        return preguntas[index][Random.Range(0, preguntas[index].Count)];
    }
}
