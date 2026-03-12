using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // print("pressed");
            if(isPause){
                ContinueGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }

    public void ContinueGame(){
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void QuitGame(){
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
