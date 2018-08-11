using UnityEngine;
using System.Collections;
using System;

using System.Collections.Generic;
//Adding this allows us to access members of the UI namespace including Text.
using UnityEngine.UI;



public class CompletePlayerController : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    public Text countText;          //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int count;              //Integer to store the number of pickups collected so far.
    private NameModel nameModel;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

        //Initialize count to zero.
        count = 0;
        //to add
        nameModel = new NameModel();

        //Initialze winText to a blank string since we haven't won yet at beginning.

        //Call our SetCountText function which will update the text with the current value for count.
        SetCountText();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);
    }

    //OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
    void OnTriggerEnter2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.CompareTag("PickUp"))
        {
            //... then set the other object we just collided with to inactive.
            other.gameObject.SetActive(false);

            //Add one to the current value of our count variable.
            count = count + 1;

            //Update the currently displayed count by calling the SetCountText function.
            SetCountText();
        }
    }

    //This function updates the text displaying the number of objects we've collected and displays our victory message if we've collected all of them.
    void SetCountText()
    {
        //Set the text property of our our countText object to "Count: " followed by the number stored in our count variable.
        countText.text = "Count: " + count.ToString() +" rand : "+ nameModel.GetRandomName(count);

        //Check if we've collected all 12 pickups. If we have...
        if (count >= 12)
        {
            //... then set the text property of our winText object to "You win!"
            winText.text = "You win!";
        }
    }
    
}

public class NameModel
{
    public NameModel() {
        InitDictionary();
    }
    
    List<String> dictionary = new List<String>();

    public String GetRandomName()
    {
        int dictionaryLength = dictionary.Count;
        int randomNumber = GetRandomNumber(dictionaryLength);
        String randomName = dictionary[randomNumber];
        return randomName;
    }

    public String GetRandomName(int nameLength)
    {
        List<String> sortedDictionary = GetAllWorldsWithSameSize(nameLength);
        int dictionaryLength = sortedDictionary.Count;
        int randomNumber = GetRandomNumber(dictionaryLength);
        String randomName = sortedDictionary[randomNumber];
        return randomName;
    }

    private List<string> GetAllWorldsWithSameSize(int size)
    {
        List<String> notFilteredList = dictionary;
        List<String> filteredList = dictionary.FindAll(item => item.Length == size);
        if(filteredList.Count < 1)
        {
            String errorMessage = "No name found with " + size + " length.";
            return new List<String>() { errorMessage };
        }
        return filteredList;
    }

    private int GetRandomNumber(int maxValue)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(maxValue);
    }

    private void InitDictionary()
    {
        dictionary.Add("AFK");
        dictionary.Add("alliance");
        dictionary.Add("apt-cache");
        dictionary.Add("apt-get");
        dictionary.Add("arborescence");
        dictionary.Add("ASCII");
        dictionary.Add("at");
        dictionary.Add("booter");
        dictionary.Add("chmod");
        dictionary.Add("cookie");
        dictionary.Add("boss");
        dictionary.Add("cat");
        dictionary.Add("capture");
        dictionary.Add("casu");
        dictionary.Add("cloud");
        dictionary.Add("community manager");
        dictionary.Add("cosplay");
        dictionary.Add("cp");
        dictionary.Add("do");
        dictionary.Add("done");
        dictionary.Add("farmer");
        dictionary.Add("fichiers sources");
        dictionary.Add("for");
        dictionary.Add("freeware");
        dictionary.Add("gamer");
        dictionary.Add("geek");
        dictionary.Add("grep");
        dictionary.Add("gzip");
        dictionary.Add("GG");
        dictionary.Add("Girl powa");
        dictionary.Add("guilde");
        dictionary.Add("head");
        dictionary.Add("history");
        dictionary.Add("guilder");
        dictionary.Add("IA");
        dictionary.Add("iconv");
        dictionary.Add("if");
        dictionary.Add("Intart");
        dictionary.Add("IRL");
        dictionary.Add("IG");
        dictionary.Add("interface");
        dictionary.Add("kevin");
        dictionary.Add("kikoolol");
        dictionary.Add("kill");
        dictionary.Add("LOL");
        dictionary.Add("loot");
        dictionary.Add("main");
        dictionary.Add("MAJ");
        dictionary.Add("make");
        dictionary.Add("mkdir");
        dictionary.Add("MMORPG");
        dictionary.Add("MP");
        dictionary.Add("mv");
        dictionary.Add("nerd");
        dictionary.Add("netiquette");
        dictionary.Add("newbie");
        dictionary.Add("noob");
        dictionary.Add("OSEF");
        dictionary.Add("ownedPGM");
        dictionary.Add("passwd");
        dictionary.Add("post");
        dictionary.Add("poweroff");
        dictionary.Add("PVP");
        dictionary.Add("PVE");
        dictionary.Add("pwd");
        dictionary.Add("pyjaracine");
        dictionary.Add("raider");
        dictionary.Add("random");
        dictionary.Add("reboot");
        dictionary.Add("régis");
        dictionary.Add("reroll");
        dictionary.Add("rmdir");
        dictionary.Add("rsync");
        dictionary.Add("roxer");
        dictionary.Add("rusher");
        dictionary.Add("skill");
        dictionary.Add("skin");
        dictionary.Add("shutdown");
        dictionary.Add("sort");
        dictionary.Add("ssh");
        dictionary.Add("sudo su");
        dictionary.Add("tail");
        dictionary.Add("tar");
        dictionary.Add("thread");
        dictionary.Add("touch");
        dictionary.Add("uniq");
        dictionary.Add("uper");
        dictionary.Add("URL");
        dictionary.Add("upgrade");
        dictionary.Add("usermod");
        dictionary.Add("wc");
        dictionary.Add("zcat");
    }
}