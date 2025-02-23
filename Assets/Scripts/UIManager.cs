using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public Button restartButton; // Referencia al bot�n de reinicio
    public Button backToMenuButton; // Referencia al bot�n de regresar al men�

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        restartButton.onClick.AddListener(ReloadGame); // Conectar el bot�n con la funci�n
        backToMenuButton.onClick.AddListener(ChangingScene); // Conectar el bot�n con la funci�n
    }

    public void ReloadGame()
    {
        GameManager.Instance.ReloadScene(); // Llamar a la funci�n del GameManager
    }

    public void ChangingScene()
    {
        GameManager.Instance.ChangeScene("Main Menu"); // Llamar a la funci�n del GameManager
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
