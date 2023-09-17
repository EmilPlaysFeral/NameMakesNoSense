using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Using Unity's UI package

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button exitPauseButton;
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked); //when button gets clicked execute the OnPauseButtonClicked function
        exitPauseButton.onClick.AddListener(OnExitPauseButtonClicked);
    }

    private void OnPauseButtonClicked()
    {
        pauseMenu.SetActive(true);
    }

    private void OnExitPauseButtonClicked()
    {
        pauseMenu.SetActive(false);
    }
}
