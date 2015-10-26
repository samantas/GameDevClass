using UnityEngine;
using System.Collections;

public class TextAdventure : MonoBehaviour {

	public string currentRoom = "entryWay";

	public string room_north;
	public string room_south;
	public string room_east;
	public string room_west;

	private bool hasKey = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		string textBuffer = "";
		room_north = "";
		room_south = "";
		room_west = "";
		room_east = "";

		switch (currentRoom) {
		case"entryWay":
			textBuffer = "You are in the entryway.\n";
			room_north = "magicRoom";
			break;
		case"magicRoom":
			textBuffer = "You are in the magic room.\n";
			room_south = "entryway";
			room_east = "partyRoom";
			room_north = "key room";

			break;

		case"key room":
			textBuffer = "you are in a room that's called \n the key room, for some reason. \n there's a drawer in front of you \n" + "Press 'm' to open the drawer.";

			if (Input.GetKeyDown("m")){
				hasKey = true;
				currentRoom = "Got Key";
			}

			break;
		case"Got Key":
				textBuffer = "Congrats! You found a key inside the drawer.\n" + "Press any key!";
				if (Input.anyKeyDown){
				currentRoom = "after party room";
			}
				break;
		case"partyRoom":
			textBuffer = "You are in the partyRoom.";
			room_west = "magicRoom";
			room_east = "party room door";
			break;

		case"party room door":
			if (hasKey == true){
				textBuffer = "you use the key to open the door.";

				room_south = "after party room"; 
			} else {
				textBuffer = "The door is locked. \n Press any key to return to the party room.";

				if (Input.anyKeyDown){
					currentRoom = "partyRoom";
				}
			}
			break;

		case"after party room":
				textBuffer = "you are in the after party room.\n" + "all of your friends are here.\n" + "you won!!!";

			break;
		default:
			break;
		}

		if (room_north != "") {
			textBuffer += "\n Press 'n' to go to the " + room_north + ".";

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
			textBuffer += "\nPress 'w' to go to the " + room_west + ".";
			
			if (Input.GetKeyDown ("w")){
				currentRoom = room_west;
			}
		}

		GetComponent<TextMesh>().text = textBuffer;


//		if (currentRoom == "entryWay") {
//			GetComponent<TextMesh> ().text = "You are in the entryway.\n" + "There is a magic room to the north.";
//
//			if (Input.GetKeyDown ("n")) {
//				currentRoom = "magicRoom";
//			}
//
//		} else if (currentRoom == "magicRoom") {
//				GetComponent<TextMesh>().text = "You are in the magic room.\n" + "There is an entryway to the south.";
//			
//			if (Input.GetKeyDown ("s")){
//					currentRoom = "entryWay";
//			}
//		}
		
	}
	
}
	