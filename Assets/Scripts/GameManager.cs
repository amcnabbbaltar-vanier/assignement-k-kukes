using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public int health = 3;
    public float timer = 0f;

    public Text scoreText;
    public Text healthText;
    public Text timerText;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        timerText.text = "Time: " + Mathf.FloorToInt(timer);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            RestartLvl();
        }
    }

    public void RestartLvl()
    {
        health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
