using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LocationScriptableObject currentLocation; //save the current location

    public Text locationNameText; //the name of the location shown on the screen
    public Text locationDescription; // the description of the location shown on the screen

    public GameObject buttonNorth; 
    public GameObject buttonSouth;
    public GameObject buttonWest;
    public GameObject buttonEast;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLocation(); //initiate the screen 
    }

    public void MoveDirection(int dir) // trigger this function when clicking on buttons
    {
        switch (dir)
        {
            case 0:
                currentLocation = currentLocation.locationNorth;
                break;
            case 1:
                currentLocation = currentLocation.locationSouth;
                break;
            case 2:
                currentLocation = currentLocation.locationEast;
                break;
            case 3:
                currentLocation = currentLocation.locationWest;
                break;
            default:
                break;
        }
        
        UpdateLocation();
    }

    void UpdateLocation() //when enter a new room, update the new room info
    {
        locationNameText.text = currentLocation.locationName; //update room name
        locationDescription.text = currentLocation.description; //update room description
        
        if (currentLocation.locationEast == null)  //when there's no room on the east, disable "East" button on the screen
        {
            buttonEast.SetActive(false);
        }
        else //bring the button back if there is room on the east
        {
            currentLocation.locationEast.locationWest = currentLocation;
            buttonEast.SetActive(true);
        }

        if (currentLocation.locationNorth == null)
        {
            buttonNorth.SetActive(false);
        }
        else
        {
            currentLocation.locationNorth.locationSouth = currentLocation;
            buttonNorth.SetActive(true);
        }

        if (currentLocation.locationSouth == null)
        {
            buttonSouth.SetActive(false);
        }
        else
        {
            currentLocation.locationSouth.locationNorth = currentLocation;
            buttonSouth.SetActive(true);
        }

        if (currentLocation.locationWest == null)
        {
            buttonWest.SetActive(false);
        }
        else
        {
            currentLocation.locationWest.locationEast = currentLocation;
            buttonWest.SetActive(true);
        }

        if (currentLocation.name == "DaughterRoom") //if the player enters "Daughter's Room", game ends and disable the buttons on the screen.
        {
            buttonNorth.SetActive(false);
        }
    }
    
}
