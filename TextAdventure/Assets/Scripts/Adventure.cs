using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Adventure : MonoBehaviour {

	public string currentRoom = "Introduction";
	
	public string room_north;
	public string room_south;
	public string room_east;
	public string room_west;

	public static int clues = 0;

	public Slider clueSlider;
	public AudioClip findsClue;
	public Text SliderCaption;

	public AudioClip findsKey;
	private bool hasKey = false;


	// Use this for initialization
	void Start () {
		clues = 0;
	}
	
	// Update is called once per frame
	void Update () {

		AudioSource audio = GetComponent<AudioSource>();
		SliderCaption.text = "Clues Collected: " + clues + "/10";

		clueSlider.value = clues;

		string textBuffer = "";
		room_north = "";
		room_south = "";
		room_west = "";
		room_east = "";
		
		switch (currentRoom) {
		case"Introduction":
			textBuffer = "Once upon a time, there was a lonely man living the the dark, forsaken woods." + 
					"\nHis house was the only one standing after the Great Storm wiped the rest of the population out." + 
					"\nAs a visitor from Jupiter, you are on a mission to figure out how this lonely man has survived the past 40 years alone.";

			room_north = "dark forest";

			break;
		case"dark forest":
			textBuffer = "You've entered the dark forest. A glimmering light seems to shine through a window from the east.";

			room_east = "window";
			room_west = "the other way";

			break;
			
		case"window":
				textBuffer = "Below the window, you notice something metallic." +
					"\nIt's a key!" +
					"\nPress 'n' to pick up the key.";
			
			if (Input.GetKeyDown("n")){
				hasKey = true;

				// insert findsKey sound

				currentRoom = "abandoned house";
			}
			
			break;

		case"abandoned house":
				textBuffer = "You enter the abandoned house with the key you just found." +
					"\nBut wait, did you hear that? It's not really abandoned is it...";

			room_south = "forest";
			break;
		case"forest":
				textBuffer = "You're back in the forest." +
					"\nYou notice a river to the west and a little house to the north.";

			room_west = "the river";
			room_north = "little house";

			break;

		case"the river":
				textBuffer = "You notice another piece of paper floating in the river.";

			// enter code to pick up and read the note

			break;

		case"the other way":
				textBuffer = "Oh no! You accidentally stepped into a ditch." +
					"\nClimbing out, you step on something crunchy. Look! It's a note." +
					"\nPress 'm' to pick up the note.";
			if(Input.GetKeyDown ("m")){
				clues = 1;

				//call sound effect
				audio.clip = findsClue;
				audio.Play ();

				currentRoom = "outside little house";
			}

			break;

		case"outside little house":
				textBuffer = "The note looks like it's something from 30 years ago." +
					"\nBut the handwriting is not entirely legible." +
					" On the back, however, you notice a map! To the north of that map, you notice a small drawing" +
					" of a little house.";
				room_north = "little house";

			break;

		case"little house":
				textBuffer = "You approach the little house.";
				room_east = "living room inside the little house.";

			break;

		default:
			break;
		}
		
		if (room_north != "") {
			textBuffer += "\nPress 'n' to go to the " + room_north + ".";
			
			if (Input.GetKeyDown ("n")){
				currentRoom = room_north;
			}
		}
		
		if (room_south != "") {
			textBuffer += "\nPress 's' to go to the " + room_south + ".";
			
			if (Input.GetKeyDown ("s")){
				currentRoom = room_south;
			}
		}
		
		if (room_east != "") {
			textBuffer += "\nPress 'e' to go to the " + room_east + ".";
			
			if (Input.GetKeyDown ("e")){
				currentRoom = room_east;
			}
		}
		
		if (room_west != "") {
			textBuffer += "\nPress 'w' to go " + room_west + ".";
			
			if (Input.GetKeyDown ("w")){
				currentRoom = room_west;
			}
		}

		GetComponent<Text> ().text = textBuffer;
	}
}
