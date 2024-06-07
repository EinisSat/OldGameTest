using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	//Follow player
	private Transform plPos;
	[SerializeField] private float aheadDistance;
	[SerializeField] private float cameraSpeed;
	private PlayerController play;
	private GameObject player;
	private float lookAhead;




	private Vector3 offset = new Vector3 (0f, 0f, -10f);
	private float smoothTime = 0.25f;
	private Vector3 velocity = Vector3.zero;

	private Transform target;
	private void Start()
	{
		play = GetComponent<PlayerController>();
		player = GameObject.FindGameObjectWithTag("Player");
		plPos = player.transform;
		target = player.transform;
	}
	private void Update()
	{
		//transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed * Time.deltaTime);
		Vector3 targetPosition = new Vector3(target.position.x + lookAhead, target.position.y, transform.position.z);
		lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * target.localScale.x), Time.deltaTime * cameraSpeed);
		/*Vector3 targetPosition = target.position + offset;*/
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
	}


}
