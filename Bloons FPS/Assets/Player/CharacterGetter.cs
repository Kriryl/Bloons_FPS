using UnityEngine;

public class CharacterGetter : MonoBehaviour
{
    public Transform stores;
    public Transform characters;

    private void Start()
    {
        string characterName = PlayerPrefs.GetString(Characters.SELECTED_CHARACTER);
        string storeToken = PlayerPrefs.GetString(Characters.SELECTED_CHARACTER_STORE);

        print($"token: {storeToken}. Character: {characterName}.");

        if (string.IsNullOrEmpty(characterName) || string.IsNullOrEmpty(storeToken)) { return; }

        foreach (Transform t in characters)
        {
            print(t.name);
            print(t.name.ToLower() != characterName.ToLower());
            if (t.name.ToLower() != characterName.ToLower())
            {
                t.gameObject.SetActive(false);
            }
        }
        foreach (Transform t in stores)
        {
            print(t.name);
            print(t.name.ToLower() != storeToken.ToLower());
            if (t.name.ToLower() != storeToken.ToLower())
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
