using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
    {
        //instancja dla RigidBody
        // komponenty które są powiązane z rigidBody
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.Instance.scrollSpeed, 0);
	}
	// Update is called once per frame
	void Update () {
        // sprawdzamy czy gra jest GameOver jeśli tak zatrzymaj ziemie, niebo itp zmień Vector2 na zero
        if (GameControl.Instance.isGameOver)
        {
            rb2d.velocity = Vector2.zero; 
        }
	}
}
