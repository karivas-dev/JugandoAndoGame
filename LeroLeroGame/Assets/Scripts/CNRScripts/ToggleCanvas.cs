using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
	public Canvas canvas;
	public KeyCode hideKey = KeyCode.X;
	public bool isactive = true;
	public GameObject player;


	private void Start()
	{
		player.GetComponent<PlayerController>().enabled = false;
	}
	private void Update()
	{

		if (Input.GetKeyDown(hideKey))
		{
			player.GetComponent<PlayerController>().enabled = true;
			canvas.gameObject.SetActive(false);
		}


	}
}
