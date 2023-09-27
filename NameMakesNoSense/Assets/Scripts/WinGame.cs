using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button exitGameButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None; //Locks the cursor
                                                    //Cursor.visible = true; //ChatGPT gjorde denna också förutom min, testa med min egna först sen detta
            winMenu.SetActive(true);
        }
    }

    void Start()
    {
        restartGameButton.onClick.AddListener(OnRestartGameButtonClicked); //when button gets clicked execute the OnPauseButtonClicked function
        exitGameButton.onClick.AddListener(OnExitGameButtonClicked);
    }

    private void OnRestartGameButtonClicked() //Restarta spelet, just nu genom att ladda om scenen
    {
        ReloadScene();
    }

    private void OnExitGameButtonClicked() //Testa i utbyggd version
    {
        QuitGame();
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
