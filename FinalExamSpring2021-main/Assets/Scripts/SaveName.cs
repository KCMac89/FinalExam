using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public InputField nameInput;

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("name", nameInput.text);
    }
}
