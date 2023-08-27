using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI livesText;

    [SerializeField] private Button restartButton;
    [SerializeField] private Slider slider;
    [SerializeField] private Image pauseImage;

    [SerializeField] private AudioSource bgMusic;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject wall;

    private float spawnRate = 1f;
    
    private int score;
    private int lives=3;

    public bool isGameActive;
    private bool isPause;
    
    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    private void Update()
    {
        SoundOption();
        PauseGame();
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
    public void GameOver() 
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficultyRate)
    {
        spawnRate /= difficultyRate;
        isGameActive = true;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        titleScreen.SetActive(false);
    }
    public void LivesCount()
    {
        if (lives>0)
        {
            lives -= 1;
            livesText.text = "Lives: " + lives;
        }
        if (lives==0)
        {
            GameOver();
            isGameActive = false;
        }
    }

    void SoundOption()
    {
        bgMusic.volume = slider.value;
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPause)
        {
            pauseImage.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPause = true;
            wall.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPause)
        {
            pauseImage.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPause=false;
            wall.SetActive(false);
        }
    }
}
