using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour
{
	private bool field_inited = false;

	public Camera Camera;
	public Pad PadLeft;
	public Pad PadRight;
	public Pad PadTop;
	public Pad PadBottom;
	public Ball Ball;
	public float PadPadding;

	[Range(0, 1f)]
	public float BallInitialSpeed;
	public float BallAcceleration;
	public Vector2 BallInitialDirection;

	private int field_playersCount = 1;

	private int field_screenWidth = 0;
	private int field_screenHeight = 0;
	private float field_screenDpiDefault = 96; // Default DPI for desktops and any weird platform
	private float field_screenDpi = 0;
	private Vector3 field_worldLeftTop = Vector3.zero;
	private Vector3 field_worldRightBottom = Vector3.zero;
	private float field_worldWidth = 0;
	private float field_worldHeight = 0;
	private float field_screenToWorldX = 0;
	private float field_screenToWorldY = 0;

	private float field_ballSpeed;
	private Vector2 field_ballDirection;

	private Vector3 field_ballSize;
	private Vector3 field_padHorizontalSize;
	private Vector3 field_padVerticalSize;
	private float field_padLeftPositionY;
	private float field_padRightPositionY;
	private float field_padTopPositionX;
	private float field_padBottomPositionX;
	private Vector2 field_ballPositionRelative = new Vector2(0, 0);
	private float field_padOnePosition = 0.5f;
	private float field_padTwoPosition = 0.5f;
	private DirectionEnum field_gameDirection;
	//private ScreenOrientation field_screenOrientaion;

	//private bool field_gameStarted;
	//private bool field_gamePaused;
	private bool field_gameStateShowPads = false;
	//private bool field_gameStateShowBall = true;
	private bool field_scoreLeftHit = false;
	private bool field_scoreRightHit = false;
	private bool field_scoreTopHit = false;
	private bool field_scoreBottomHit = false;

	void Start()
	{
		//field_gameState = GameStateIs.RUNNING;
		//Reset();
		//Resize();
		//field_ballSpeed = BallInitialSpeed;
		//field_ballDirection = BallInitialDirection;
		//Resize();
		//Rerotate();
		//GameStop(true);
	}

	void Update()
	{
		//if (field_screenOrientaion != Screen.orientation)
		//{
		//    Rerotate();
		//}
		if (field_screenWidth != Screen.width || field_screenHeight != Screen.height)
		{
			Resize();
		}
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	bool HasCollisionPoint(GameObject param_gameObject, Vector3 param_pointFrom, Vector3 param_pointTo, out RaycastHit param_hit)
	{
		Vector3 direction = param_pointTo - param_pointFrom;
		float distance = direction.magnitude;
		if (distance < 0.000001f)
		{
			param_hit = new RaycastHit();
			return false;
		}
		direction.Normalize();
		Ray ray = new Ray(param_pointFrom, direction);
		//RaycastHit hit;
		if (param_gameObject.collider.Raycast(ray, out param_hit, distance))
		{
			if (param_hit.distance > direction.magnitude)
			{
				return false;
			}
			//param_point = ray.GetPoint(hit.distance);
			//param_distance = hit.distance;
			//param_normal = hit.normal;
			//Debug.Log("Hit distance = " + param_hit.distance);
			//Debug.Log("Direction magnitude = " + direction.magnitude);
			return true;
		}
		else
		{
			return false;
		}
	}

	Vector3 MoveBall(GameObject[] param_gameObjects, Vector3 param_source, Vector3 param_destination)
	{
		RaycastHit hitNearest = new RaycastHit();
		RaycastHit hitTemp;
		//Vector3 nearestCollisionPosition = Vector3.zero;
		//float nearestCollisionDistance = 0;
		//Vector3 nearestCollisionNormal = Vector3.zero;

		//Vector3 tempCollisionPosition = Vector3.zero;
		//float tempCollisionDistance = 0;
		//Vector3 tempCollisionNormal = Vector3.zero;

		bool collisionFound = false;

		for (int i = 0; i < param_gameObjects.Length; i++)
		{
			if (HasCollisionPoint(param_gameObjects[i], param_source, param_destination, out hitTemp))
			{
				if (!collisionFound || hitTemp.distance < hitNearest.distance)
				{
					hitNearest = hitTemp;
				}
				collisionFound = true;
			}
		}

		if (collisionFound)
		{
			Vector3 destination = hitNearest.point + Vector3.Reflect(param_destination - hitNearest.point, hitNearest.normal);
			field_ballDirection = Vector3.Reflect(field_ballDirection, hitNearest.normal);
			//Debug.Log("Ball collision, moved from " + param_destination.x + " to " + destination.x);
			//Debug.Log("Collision point = " + hitNearest.point.x);
			//Debug.Log("Ball source = " + param_source.x);
			//Debug.Log("Original = " + (param_destination - hitNearest.point).x);
			//Debug.Log("Reflected = " + Vector3.Reflect(param_destination - hitNearest.point, hitNearest.normal).x);
			//Debug.Log("Normal = " + hitNearest.normal);
			return destination;//MoveBall(param_gameObjects, hitNearest.point, param_destination);
		}
		else
		{
			return param_destination;
		}

		//if (HasCollisionPoint(PadLeft.gameObject, param_source, param_destination, ref positionCollisionPoint))
		//{
		//	field_ballDirection.x = -field_ballDirection.x;
		//	collisionFound
		//}
		//if (HasCollisionPoint(PadRight.gameObject, param_source, param_destination, ref positionCollisionPoint))
		//{
		//	field_ballDirection.x = -field_ballDirection.x;
		//}
		//if (HasCollisionPoint(PadTop.gameObject, param_source, param_destination, ref positionCollisionPoint))
		//{
		//	field_ballDirection.y = -field_ballDirection.y;
		//}
		//if (HasCollisionPoint(PadBottom.gameObject, param_source, param_destination, ref positionCollisionPoint))
		//{
		//	field_ballDirection.y = -field_ballDirection.y;
		//}
	}

	void FixedUpdate ()
	{
		//if (field_ballDirection.x > 0 && PadRight.IsHit())
		//{
		//	field_ballDirection.x = -field_ballDirection.x;
		//}
		//if (field_ballDirection.x < 0 && PadLeft.IsHit())
		//{
		//	field_ballDirection.x = -field_ballDirection.x;
		//}
		//if (field_ballDirection.y > 0 && PadTop.IsHit())
		//{
		//	field_ballDirection.y = -field_ballDirection.y;
		//}
		//if (field_ballDirection.y < 0 && PadBottom.IsHit())
		//{
		//	field_ballDirection.y = -field_ballDirection.y;
		//}

		// Move the ball
		if (Global.StateManager.GameState == GameState.IDLE || Global.StateManager.GameState == GameState.RUNNING)
		{
			Vector3 positionPrevious = Ball.transform.position;
			Vector3 positionNext = positionPrevious + new Vector3(field_ballDirection.x, field_ballDirection.y, 0).normalized * field_ballSpeed * Time.deltaTime * field_worldWidth;

			GameObject[] pads = new GameObject[]{PadLeft.gameObject, PadRight.gameObject, PadTop.gameObject, PadBottom.gameObject};
			positionNext = MoveBall(pads, positionPrevious, positionNext);

			// Top Border
			if (positionNext.y > field_worldLeftTop.y - field_ballSize.y)
			{
				positionNext.y -= (positionNext.y - (field_worldLeftTop.y - field_ballSize.y)) * 2;
				field_ballDirection.y = -field_ballDirection.y;
				if (field_gameDirection == DirectionEnum.VERTICAL)
				{
					field_ballSpeed = BallInitialSpeed;
					Global.ScoreManager.PlayerOneScore++;
				}
			}
			// Bottom Border
			if (positionNext.y < field_worldRightBottom.y + field_ballSize.y)
			{
				positionNext.y -= (positionNext.y - (field_worldRightBottom.y + field_ballSize.y)) * 2;
				field_ballDirection.y = -field_ballDirection.y;
				if (field_gameDirection == DirectionEnum.VERTICAL)
				{
					field_ballSpeed = BallInitialSpeed;
					Global.ScoreManager.PlayerTwoScore++;
				}
			}
			// Left Border
			if (positionNext.x < field_worldLeftTop.x + field_ballSize.x)
			{
				positionNext.x -= (positionNext.x - (field_worldLeftTop.x + field_ballSize.x)) * 2;
				field_ballDirection.x = -field_ballDirection.x;
				if (field_gameDirection == DirectionEnum.HORIZONTAL)
				{
					field_ballSpeed = BallInitialSpeed;
					Global.ScoreManager.PlayerOneScore++;
				}
			}
			// Right Border
			if (positionNext.x > field_worldRightBottom.x - field_ballSize.x)
			{
				positionNext.x -= (positionNext.x - (field_worldRightBottom.x - field_ballSize.x)) * 2;
				field_ballDirection.x = -field_ballDirection.x;
				if (field_gameDirection == DirectionEnum.HORIZONTAL)
				{
					field_ballSpeed = BallInitialSpeed;
					Global.ScoreManager.PlayerTwoScore++;
				}
			}

			// Save relative ball position
			field_ballPositionRelative = new Vector2(positionNext.x / field_worldWidth, positionNext.y / field_worldHeight);
			// Move the ball
			Ball.transform.position = positionNext;
			// Accelerate the ball
			if (Global.StateManager.GameState == GameState.RUNNING)
			{
				field_ballSpeed += BallAcceleration * Time.deltaTime;
			}
		}
	}

	void Resize()
	{
		field_screenWidth = Screen.width;
		field_screenHeight = Screen.height;
		field_screenDpi = Screen.dpi;
		if (field_screenDpi == 0)
		{
			field_screenDpi = field_screenDpiDefault;
		}

		field_worldLeftTop = Camera.ScreenToWorldPoint(new Vector3(0, field_screenHeight, 10));
		field_worldRightBottom = Camera.ScreenToWorldPoint(new Vector3(field_screenWidth, 0, 10));
		field_worldWidth = field_worldRightBottom.x - field_worldLeftTop.x;
		field_worldHeight = field_worldLeftTop.y - field_worldRightBottom.y;

		field_screenToWorldX = field_worldWidth / field_screenWidth;
		field_screenToWorldY = field_worldHeight / field_screenHeight;

		field_ballSize = new Vector3((field_worldWidth + field_worldHeight) / 200, (field_worldWidth + field_worldHeight) / 200, (field_worldWidth + field_worldHeight) / 200);
		field_padVerticalSize = new Vector3(field_worldWidth / 100, field_worldHeight / 10, (field_worldWidth + field_worldHeight) / 200);
		field_padHorizontalSize = new Vector3(field_worldHeight / 100, field_worldWidth / 10, (field_worldWidth + field_worldHeight) / 200);

		Debug.Log("World Left Top is " + field_worldLeftTop);
		Debug.Log("World Right Bottom is " + field_worldRightBottom);
		Debug.Log("Screen DPI is " + field_screenDpi);
		Debug.Log("Resized to " + field_screenWidth + "x" + field_screenHeight);

		Ball.transform.localScale = field_ballSize;
		PadLeft.transform.localScale = field_padVerticalSize;
		PadRight.transform.localScale = field_padVerticalSize;
		PadTop.transform.localScale = field_padHorizontalSize;
		PadBottom.transform.localScale = field_padHorizontalSize;

		SetPadOnePosition(field_padOnePosition);
		SetPadTwoPosition(field_padTwoPosition);
		SetBallPosition(field_ballPositionRelative);

		if (field_screenWidth > field_screenHeight && field_gameDirection != DirectionEnum.HORIZONTAL)
		{
			field_gameDirection = DirectionEnum.HORIZONTAL;
			field_ballPositionRelative = new Vector2(field_ballPositionRelative.y, field_ballPositionRelative.x);
			SetBallPosition(field_ballPositionRelative);
		}
		if (field_screenWidth < field_screenHeight && field_gameDirection != DirectionEnum.VERTICAL)
		{
			field_gameDirection = DirectionEnum.VERTICAL;
			field_ballPositionRelative = new Vector2(field_ballPositionRelative.y, field_ballPositionRelative.x);
			SetBallPosition(field_ballPositionRelative);
		}
		ShowPads();
	}

	//void Rerotate()
	//{
	//    field_screenOrientaion = Screen.orientation;
	//    ShowPads();
	//}

	public void ShowPads()
	{
		if (field_gameStateShowPads)
		{
			if (field_gameDirection == DirectionEnum.HORIZONTAL)
			{
				PadLeft.gameObject.SetActive(true);
				PadRight.gameObject.SetActive(true);
				PadTop.gameObject.SetActive(false);
				PadBottom.gameObject.SetActive(false);
			}
			else
			{
				PadLeft.gameObject.SetActive(false);
				PadRight.gameObject.SetActive(false);
				PadTop.gameObject.SetActive(true);
				PadBottom.gameObject.SetActive(true);
			}
		}
	}
	public void HidePads()
	{
		PadLeft.gameObject.SetActive(false);
		PadRight.gameObject.SetActive(false);
		PadTop.gameObject.SetActive(false);
		PadBottom.gameObject.SetActive(false);
	}

	public void Reset()
	{
		field_ballSpeed = BallInitialSpeed;
		field_ballDirection = BallInitialDirection;

		SetBallPosition(Vector2.zero);//new Vector2(0.5f, 0.5f));
		SetPadOnePosition(0.5f);
		SetPadTwoPosition(0.5f);
	}
	public void GameStart()
	{
		field_gameStateShowPads = true;
		ShowPads();
		Reset();

		//Time.timeScale = 1;
		//Debug.Log("Game started");
	}
	public void GamePause()
	{
		field_gameStateShowPads = true;
		ShowPads();

		//Time.timeScale = 0;
		//Debug.Log("Game paused");
	}
	public void GameResume()
	{
		field_gameStateShowPads = true;
		ShowPads();

		//Time.timeScale = 1;
		//Debug.Log("Game resumed");
	}
	public void GameStop()
	{
		field_gameStateShowPads = false;
		HidePads();
		Reset();

		//Time.timeScale = 1;	
		//Debug.Log("Game stopped");
	}
	public void GameExit()
	{
		Application.Quit();
	}
	public void GameSet(int param_playersCount)
	{
		field_playersCount = param_playersCount;
	}
	public void SetBallPosition(Vector2 param_positionRelative)
	{
		float halfWidth = (field_worldWidth - field_ballSize.x) / 2;
		float halfHeight = (field_worldHeight - field_ballSize.y) / 2;
		field_ballPositionRelative = new Vector2(Mathf.Clamp(param_positionRelative.x, -halfWidth, halfWidth), Mathf.Clamp(param_positionRelative.y, -halfHeight, halfHeight));
		Ball.transform.position = new Vector3(field_ballPositionRelative.x * field_worldWidth, field_ballPositionRelative.y * field_worldHeight, Ball.transform.position.z);
	}
	public void SetPadOnePosition(float param_position)
	{
		field_padOnePosition = param_position;

		float halfWidth = (field_worldWidth - field_padHorizontalSize.x) / 2;
		float halfHeight = (field_worldHeight - field_padVerticalSize.y) / 2;

		field_padLeftPositionY = Mathf.Clamp(field_worldHeight * (param_position - 0.5f), -halfHeight, halfHeight);
		//if (field_padLeftPositionY > (field_worldHeight - field_padVerticalSize.y) / 2)
		//{
		//	field_padLeftPositionY = (field_worldHeight - field_padVerticalSize.y) / 2;
		//}
		//if (field_padLeftPositionY < -(field_worldHeight - field_padVerticalSize.y) / 2)
		//{
		//	field_padLeftPositionY = -(field_worldHeight - field_padVerticalSize.y) / 2;
		//}
		PadLeft.transform.position = new Vector3(field_worldLeftTop.x + PadPadding * field_screenDpi * field_screenToWorldX, field_padLeftPositionY, PadLeft.transform.position.z);

		field_padTopPositionX = Mathf.Clamp(field_worldWidth * (param_position - 0.5f), -halfWidth, halfWidth);
		//if (field_padTopPositionX > (field_worldWidth - field_padHorizontalSize.x) / 2)
		//{
		//	field_padTopPositionX = (field_worldWidth - field_padHorizontalSize.x) / 2;
		//}
		//if (field_padTopPositionX < -(field_worldWidth - field_padHorizontalSize.x) / 2)
		//{
		//	field_padTopPositionX = -(field_worldWidth - field_padHorizontalSize.x) / 2;
		//}
		PadTop.transform.position = new Vector3(field_padTopPositionX, field_worldLeftTop.y - PadPadding * field_screenDpi * field_screenToWorldY, PadLeft.transform.position.z);
	}
	public void SetPadTwoPosition(float param_position)
	{
		field_padTwoPosition = param_position;

		float halfWidth = (field_worldWidth - field_padHorizontalSize.x) / 2;
		float halfHeight = (field_worldHeight - field_padVerticalSize.y) / 2;

		field_padRightPositionY = Mathf.Clamp(field_worldHeight * (param_position - 0.5f), -halfHeight, halfHeight);
		//field_padRightPositionY = field_worldHeight * (param_position - 0.5f);
		//if (field_padRightPositionY > (field_worldHeight - field_padVerticalSize.y) / 2)
		//{
		//	field_padRightPositionY = (field_worldHeight - field_padVerticalSize.y) / 2;
		//}
		//if (field_padRightPositionY < -(field_worldHeight - field_padVerticalSize.y) / 2)
		//{
		//	field_padRightPositionY = -(field_worldHeight - field_padVerticalSize.y) / 2;
		//}
		PadRight.transform.position = new Vector3(field_worldRightBottom.x - PadPadding * field_screenDpi * field_screenToWorldX, field_padRightPositionY, PadRight.transform.position.z);

		field_padBottomPositionX = Mathf.Clamp(field_worldWidth * (param_position - 0.5f), -halfWidth, halfWidth);
		//field_padBottomPositionX = field_worldWidth * (param_position - 0.5f);
		//if (field_padBottomPositionX > (field_worldWidth - field_padHorizontalSize.y) / 2)
		//{
		//	field_padBottomPositionX = (field_worldWidth - field_padHorizontalSize.y) / 2;
		//}
		//if (field_padBottomPositionX < -(field_worldWidth - field_padHorizontalSize.y) / 2)
		//{
		//	field_padBottomPositionX = -(field_worldWidth - field_padHorizontalSize.y) / 2;
		//}
		PadBottom.transform.position = new Vector3(field_padBottomPositionX, field_worldRightBottom.y + PadPadding * field_screenDpi * field_screenToWorldY, PadBottom.transform.position.z);
	}
}
