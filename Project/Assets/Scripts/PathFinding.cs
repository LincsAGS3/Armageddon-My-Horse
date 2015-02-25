using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class PathFinding : MonoBehaviour {

	//node struct
	public struct node
	{
		public Vector2 pos;
		public Vector2 prev;
		public float cost;
		public float f_score;
	};
	public int playerscent = 20;
	public static int[,] buffer1;
	public int[,] buffer2;
	public static int[,] level;
	public GameObject player;
	//grid size
	public static int gridSize = 250;

	void Start () {
		level = new int[gridSize, gridSize];
		Collider2D col = null;
		//todo add map loading for now set all to 0
		for (int i = 0; i < gridSize; i++) {
			for (int j = 0; j < gridSize; j++) {
				col = Physics2D.OverlapCircle (new Vector2 (j, i), 1f);
				if (col == null) {
					level [j, i] = 0;
				} else if (col.tag == "Wall") {
					level [j, i] = 1;
				} else {
					level [j, i] = 0;
				}
				col = null;
			}
		}
		buffer1 = new int[gridSize, gridSize];
		buffer2 = new int[gridSize, gridSize];
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				buffer1[i, j] = 0;
				buffer2[i, j] = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//set the player pos to be the current scent
		buffer1[(int)player.transform.position.x, (int)player.transform.position.y] = playerscent;
		//increment the scent
		//playerscent++;
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				buffer2[i,j] = buffer1[i,j];
			}
		}
		//Update buffer 1 based on buffer 2
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				UpdateSpace(new Vector2(j, i));
			}

		}
	}
	
	bool isValid(Vector2 curr)
	{
		if (curr.x < 0 || curr.y < 0) {
			return false;
		} else {
			if(curr.x >= gridSize || curr.y >= gridSize) {
				return false;
			}
			else{
				if(level[(int)curr.x,(int)curr.y] ==0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}
	}
	private void UpdateSpace(Vector2 pos)
	{
		if (isValid (pos)) {
			int curr = 0;
			pos.x += 1;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.x -= 2;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.x += 1;
			pos.y += 1;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.y -= 2;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			
			pos.x += 1;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.x -= 2;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.y += 2;
			
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.x += 2;
			if (isValid (pos)) {
				if (buffer2 [(int)pos.x, (int)pos.y] > curr) {
					curr = buffer2 [(int)pos.x, (int)pos.y];
				}
			}
			pos.x -= 1;
			pos.y -= 1;
			buffer1 [(int)pos.x, (int)pos.y] = curr - 1;
		} else {
			buffer1 [(int)pos.x, (int)pos.y] = - 1;
		}
	}
}