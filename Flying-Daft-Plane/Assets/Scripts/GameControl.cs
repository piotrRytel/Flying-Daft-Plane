using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // udostępnienie dla innych klas
    public static GameControl Instance;

    //zmienne
    public float scrollSpeed = -2.5f;
    public bool isGameOver = false;
    private int score = 0;

    public Text scoreText;
    public GameObject gameOverText;

    public AudioSource scoreAudio;
    public AudioSource dieAudio;


    // Awake rusza przed " void start"     
    private void Awake()
    {
        

        if (Instance == null)
        {
            Instance = this;

        }else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
   
    // Update is called once per frame
    void Update ()
    {
        

        // przeładowanie całej sceny (restart) po game over / po kliknięciu
		if(isGameOver && Input.GetMouseButtonDown(0))
        {
            //przeładuj aktywną scenę
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            

        }
	}
    // metoda zwracająca wynik po gameover
    public void Score()
    {
        scoreAudio.Play();
        if (isGameOver) { return; }
        score++;
        // wyświetl jaki jest wynik
        scoreText.text = "Score: " + score;
       
    }
    public void Die()
    {
        dieAudio.Play();
        // jeśli gameover = true wyświetl gameOver text
        isGameOver = true;
        gameOverText.SetActive(true);
        

    }
    
}

