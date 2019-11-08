using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameOver : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

        this.transform.Find("score").GetComponent<TextMeshProUGUI>().SetText(GameManager.score.ToString());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            if (GameManager.score > SceneTransition.highScore) {
                SceneTransition.highScore = GameManager.score;
                player.highscore = SceneTransition.highScore;
                player.SavePlayer();
            }
            SceneManager.LoadScene(0);
        }
    }
}
