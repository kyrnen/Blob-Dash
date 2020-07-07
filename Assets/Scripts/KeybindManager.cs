using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeybindManager : MonoBehaviour
{
    public static KeybindManager instance;
    bool gameStart;
    private string bindName;
    public static Dictionary<string, KeyCode> keybindings { get; private set; }

    public static KeybindManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        keybindings = new Dictionary<string, KeyCode>();
    }

    private void Start()
    {
        BindKey("UP", KeyCode.W);
        BindKey("LEFT", KeyCode.A);
        BindKey("DOWN", KeyCode.S);
        BindKey("RIGHT", KeyCode.D);
    }

    public void BindKey(string key, KeyCode keybind)
    {
        Dictionary<string, KeyCode> currentDictionary = keybindings;

        if(!currentDictionary.ContainsKey(key))
        {
            currentDictionary.Add(key, keybind);
            UIManager.Instance.UpdateKeyText(key, keybind);
        }
        else if (currentDictionary.ContainsValue(keybind))
        {
            string myKey = currentDictionary.FirstOrDefault(x => x.Value == keybind).Key;
            currentDictionary[myKey] = KeyCode.None;
            UIManager.Instance.UpdateKeyText(key, keybind);
        }

        currentDictionary[key] = keybind;
        bindName = string.Empty;
    }

    public void KeyBindOnClick(string bindName)
    {
        this.bindName = bindName;
    }

    private void OnGUI()
    {
        if(bindName != string.Empty)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                BindKey(bindName, e.keyCode);
            }
        }
    }

    public KeyCode GetKeyFor(string key)
    {
        return keybindings[key];
    }
}
