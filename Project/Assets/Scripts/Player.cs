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
            audio.Stop();
            soundPlaying = false;
        }

        if ((famineFound == true)&&(soundPlaying == false))
        {
            cavalryFound = false;
            soundPlaying = true;
            Debug.Log("Playing track 1");
            playSound(1);
        }
        if ((deathFound == true)&&(soundPlaying == false))
        {
            cavalryFound = false;
            soundPlaying = true;
            Debug.Log("Playing track 2");
            playSound(2);
        }
        if ((conquestFound == true)&&(soundPlaying == false))
        {
            cavalryFound = false;
            soundPlaying = true;
            Debug.Log("Playing track 3");
            playSound(3);
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
	public static void hit(int damage)
	{
		PlayerHealth -= damage;
	}

    void playSound(int Clip)
    {
        audio.clip = audioClip[Clip];
        audio.Play();
    }
}
