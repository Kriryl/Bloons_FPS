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
            if (t.name.ToLower() != characterName.ToLower())
            {
                t.gameObject.SetActive(false);
            }
        }
        foreach (Transform t in stores)
        {
            if (t.name.ToLower() != storeToken.ToLower())
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
