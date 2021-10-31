using System;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public Character[] characters;
    private Character selectedCharacter;

    public BaseUpgrade BaseUpgrade => selectedCharacter.character;

    public string CharacterName
    {
        get
        {
            if (selectedCharacter != null)
            {
                return selectedCharacter.name;
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
        public string name = string.Empty;

        public static void Equals()
        { }
    }

    public void SelectCharacter(string refrenceName)
    {
        foreach (Character character in characters)
        {
            if (refrenceName.ToLower() == character.name.ToLower())
            {
                selectedCharacter = character;
                break;
            }
        }
    }
}
