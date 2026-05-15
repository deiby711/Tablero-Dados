using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DadoManager : MonoBehaviour
{
    public Sprite[] diceFaces;
    public Image diceImage;
    public float rollDuration = 1f;
    private bool isRolling = false;

    public void OnDiceClicked()
    {
        if (!isRolling)
        {
            StartCoroutine(RollDice());
        }
    }

    IEnumerator RollDice()
    {
        isRolling = true;
        float elapsedTime = 0f;

        while (elapsedTime < rollDuration)
        {
            diceImage.sprite = diceFaces[Random.Range(0, diceFaces.Length)];
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        int numeroDado = Random.Range(1, 7);
        diceImage.sprite = diceFaces[numeroDado - 1];
        PlayerManager.instancia.pasosRestantes = numeroDado + 1;
        PlayerManager.instancia.mover = true;
        isRolling = false;
    }
}