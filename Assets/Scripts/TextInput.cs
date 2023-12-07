using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;
    private GameController gameController;
    private void Awake()
    {
        gameController = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);     
    }
    private void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        gameController.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        for(int i = 0; i < gameController.inputActions.Length; i++)
        {
            InputAction inputAction = gameController.inputActions[i];
            if(inputAction.keyWord == seperatedInputWords[0]) 
            {
                inputAction.RespondToInput(gameController , seperatedInputWords);
            }
        }


        InputComplete();
    }

    private void InputComplete()
    {
        gameController.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = string.Empty;
    }
}
