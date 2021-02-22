using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
	// When an object enters the finish zone, let the
	// game manager know that the current game has ended
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) ;
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("End");
		}
	}
}
