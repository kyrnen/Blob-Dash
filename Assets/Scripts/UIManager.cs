using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    private GameObject[] keybindButtons;
    public GameObject options;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
        options.SetActive(false);
    }

    public void UpdateKeyText(string key, KeyCode keybind)
    {
        Text tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<Text>();
        tmp.text = keybind.ToString();
    }
}
