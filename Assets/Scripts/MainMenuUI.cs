using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button playGameButton;

    // Start is called before the first frame update
    void Start()
    {
        playGameButton.onClick.AddListener(NextScene);
    }

    public void NextScene()
    {
        GameManager.Instance.ChangeScene("Prototype 4"); // Llamar a la función del GameManager
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MenuButtonPressed()
    {
        AudioManager.Instance.PlaySFX("Button");
    }
}
