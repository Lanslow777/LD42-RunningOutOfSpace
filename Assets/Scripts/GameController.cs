using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject file;
	public int timerFile;
	public InputField inputField;
	public int maxSpace;
	public Text ScoreText;
	public Text RunningSpaceText;

	int score = 0;
	int spaceUsed = 0;
	int timeSinceLastSpawn = 0;
	FileNameGenerator generator = new FileNameGenerator();

	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score", 0);
		updateScore (0);
		updateSpace (0);
		InputComplete ();
	}

	void Awake(){
		inputField.onEndEdit.AddListener (AcceptStringInput);
	}

	void FixedUpdate () {
		//Spawn a new file
		timeSinceLastSpawn++;
		if (timeSinceLastSpawn >= timerFile) {
			timeSinceLastSpawn = 0;
			SpawnFile ();
		}
	}

	//Crée un nouveau fichier et augmente l'espace utilisé, Game Over si plus d'espace.
	public void SpawnFile(){
		GameObject newModulePrefab = file;
		GameObject newModule =(GameObject) Instantiate(newModulePrefab);
		newModule.transform.position = new Vector3(Random.Range (-6, 6), Random.Range (-4, 4), Random.Range(-5,5));
		string fileName = generator.GetRandomName();
		newModule.name = fileName;
		newModule.transform.GetChild (0).gameObject.GetComponent<TextMesh> ().text = fileName;

		if (spaceUsed > maxSpace) {
			spaceUsed = maxSpace;

		}
		updateSpace (fileName.Length);
	}

	void AcceptStringInput(string userInput)
	{
		GameObject fileToDelete = GameObject.Find (userInput);
		//Si le fichier existe le supprimer et mettre à jour les scores et autre éléments de l'UI, sinon signalé une erreur
		if (fileToDelete != null) {
			updateScore (userInput.Length);
			updateSpace (-userInput.Length);
			Destroy (fileToDelete);
		} else {

		}

		InputComplete ();
	}

	void InputComplete()
	{
		inputField.ActivateInputField ();
		inputField.text = null;
	}

	public void updateScore(int addScore){
		score += addScore;
		PlayerPrefs.SetInt ("Score", score);
		ScoreText.text = "Score : " + score;
	}

	public void updateSpace(int removeSpace){
		spaceUsed += removeSpace;
		RunningSpaceText.text = "Space Used : " + spaceUsed + "/" + maxSpace;
	}
}
