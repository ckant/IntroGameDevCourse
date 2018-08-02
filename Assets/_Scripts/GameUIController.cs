using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameUIController : MonoBehaviour {
    private Text ScoreHUD;
    private static int score = 0;

    private GameObject hud;

	// Use this for initialization
	void Start () {
        hud = GameObject.FindGameObjectWithTag("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncrementScore()
    {
        score++;
        ScoreHUD.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOver()
    {
        hideHUD();
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }

    public void RestartGameScene()
    {
        ResetScore();
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        updateScore();
    }

    private void hideHUD()
    {
        hud.SetActive(false);
    }

    private void updateScore()
    {
        Text[] textObjects = GameObject.FindObjectsOfType<Text>();
        ScoreHUD = textObjects.Where(to => to.name == "Score").First();
        ScoreHUD.text = score.ToString();
    }
}
