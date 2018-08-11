using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject file;
	public int timerFile;
	public InputField inputField;
	int timeSinceLastSpawn = 0;
	FileNameGenerator generator = new FileNameGenerator();

	// Use this for initialization
	void Start () {
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

	public void SpawnFile(){
		GameObject newModulePrefab = file;
		GameObject newModule =(GameObject) Instantiate(newModulePrefab);
		newModule.transform.position = new Vector2(Random.Range (-6, 6), Random.Range (-4, 4));
		string fileName = generator.GetRandomName();
		newModule.name = fileName;
		newModule.transform.GetChild (0).gameObject.GetComponent<TextMesh> ().text = fileName;
	}

	void AcceptStringInput(string userInput)
	{
		GameObject fileToDelete = GameObject.Find (userInput);
		//Si le fichier existe le supprimer et mettre à jour les scores et autre éléments de l'UI, sinon signalé une erreur
		if (fileToDelete != null) {
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
}
