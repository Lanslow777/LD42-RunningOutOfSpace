using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject file;
	public int timerFile;
	int timeSinceLastSpawn = 0;
	FileNameGenerator generator = new FileNameGenerator();

	// Use this for initialization
	void Start () {
		
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
}
