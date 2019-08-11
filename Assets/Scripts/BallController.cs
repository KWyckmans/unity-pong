using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float forceValue = 4.5f;

	float leftBorder = 0.0f;
	float rightBorder = Screen.width;

    [SerializeField]
    GameManager manager;

    Rigidbody2D body;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Starting the ball");
        body = GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(forceValue * 50, 50));
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
		Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

		if(screenPos.x < leftBorder){
			manager.Score(2);
		} else if (screenPos.x > rightBorder){
			manager.Score(1);
		}

    }

    public void Stop(){
        body.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
        Debug.Log("Stopping the ball");
        this.spriteRenderer.enabled = false;
    }

    public void Reset()
    {
        this.Stop();
        this.Start();
    }
}
