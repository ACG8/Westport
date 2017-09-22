using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public Button localMultiplayer;

	void Start() {
		Button localMult = localMultiplayer.GetComponent<Button> ();
		localMult.onClick.AddListener (LocalMultiplayer);
	}

	void LocalMultiplayer() {
		SceneManager.LoadScene ("localMultiplayer");
	}
		


}
