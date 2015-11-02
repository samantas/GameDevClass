using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Adventure : MonoBehaviour {

	public string currentRoom = "TitlePage";
	
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

	public AudioClip lonelyMan;
	public AudioSource lonelyManAS;

	public AudioClip gunShot;
	private bool shotDead = false;

	public AudioClip restartSound;
	
	public Button button;


	// Use this for initialization
	void Start () {
		clues = 0;

	}

	public void buttonPressed(){

		currentRoom = "Introduction";
		lonelyManAS.clip = lonelyMan;
		lonelyManAS.Play();

	}

	// Update is called once per frame
	void Update () {

		AudioSource audio = GetComponent<AudioSource>();

		clueSlider.value = clues;
		SliderCaption.text = "Clues Collected: " + clues + "/10";


		string textBuffer = "";
		room_north = "";
		room_south = "";
		room_west = "";
		room_east = "";

		if (currentRoom == "TitlePage") {
			GetComponent<Text> ().fontStyle = FontStyle.Bold;
		} else {
			GetComponent<Text> ().fontStyle = FontStyle.Normal;
		}

		switch (currentRoom) {

		case"TitlePage":
			textBuffer = "The Lonely Man in the Abandoned Woods";

			break;
		case"Introduction":
			textBuffer = "Once upon a time, there was a lonely man living in the the dark, forsaken woods." + 
					"\nHis house was the only one standing after the Great Storm wiped the rest of the population out." + 
					"\nAs a visitor from Jupiter, you are on a mission to figure out how this lonely man has survived the past 40 years alone.\n";

			room_north = "dark forest";

			break;
		case"dark forest":
			textBuffer = "You've entered the dark forest. A glimmering light seems to shine through a window from the east, " +
				"but you're not sure if the area is safe because you notice a trail of decaying bones leading towards the light.\n";

			room_east = "window";
			room_west = "the other way";

			break;
			
		case"window":
				textBuffer = "Below the window, you notice something metallic." +
					"\nIt's a key!" +
					"\n\nPress 'n' to pick up the key.\n";
			
			if (Input.GetKeyDown("n")){
				hasKey = true;
				clues += 1;

				audio.clip = findsKey;
				audio.Play ();

				// insert findsKey sound

				currentRoom = "abandoned house";
			}
			
			break;

		case"abandoned house":
			if(hasKey == true){
				textBuffer = "You enter the abandoned house with the key you just found." +
					"\nBut wait, did you hear that? It's not really abandoned is it..." +
					"a strange looking, perhaps mutated, animal chases you out the house.\n\n";

			room_south = "forest";

			}
			break;
		case"forest":
				textBuffer = "Sprinting out the house, a note sticks to your jacket. \n\n" +
					"Press 'm' to read the note. ";

			if (Input.GetKeyDown ("m")){
				clues += 1;
				audio.clip = findsClue;
				audio.Play ();

				currentRoom = "reads note";
			}

			break;

		case"reads note":

				textBuffer = "The note reads 'BEWARE OF THE MUTATED WOLF'. You think to yourself, that would've " +
					"been useful two minutes earlier. Nonetheless, it's a sign of life! " +
					"You're back in the forest. " +
					"\nYou notice a river to the west and a little house to the north.\n";

				room_west = "the river";
				room_north = "little house";

			break;

		case"the river":
				textBuffer = "You notice a piece of paper floating in the river.\n\n" +
					"Press 'm' to pick up the note.";

				if(Input.GetKeyDown("m")){

				clues += 1;

				Debug.Log ("added clue to slider");

				audio.clip = findsClue;
				audio.Play ();

				currentRoom = "note by river";
			}

			break;

		case"note by river":
			
				textBuffer = "The ink is smudged from the water. But you notice a tally. It looks like someone" +
					" has been keeping track of how many days have been passing by. " +
					"You notice that it has been signed by a man named Hugo. " +
					"Perhaps the river has more notes that can provide you with clues, or perhaps you should risk crossing " +
					"the river to approach the little house in the distance.\n";

			room_east = "little house";
			room_west = "and search the river for more notes";

			break;

		case"and search the river for more notes":

				textBuffer = "You continue searching the river for more notes but with no success.\n" +
					"You decide to risk crossing the river to go to the little house.\n";

				room_east = "little house";

				break;
		case"the other way":
				textBuffer = "Oh no! Rushing away from the trail of decaying bones, you accidentally stepped into a ditch." +
					"\nClimbing out, you step on something crunchy. Look! It's a couple of notes.\n" +
					"\nPress 'm' to pick up the notes.";
			if(Input.GetKeyDown ("m")){
				clues += 2;

				audio.clip = findsClue;
				audio.Play ();

				currentRoom = "outside little house";
			}

			break;

		case"outside little house":
				textBuffer = "The notes look like they're something from 30 years ago." +
					"\nBut the handwriting is not entirely legible." +
					" On the back of one of them, however, you notice a map! To the north of that map, you notice a small drawing" +
					" of a little house.\n";
				room_north = "little house";

			break;

		case"little house":
				textBuffer = "You approach the little house.\n";

				room_west = "to the kitchen";
				room_south = "bedroom";
				room_east = "living room inside the little house";

			break;

		case"to the kitchen":
				textBuffer = "Looking around, you find a stack of notes on the kitchen counter. " +
					"\n\nPress 'm' to read all the notes.";
				
			if(Input.GetKeyDown("m")){
				
				clues += 5;
				audio.clip = findsClue;
				audio.Play ();

			currentRoom = "and search for the basement";

			}

				break;

		case"and search for the basement":
				textBuffer = "One of the notes is dated today's date: November 1st, 2055. " +
					"Suddenly, you hear a noise coming from down below. There's a basement! " + 
					"You quickly search the house for a door to the basement. " +
					"You notice there's a door behind the sofa in the living room.\n";

			room_south = "door";

			break;

		case"bedroom":
				textBuffer = "There bedroom is completely destroyed. There's mold everywhere. There's " +
					"nothing interesting to see or find, except for a couple of dirty, illegible notes. " +
					"\n\nPress 'm' to pick them up anyway.";

			if(Input.GetKeyDown("m")){
				
				clues += 2;
				audio.clip = findsClue;
				audio.Play ();
				currentRoom = "to the kitchen";
			}
			break;

		case"living room inside the little house":
				textBuffer = "The living room smells a little like cinnamon, a scent that surprises you because" +
					" it's so dirty that you cannot tell the original color of the sofa." +
					" The sofa rests against a wall with a giant painting, which appears to be blocking a door." +
					"\n";
			room_south = "door";
			room_west = "to the kitchen";
			break;

		case"door":
				textBuffer = "The door leads down to the basement. The staircase is made out of wood and is missing half of its steps." +
					" The basement is even darker than outside in the forest. However, you get a glimpse of a note at the bottom of the" +
					" staircase.\n";

			room_south = "note in the basement";

				break;

		case"note in the basement":
				textBuffer = "Attempting to go down and pick up the note, you fall down the stairs." +
					" A voice yells 'WHO'S THERE?!'\n";

			room_east = "man and answer";
			room_north = "living room";
				break;
		

		case"man and answer":
				textBuffer = "The man is lying on a bed, paralyzed from the waist down. He says 'don't come" +
					" near me you freak. How did you find my house in the first place?" +
					" I thought there was no one but me who survived the Great Storm.'" +
					" \n\nPress 'i' to explain who you are." +
					" \nPress 'u' to ask about the Great Storm";

			if(Input.GetKeyDown ("i")){
				currentRoom = "explain";

			}

			if(Input.GetKeyDown ("u")){
				currentRoom = "ask";
			}
				
				break;

		case"ask":
				textBuffer = "Hugo grunts and then says, 'I knew I would have to talk about it again...well, " +
					"you see, it was just a regular fall day in 2015, when suddenly the temperature dropped " +
					"30 degrees Celsius below 0. Many people froze to death because people living by the equator " +
					"weren't ready for such a temperature drop. " +
					"Living in northern Sweden, you see, we are always ready for a cold day. Anyway, " +
					"I tried calling my wife, but the temperature drop wasn't the only thing that plagued earth. " +
					"The magnetic field suffered by something beyond my knowledge, but it implicated our network " +
					"system. So suddenly all mobile phones, laptops, and landlines were useless.' " +
					"\n\nPress 'u' to ask if Hugo wants to accompany you to your ship.";

			if(Input.GetKeyDown ("u")){
				currentRoom = "ship";
			}

				break;
		case"ship":
				textBuffer = "Hugo says, 'tell me why I should trust you'. " +
					"\n\nPress 'i' to kindly explain. " +
					"\nPress 'u' to say there's no time for explanation and that he better agree to accompany you.";

			if(Input.GetKeyDown ("i")){
				currentRoom = "explain why";
			}

			if(Input.GetKeyDown ("u")){
				currentRoom = "no time";
			}

				break;

		case"explain why":
				textBuffer = "You explain that your facilities on Jupiter can help him heal, and " +
					"that Jupiter's livingkind will respect him as a legend, eternally. You also " +
					"explain that his partner rescued another human being from Australia who " +
					"also survived the Great Storm. Hugo's face lights up with interest. He agrees " +
					"to accompany you." +
					"\n\nGreat job, with or without all the clues, you managed to complete the mission." +
					"\n\nPress 'o' to play again." +
					"\nPress 'esc' to quit the game.";

			if(Input.GetKeyDown ("o")){
				currentRoom = "Introduction";
				audio.clip = restartSound;
				audio.Play ();
				clues = 0;
			}

			if(Input.GetKey ("escape")){
				currentRoom = "TitlePage";
				audio.clip = restartSound;
				audio.Play ();
				clues = 0;
				Application.Quit ();
			}

				break;

		case"no time":
				textBuffer = "Hugo shoots you dead. You probably should've been more polite. " +
					"\nPress 'q' to restart.";

			if (!shotDead) {
			
			shotDead = true;
			audio.clip = gunShot;
			audio.Play ();

			} 

			if(Input.GetKeyDown ("q")){
				clues = 0;
				audio.clip = restartSound;
				audio.Play ();
				currentRoom = "Introduction";
			}

				break;

		case"explain":
				textBuffer = "You say, 'I have travelled here from Jupiter to find you. Don't worry. " +
					"I am not going to harm you. I just want to ask a few questions.' Hugo responds, " +
					"'I am in no condition to talk to you.'" +
					"\n\nPress 'u' to ask about the Great Storm.";

			if(Input.GetKeyDown ("u")){
				currentRoom = "ask";
			}
				

				break;
		case"living room":
				textBuffer = "You're back in the living room. But, you remember that it is your mission " +
					"to find out how and why this man has survived. You must choose whether or not you " +
					"will successfully complete this mission. Perhaps life on earth seems promising, do you want " +
					"to abandon the mission?\n";
			room_west = "on and abandon the mission";
			room_east = "man and answer";
				
				break;

		case"on and abandon the mission":

				textBuffer = "You abandon the mission and attempt to run out the house. " +
					"However, the front door has slammed shut, and you can't seem to open it. " +
					"While struggling to break the door open, a man yells 'WHO'S UP THERE?!' \n" +
					"\nPress 'i' to continue trying to break the door open." +
					"\nPress 'u' to find the man, answer him, and do what you should've done earlier: return to your mission.";

			if(Input.GetKeyDown ("i")){
				clues -= 1;
				currentRoom = "failure";

			}
			
			if(Input.GetKey ("u")){
				currentRoom = "man and answer";
			}

				break;

		case"failure":
				textBuffer = "You manage to break the door open, but you lose a note. " +
					"You also accidentally step right into a trap, a net quickly surrounds you, " +
					"entagles you, and quickly fishes you up towards the treetops, where you starve to death.\n\n" +
					"Press 'o' to restart the game.";

			if(Input.GetKeyDown ("o")){
				currentRoom = "Introduction";
				audio.clip = restartSound;
				audio.Play ();
				clues = 0;
			}

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
