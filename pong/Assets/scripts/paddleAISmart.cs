using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddleAISmart : MonoBehaviour {
	public float speed = 10f;
	GameObject ball_gm;
	Transform ball;
	Collider2D col;
	Collider2D ballCol;
	float extents, bextents;
	float lastX, lastY, slope, yint,xsped;
	// Update is called once per frame
	void Start(){
		ball_gm = GameObject.FindGameObjectWithTag ("Ball");
		ball = ball_gm.transform;
		col = GetComponent<Collider2D> ();
		extents = col.bounds.extents.y;
		ballCol = ball_gm.GetComponent<Collider2D> ();
		bextents = ballCol.bounds.extents.y;
		lastX = ball.position.x;
		lastY = ball.position.x;
	}
	void Update () {
		if (ball.position.x == lastX)
			return;
		xsped = ball.position.x - lastX;
		slope = (ball.position.y - lastY)/ xsped;
		yint = ball.position.y - slope * ball.position.x;
		Vector3 tr = transform.position;
		float ballPosY = ball.position.y;
		float paddleMaxY = tr.y + extents;
		float paddleMinY = tr.y - extents;

		//check if the ball lands somwhere on the paddle
		//thus its y values have to be in a certain range
		Vector3 ss = tr;
		ss.y = paddleMaxY;
		Vector3 st = ss;
		st.x = 0;
		Debug.DrawLine (ss, st);
		ss.y = paddleMinY;
		st.y = paddleMinY;
		Debug.DrawLine (ss, st);

		//where will the ball hit?
		float ballYhit = slope*tr.x + yint;
		Vector3 ballHit = new Vector3 (tr.x, ballYhit, 0);
		Debug.DrawLine (ballHit, ball.position, Color.green);

		tr.y = ballYhit;
		transform.position = tr;
	}
}
