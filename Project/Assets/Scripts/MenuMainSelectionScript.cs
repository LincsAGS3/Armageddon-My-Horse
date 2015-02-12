using UnityEngine;
using System.Collections;

public class MenuMainSelectionScript : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
				//default selected button is play
				UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (GameObject.Find ("Play button"));
		}
	
		public static void ProcessSelection (int CurrentSelection)
		{
				switch (CurrentSelection) {
				case 0:
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
						Application.Quit ();
			#endif
						break;
				case 1:
						Application.LoadLevel ("MainGame");
						break;
				case 2:
						MenuStateScript.MenuStateChange (1);
						break;
				case 3:
						MenuStateScript.MenuStateChange (2);
						break;
				}			
		}
}
