using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	//Puntuación
	public TextMeshProUGUI scoreText;
    int score = 0;
    public TextMeshProUGUI gameovertext;

	//Player
	public GameObject player;

	//Enemigos
	public GameObject AsterMed3;
    public SpawnAsteroid spawnAsteroid;    


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
	}

    public void GameOver()
    {
        // Detener el spawn de asteroides
        CancelInvoke("spawnAsteroid");
        // Mostrar mensaje de Game Over
        gameovertext.text = "Game Over! Final Score: " + score;
        gameovertext.gameObject.SetActive(true);
        
	}
}
