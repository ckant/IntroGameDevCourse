using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour {

    private GameObject hud;

	// Use this for initialization
	void Start () {
        hud = GameObject.FindGameObjectWithTag("HUD");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOver()
    {
        hud.SetActive(false);
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }

    public void RestartGameScene()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
