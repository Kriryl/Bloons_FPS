using System;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public const string SELECTED_CHARACTER = "Selected character";
    public const string SELECTED_CHARACTER_STORE = "Store";

    public GameObject characterButton;

    public Character[] characters;

    public BaseUpgrade BaseUpgrade => SelectedCharacter.character;

    public Character SelectedCharacter { get; private set; }

    private bool setCharacterButton = true;

    public string CharacterName
    {
        get
        {
            if (SelectedCharacter != null)
            {
                return SelectedCharacter.name;
            }
            else
            {
                return "Undefined";
            }
        }
    }

    [Serializable]
    public class Character
    {
        public BaseUpgrade character;
        public GameObject store;
        public string storeToken = "";
        public string name = string.Empty;
    }

    public void ToggleCharacters()
    {
        characterButton.SetActive(setCharacterButton);
        setCharacterButton = !setCharacterButton;
    }

    public void SelectCharacter(string refrenceName)
    {
        string token = "";

        foreach (Character character in characters)
        {
            if (refrenceName.ToLower() == character.name.ToLower())
            {
                SelectedCharacter = character;
                token = character.storeToken;
                break;
            }
        }
        if (SelectedCharacter != null)
        {
            PlayerPrefs.SetString(SELECTED_CHARACTER, refrenceName);
            PlayerPrefs.SetString(SELECTED_CHARACTER_STORE, token);
        }
    }
}
