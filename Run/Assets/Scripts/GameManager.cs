using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private GameObject scoreObj;
    [SerializeField] private TMP_Text totalScoreText;
    [SerializeField] private int score;
    [SerializeField] private int totalScore;
    [SerializeField] private int highscore;
    public float speed=20f;
    private bool _isFirst = true;
    private bool _isPause=false;
    public void Restart()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void StartGame()
    {
        StartCoroutine(ScoreCounter());
        Time.timeScale = 1f;
        _isPause = false;

    }

    private void SaveRecord()
    {
        if (totalScore > highscore)
        {
            highscore = totalScore;
            totalScoreText.text = "Score: " + totalScore + " New Record!";
            highscoreText.text = "Highscore: " + highscore;
        }
        else
        {
            highscoreText.text = "Highscore: " + highscore;
            totalScoreText.text = "Score: " + totalScore;
        }
    }

    public void FirstStart()
    {
        startPanel.SetActive(false);
        score = 0;
        StartGame();
        scoreObj.SetActive(true);
        _isFirst = false;
    }

    private IEnumerator ScoreCounter()
    {
        while (true)
        {
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
            // ReSharper disable once IteratorNeverReturns
        }
    }

    private void Pause()
    {
        _isPause = true;
        Time.timeScale = 0f;
        StopAllCoroutines();
    }

    public void Show_Pause_Panel()
    {
            pauseButton.SetActive(false);
            playButton.SetActive(true);
            pausePanel.SetActive(true);
            Pause();
    }


    public void Resume()
    {
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        pausePanel.SetActive(false);
        if (_isFirst == false)
            StartGame();
        else
            FirstStart();
    }


    public void Game_Over()
    {
        gameOverPanel.SetActive(true);
        scoreObj.SetActive(false);
        pauseButton.SetActive(false);
        totalScore = score;
        score = 0;
        scoreText.text = totalScore.ToString();
        SaveRecord();
        Pause();
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Start()
    {
        _isFirst = true;
        startPanel.SetActive(true);
        scoreObj.SetActive(false);
        Pause();
        
    }
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (_isPause)
        {
            StartGame();
        }
        else
        {
            Pause();
        }
    }
}
