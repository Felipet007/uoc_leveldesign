using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoadLevel : MonoBehaviour {
	public string sceneToLoad;

	void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Player") == false) return;

		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneToLoad);
    }
}
