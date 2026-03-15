using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public Text timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;
            healthText.text = "Health: " + GameManager.Instance.health;
            timerText.text = "Time: " + Mathf.FloorToInt(GameManager.Instance.timer);
        }
    }
}
