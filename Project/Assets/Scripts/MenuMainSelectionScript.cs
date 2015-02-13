using UnityEngine;
using System.Collections;

public class MenuMainSelectionScript : MonoBehaviour
{
		void Start ()
		{			
				UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (GameObject.Find ("Play button"));//default selected button is play
		}

		public static void ProcessSelection (int CurrentSelection)
		{
				switch (CurrentSelection) {// switch used to process the users selection on the main menu
				case 0:
						//quit the game
						#if UNITY_EDITOR
							UnityEditor.EditorApplication.isPlaying = false;
						#else
							Application.Quit ();
						#endif
						break;
				case 1:
						Application.LoadLevel ("MainGame"); // loads the main game
						break;
				case 2:
						MenuStateScript.MenuStateChange (1); // changes to the option menu state
						break;
				case 3:
						MenuStateScript.MenuStateChange (2); // changes to the leaderboard menu state
						break;
				}			
		}
}
