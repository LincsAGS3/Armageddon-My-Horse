using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour {

	//node struct
	public struct node
	{
		public Vector2 pos;
		public Vector2 prev;
		public float cost;
		public float f_score;
	};
	//lists
	List<node> open = new List<node>();
	node[,] Carray;
	List<Vector2> path = new List<Vector2>();
	//path map
	public static Vector2[,] map;
	//level
	public static int[,] level;
	//grid size
	int gridSize = 40;

	void Start () {
		map = new Vector2[(int)Mathf.Pow (gridSize, 2), (int)Mathf.Pow (gridSize, 2)];
		level = new int[gridSize, gridSize];
		//todo add map loading for now set all to 0
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				level[j, i] = 0;
			}
		}
		Iterate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Iterate()
	{
		//point we are going from
		for (int i = 0; i<gridSize; i++) {
			for(int j = 0; j < gridSize; j++)
			{
				Expand (new Vector2(j,i));
				//to
				for (int ii = 0; ii < gridSize; ii++)
				{
					for (int jj = 0; jj < gridSize; jj++)
					{
						if (isValid(new Vector2(jj, ii)))
						{
							if (ii == i && jj == j)
							{
								map[(i * gridSize) + j, (ii * gridSize) + jj] = new Vector2(j, i);
							}
							else
							{
								//find the node we want to path to
								node temp = new node();
								temp = Carray[jj, ii];
								CreatePath(temp);
								map[(ii * gridSize) + jj, (i * gridSize) + j] = path[path.Count - 2];
							}
						}
					}
				}
			}
		}
		Debug.Log ("finished calculating");
	}

	void Expand(Vector2 pos)
	{
		//reset the closed array
		Carray= new node[gridSize,gridSize];
		for (int i = 0; i < gridSize; i++)
		{
			for (int j = 0; j < gridSize; j++)
			{
				Carray[j, i].cost = -1;
			}
		}
		//clear the lists
		open.Clear ();
		path.Clear ();
		//add the start node to the open list
		node start = new node ();
		start.pos = pos;
		start.prev = new Vector2 (-1, -1);
		start.cost = 0;
		open.Add (start);

		bool found = false;

		while (!found) {
			node curr = new node(); ;
			curr.cost = int.MaxValue;
			int count = 0;
			int rem = 0;
			if (open.Count == 0)
			{
				//finished
				found = true;
				break;
			}
			foreach (node n in open)
			{
				if (n.cost < curr.cost)
				{
					curr = n;
					rem = count;
				}
				count++;
			}
			//remove from open list
			open.RemoveAt(rem);
			Carray[(int)curr.pos.x, (int)curr.pos.y] = curr;
			//check nodes
			curr.prev = curr.pos;
			curr.cost += 1;
			curr.pos.x += 1;
			CheckSpace(curr);
			curr.pos.x -= 2;
			CheckSpace(curr);
			curr.pos.x += 1;
			curr.pos.y += 1;
			CheckSpace(curr);
			curr.pos.y -= 2;
			CheckSpace(curr);
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
		return false;
	}
	void CheckSpace(node curr)
	{
		if (isValid(curr.pos))
		{
			//is it in the closed list already
			if (Carray[(int)curr.pos.x, (int)curr.pos.y].cost != -1)
			{
				return;
			}
			
			//is there a worse route in the open list
			foreach (node n in open)
			{
				if (n.pos == curr.pos)
				{
					if (n.cost > curr.cost)
					{
						open.Remove(n);
						open.Add(curr);
						return;
					}
					return;
				}
			}
			open.Add(curr);
		}
	}
	void CreatePath(node end)
	{
		path.Clear();
		path.Add(end.pos);
		while (end.prev != new Vector2(-1, -1))
		{
			end = Carray[(int)end.prev.x, (int)end.prev.y];
			path.Add(end.pos);
		}
	}
}