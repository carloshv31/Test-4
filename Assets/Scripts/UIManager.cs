using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton; // Referencia al botón de reinicio
    public Button backToMenuButton; // Referencia al botón de regresar al menú

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.onClick.AddListener(ReloadGame); // Conectar el botón con la función
        backToMenuButton.onClick.AddListener(ChangingScene); // Conectar el botón con la función
    }

    public void ReloadGame()
    {
        GameManager.Instance.ReloadScene(); // Llamar a la función del GameManager
    }

    public void ChangingScene()
    {
        GameManager.Instance.ChangeScene("Main Menu"); // Llamar a la función del GameManager
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
        }
    }
}
