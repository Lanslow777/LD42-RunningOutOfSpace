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
	public Text ErrorGameOverText;
	public AudioClip gameOverSound;

	int score = 0;
	int spaceUsed = 0;
	int timeSinceLastSpawn = 0;
	FileNameGenerator generator = new FileNameGenerator();
	bool gameOver = false;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		inputField.ActivateInputField ();
		ErrorGameOverText.color = Color.clear;
		//score = PlayerPrefs.GetInt ("Score", 0);
		updateScore (0);
		updateSpace (0);
		InputComplete ();
		audioSource = GetComponents<AudioSource> ()[0];
	}

	void Awake(){
		inputField.onEndEdit.AddListener (AcceptStringInput);
	}

	void FixedUpdate () {
		//Spawn a new file
		timeSinceLastSpawn++;
		if (timeSinceLastSpawn >= timerFile && ! gameOver) {
			timeSinceLastSpawn = 0;
			SpawnFile ();
		}
	}

	//Crée un nouveau fichier et augmente l'espace utilisé, Game Over si plus d'espace.
	public void SpawnFile(){
		GameObject newModulePrefab = file;
		GameObject newModule =(GameObject) Instantiate(newModulePrefab);
		newModule.transform.position = new Vector3(Random.Range (-7, 7), Random.Range (-4, 4), Random.Range(-5,5));
		string fileName = generator.GetRandomName();
		newModule.name = fileName;
		newModule.transform.GetChild (0).gameObject.GetComponent<TextMesh> ().text = fileName;
		updateSpace (fileName.Length);

		if (spaceUsed > maxSpace) {
			spaceUsed = maxSpace;
			gameOver = true;
			audioSource.clip = gameOverSound;
			audioSource.loop = false;
			audioSource.Play();
			ErrorGameOverText.text = "Game Over";
			ErrorGameOverText.color = Color.red;
			inputField.DeactivateInputField ();
		}
	}

	IEnumerator DisplayError(string filename){
		if (!gameOver) {
			ErrorGameOverText.text = "Error, No file " + filename + " detected";
			ErrorGameOverText.color = Color.red;
			yield return new WaitForSeconds (1);
			ErrorGameOverText.color = Color.clear;
		}
	}

	void AcceptStringInput(string userInput)
	{
		if (!gameOver) {
            //si le joueur appuie sur echap, le jeu est réinitialisé
            if (Input.GetKeyDown(KeyCode.Escape) == true)
            {


                ResetGame();
                InputComplete();
            }
            else
            {
                GameObject fileToDelete = GameObject.Find(userInput);
                //Si le fichier existe le supprimer et mettre à jour les scores et autre éléments de l'UI, sinon signalé une erreur
                if (fileToDelete != null)
                {
                    updateScore(userInput.Length);
                    updateSpace(-userInput.Length);
                    Destroy(fileToDelete);
                }
                else
                {
                    StartCoroutine(DisplayError(userInput));
                }

                InputComplete();
            }
		}
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

    private void DisplayScore()
    {
        ScoreText.text = "Score : " + score;
    }

    private void DisplaySpaceUsed()
    {
        RunningSpaceText.text = "Space Used : " + spaceUsed + "/" + maxSpace;
    }

    public void ResetGame()
    {
        //reset
        GameObject[] gameObjectList = GameObject.FindObjectsOfType<GameObject>();
        int maxValue = gameObjectList.Length;
        for (int i = maxValue - 1; i > -1; i--)
        {
            GameObject gameObjectToDelete = gameObjectList[i];
            if ("File".Equals(gameObjectToDelete.tag))
            {
                Destroy(gameObjectToDelete);
            }
        }
        score = 0;
        spaceUsed = 0;
        DisplayScore();
        DisplaySpaceUsed();
    }
}
