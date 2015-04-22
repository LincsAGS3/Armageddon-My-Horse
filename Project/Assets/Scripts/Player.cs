using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static float TotalEnemiesKilled;
	//Player Health
	public static float PlayerHealth;
	//player speed
	public static float speed;
	//player rotate speed
	public static float rotateSpeed;



    public AudioClip[] audioClip;
    bool cavalryCheck = false;
    bool cavalryFound = false;
    public static bool famineFound = false;
    public static bool deathFound = false;
    public static bool conquestFound = false;
    float dist = 35.0f;
    public static bool soundPlaying = false;
	bool faminemusic = false;
	bool deathmusic = false;
	bool conquestmusic = false;

	// Use this for initialization
	void Start () {
		//these are here so that if you restart the game there values are reset
		TotalEnemiesKilled = 0;
		PlayerHealth = 100;
		speed = 5;
		rotateSpeed = 50;
	}
	
	// Update is called once per frame
	void Update () {

        if ((famineFound == false) && (deathFound == false) && (conquestFound == false))
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("Cavalry");
            cavalryCheck = false;
            foreach (GameObject G in g)
            {
                if (dist > Vector2.Distance(G.transform.position, transform.position))
                {
                    cavalryCheck = true;

                    if (cavalryFound == false)
                    {
                        cavalryFound = true;
						//audio.Stop();
                        playSound(0);                       
                    }
                }
            }
            
        }
        if (cavalryCheck == false)
        {
            cavalryFound = false;
        }
        if ((cavalryFound == false) && (famineFound == false) && (deathFound == false) && (conquestFound == false))
        {
			if (soundPlaying == false)
			{
				//audio.Stop();
				playSound(4);
				soundPlaying = true;
			}
            //audio.Stop();
            
        }

        if (famineFound == true)
        {
			if (faminemusic == false)
			{
				faminemusic = true;
            cavalryFound = false;
            soundPlaying = false;
            Debug.Log("Playing track 1");
			//audio.Stop();
            playSound(1);
			}
        }
        if (deathFound == true)
        {
			if (deathmusic == false)
			{
				deathmusic = true;
            cavalryFound = false;
            soundPlaying = false;
            Debug.Log("Playing track 2");
			//audio.Stop();
            playSound(2);
			}
        }
        if (conquestFound == true)
        {
				if (conquestmusic == false)
				{
					conquestmusic = true;
            cavalryFound = false;
            soundPlaying = false;
            Debug.Log("Playing track 3");
			//audio.Stop();
            playSound(3);
			}
        }
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.tag == "Enemy")
			//if (collider.tag == "Boss){ lose more health--;} and so-on
		{
			//Function can be changed to remove health decrementally or provide insta kill
			PlayerHealth-=0.1f;
		}
		if (PlayerHealth == 0)
		{
			//Game Over...
			MenuGameMenuStateScript.MenuStateChange(2);
		}
	}
	public static void hit(float damage)
	{
		PlayerHealth -= damage;
	}

    void playSound(int Clip)
    {
        audio.clip = audioClip[Clip];
        audio.Play();
    }
}
