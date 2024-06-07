using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
	[Header ("Movement Parameters")]
	[SerializeField] private float speed;
	[SerializeField] private float jumpPower;
	[SerializeField] private bool wizard;

	[Header("Multiple Jumps")]
	[SerializeField] private int extraJumps;
	private int jumpCounter;

	[Header("Coyote Parameters")]
	[SerializeField] private float coyoteTime;
	private float coyoteCounter;

	[Header("Wall Jumping")]
	[SerializeField] private float wallJumpX;
	[SerializeField] private float wallJumpY;

	[Header("Layers")]
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private LayerMask wallLayer;

	private Rigidbody2D body;
	private Animator anim;
	private BoxCollider2D boxCollider;
	//private float wallJumpCooldown;
	private float horizontalInput;
	private Vector3 left;
	private Vector3 right;

	private void Awake()
	{
		//Grab references from GameObject
		body = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
		if (wizard)
		{
			left = new Vector3(-0.86f, 0.86f, 0.86f);
			right = new Vector3(0.86f, 0.86f, 0.86f);
		}
		else
		{
			right = new Vector3(2, 2, 2);
			left = new Vector3(-2, 2, 2);
		}
			
	}

	private void Update()
	{
		horizontalInput = Input.GetAxis("Horizontal");

		//Flip player when moving sideways
		if (horizontalInput > 0.01f)
			transform.localScale = right;
		else if (horizontalInput < -0.01f)
			transform.localScale = left;
		

		//Set animator parameters
		anim.SetBool("run", horizontalInput != 0);
		anim.SetBool("grounded", isGrounded());

		//Jump
		if (Input.GetKeyDown(KeyCode.W))
			Jump();

		//Adjustable jump height
		if (Input.GetKeyDown(KeyCode.W) && body.velocity.y > 0)
			body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

		/*if(onWall())
		{
			//body.gravityScale = 1;
			//body.velocity = Vector2.zero;
		}
		else
		{
			
		}*/
		body.gravityScale = 2;
		body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

		if (isGrounded())
		{
			coyoteCounter = coyoteTime; //Reset when on the ground
			jumpCounter = extraJumps;
		}
		else
		{
			coyoteCounter -= Time.deltaTime;
		}
	}

	private void Jump()
	{

		if (coyoteCounter <= 0 && jumpCounter <= 0) return;

		
		if (isGrounded())
			body.velocity = new Vector2(body.velocity.x, jumpPower);
		else
		{
			if(coyoteCounter > 0)
			{
				body.velocity = new Vector2(body.velocity.x, jumpPower);
			}
			else
			{
				if(jumpCounter > 0)
				{
					body.velocity = new Vector2(body.velocity.x, jumpPower);
					jumpCounter--;
				}
			}
		}

		coyoteCounter = 0;
		
	}
	private void WallJump()
	{
		//body.AddForce(new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpX, wallJumpY));
		//wallJumpCooldown = 0;
	}
	private bool isGrounded()
	{
		RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
		return raycastHit.collider != null;
	}

	/*private bool onWall()
	{
		RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
		return raycastHit.collider != null;
	}*/
	public bool canAttack()
	{
		return horizontalInput == 0 && isGrounded();
	}
}
