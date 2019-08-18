using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int playerOneScore, playerTwoScore;

    [SerializeField]
    BallController ball;
    [SerializeField]
    int winScore = 5;
    GUISkin layout;
    [SerializeField]
    AudioClip score;

    [SerializeField]
    AudioSource audioSource;

    private bool victory = false;

    KeyCode restart = KeyCode.R;
    KeyCode quit = KeyCode.Escape;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        playerOneScore = 0;
        playerTwoScore = 0;
    }

    public void Score(int playerNumber)
    {
        audioSource.clip = score;
        audioSource.Play();

        if (playerNumber == 1)
        {
            playerOneScore++;
        }
        else
        {
            playerTwoScore++;
        }

        if (playerOneScore == winScore || playerTwoScore == winScore)
        {
            GameOver(playerNumber);
        }
        else
        {
            ball.Reset();
        }
    }

    void GameOver(int playerNumber)
    {
        victory = true;
        ball.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(quit))
        {
            Application.Quit();
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.color = Color.white;
        GUI.contentColor = Color.white;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 50;
        style.fontStyle = FontStyle.Bold;

        GUI.Label(new Rect(Screen.width / 2 - 150 - 50, 20, 100, 100), "" + playerOneScore, style);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 50, 20, 100, 100), "" + playerTwoScore, style);

        if (victory)
        {
            GUI.Label(new Rect(Screen.width / 2 - 125, Screen.height / 2, 500, 100), "Player " + (playerOneScore > playerTwoScore ? "1" : "2") + " wins", style);
            if (Input.GetKey(restart))
            {
                victory = false;
                this.Start();
                this.ball.Reset();
            }
        }
    }
}
