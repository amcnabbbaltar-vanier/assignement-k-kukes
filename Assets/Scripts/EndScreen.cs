using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public Text finalScoreText;
    public Text finalTimeText;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            finalScoreText.text = "Final Score: " + GameManager.Instance.score;
            finalTimeText.text = "Total Time: " + Mathf.FloorToInt(GameManager.Instance.timer);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.score = 0;
            GameManager.Instance.timer = 0f;
            GameManager.Instance.health = 3;
        }

        SceneManager.LoadScene(1);
    }
}
