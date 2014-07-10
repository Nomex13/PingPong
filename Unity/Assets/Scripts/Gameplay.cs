using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour
{
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
	private Vector2 field_ballRelativePosition = new Vector2(0, 0);
	private float field_padOnePosition = 0.5f;
	private float field_padTwoPosition = 0.5f;
	private DirectionEnum field_gameDirection;
	//private ScreenOrientation field_screenOrientaion;

	//private bool field_gameStarted;
	//private bool field_gamePaused;
	private GameStateIs field_gameState;
	private bool field_gameStateShowPads = false;
	//private bool field_gameStateShowBall = true;

	void Start()
	{
		//field_gameState = GameStateIs.RUNNING;
		//Reset();
		//Resize();
		//field_ballSpeed = BallInitialSpeed;
		//field_ballDirection = BallInitialDirection;
		Resize();
		//Rerotate();
		GameStop(true);
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

	void FixedUpdate ()
	{
		if (field_ballDirection.x > 0 && PadRight.IsHit())
		{
			field_ballDirection.x = -field_ballDirection.x;
		}
		if (field_ballDirection.x < 0 && PadLeft.IsHit())
		{
			field_ballDirection.x = -field_ballDirection.x;
		}
		if (field_ballDirection.y > 0 && PadTop.IsHit())
		{
			field_ballDirection.y = -field_ballDirection.y;
		}
		if (field_ballDirection.y < 0 && PadBottom.IsHit())
		{
			field_ballDirection.y = -field_ballDirection.y;
		}

		// Move the ball
		if (field_gameState == GameStateIs.RUNNING || field_gameState == GameStateIs.STOPPED)
		{
			Vector3 positionPrevious = Ball.transform.position;
			Vector3 positionNext = positionPrevious + new Vector3(field_ballDirection.x, field_ballDirection.y, 0).normalized * field_ballSpeed * Time.deltaTime * field_worldWidth;
			if (positionNext.y > field_worldLeftTop.y - field_ballSize.y)
			{
				positionNext.y -= (positionNext.y - (field_worldLeftTop.y - field_ballSize.y)) * 2;
				field_ballDirection.y = -field_ballDirection.y;
			}
			if (positionNext.y < field_worldRightBottom.y + field_ballSize.y)
			{
				positionNext.y -= (positionNext.y - (field_worldRightBottom.y + field_ballSize.y)) * 2;
				field_ballDirection.y = -field_ballDirection.y;
			}
			if (positionNext.x < field_worldLeftTop.x + field_ballSize.x)
			{
				positionNext.x -= (positionNext.x - (field_worldLeftTop.x + field_ballSize.x)) * 2;
				field_ballDirection.x = -field_ballDirection.x;
			}
			if (positionNext.x > field_worldRightBottom.x - field_ballSize.x)
			{
				positionNext.x -= (positionNext.x - (field_worldRightBottom.x - field_ballSize.x)) * 2;
				field_ballDirection.x = -field_ballDirection.x;
			}
			// Save relative ball position
			field_ballRelativePosition = new Vector2(positionNext.x / field_worldWidth, positionNext.y / field_worldHeight);
			// Move the ball
			Ball.transform.position = positionNext;
			// Accelerate the ball
			if (field_gameState == GameStateIs.RUNNING)
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
			field_screenDpi = 160; // Default DPI for desktops and any weird platform
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
		SetBallPosition(field_ballRelativePosition);

		if (field_screenWidth > field_screenHeight && field_gameDirection != DirectionEnum.HORIZONTAL)
		{
			field_gameDirection = DirectionEnum.HORIZONTAL;
			field_ballRelativePosition = new Vector2(field_ballRelativePosition.y, field_ballRelativePosition.x);
			SetBallPosition(field_ballRelativePosition);
		}
		if (field_screenWidth < field_screenHeight && field_gameDirection != DirectionEnum.VERTICAL)
		{
			field_gameDirection = DirectionEnum.VERTICAL;
			field_ballRelativePosition = new Vector2(field_ballRelativePosition.y, field_ballRelativePosition.x);
			SetBallPosition(field_ballRelativePosition);
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
	void GameReset()
	{
		field_ballSpeed = BallInitialSpeed;
		field_ballDirection = BallInitialDirection;

		SetBallPosition(new Vector2(0.5f, 0.5f));
		SetPadOnePosition(0.5f);
		SetPadTwoPosition(0.5f);
	}
	public void GameStart()
	{
		if (field_gameState != GameStateIs.STOPPED)
			return;
		field_gameState = GameStateIs.RUNNING;

		field_gameStateShowPads = true;
		ShowPads();
		GameReset();

		Time.timeScale = 1;
		Debug.Log("Game started");
	}
	public void GamePause()
	{
		if (field_gameState != GameStateIs.RUNNING)
			return;
		field_gameState = GameStateIs.PAUSED;

		field_gameStateShowPads = true;

		Time.timeScale = 0;
		Debug.Log("Game paused");
	}
	public void GameResume()
	{
		if (field_gameState != GameStateIs.PAUSED)
			return;
		field_gameState = GameStateIs.RUNNING;

		field_gameStateShowPads = true;

		Time.timeScale = 1;
		Debug.Log("Game resumed");
	}
	public void GameStop(bool param_force = false)
	{
		if (!param_force && field_gameState != GameStateIs.RUNNING && field_gameState != GameStateIs.PAUSED)
			return;
		field_gameState = GameStateIs.STOPPED;

		field_gameStateShowPads = false;
		HidePads();
		GameReset();

		Time.timeScale = 1;
		Debug.Log("Game stopped");
	}
	public void GameExit()
	{
		Application.Quit();
	}
	public void GameSet(int param_playersCount)
	{
		field_playersCount = param_playersCount;
	}
	public void SetBallPosition(Vector2 param_position)
	{
		field_ballRelativePosition = param_position;
		if (field_ballRelativePosition.x > (field_worldWidth - field_ballSize.x) / 2)
		{
			field_ballRelativePosition.x = (field_worldWidth - field_ballSize.x) / 2;
		}
		if (field_ballRelativePosition.x < -(field_worldWidth - field_ballSize.x) / 2)
		{
			field_ballRelativePosition.x = -(field_worldWidth - field_ballSize.x) / 2;
		}
		if (field_ballRelativePosition.y > (field_worldHeight - field_ballSize.y) / 2)
		{
			field_ballRelativePosition.y = (field_worldHeight - field_ballSize.y) / 2;
		}
		if (field_ballRelativePosition.y < -(field_worldHeight - field_ballSize.y) / 2)
		{
			field_ballRelativePosition.y = -(field_worldHeight - field_ballSize.y) / 2;
		}
		Ball.transform.position = new Vector3(field_ballRelativePosition.x * field_worldWidth, field_ballRelativePosition.y * field_worldHeight, Ball.transform.position.z);
	}
	public void SetPadOnePosition(float param_position)
	{
		field_padOnePosition = param_position;

		field_padLeftPositionY = field_worldHeight * (param_position - 0.5f);
		if (field_padLeftPositionY > (field_worldHeight - field_padVerticalSize.y) / 2)
		{
			field_padLeftPositionY = (field_worldHeight - field_padVerticalSize.y) / 2;
		}
		if (field_padLeftPositionY < -(field_worldHeight - field_padVerticalSize.y) / 2)
		{
			field_padLeftPositionY = -(field_worldHeight - field_padVerticalSize.y) / 2;
		}
		PadLeft.transform.position = new Vector3(field_worldLeftTop.x + PadPadding * field_screenDpi * field_screenToWorldX, field_padLeftPositionY, PadLeft.transform.position.z);

		field_padTopPositionX = field_worldWidth * (param_position - 0.5f);
		if (field_padTopPositionX > (field_worldWidth - field_padHorizontalSize.x) / 2)
		{
			field_padTopPositionX = (field_worldWidth - field_padHorizontalSize.x) / 2;
		}
		if (field_padTopPositionX < -(field_worldWidth - field_padHorizontalSize.x) / 2)
		{
			field_padTopPositionX = -(field_worldWidth - field_padHorizontalSize.x) / 2;
		}
		PadTop.transform.position = new Vector3(field_padTopPositionX, field_worldLeftTop.y - PadPadding * field_screenDpi * field_screenToWorldY, PadLeft.transform.position.z);
	}
	public void SetPadTwoPosition(float param_position)
	{
		field_padTwoPosition = param_position;

		field_padRightPositionY = field_worldHeight * (param_position - 0.5f);
		if (field_padRightPositionY > (field_worldHeight - field_padVerticalSize.y) / 2)
		{
			field_padRightPositionY = (field_worldHeight - field_padVerticalSize.y) / 2;
		}
		if (field_padRightPositionY < -(field_worldHeight - field_padVerticalSize.y) / 2)
		{
			field_padRightPositionY = -(field_worldHeight - field_padVerticalSize.y) / 2;
		}
		PadRight.transform.position = new Vector3(field_worldRightBottom.x - PadPadding * field_screenDpi * field_screenToWorldX, field_padRightPositionY, PadRight.transform.position.z);

		field_padBottomPositionX = field_worldWidth * (param_position - 0.5f);
		if (field_padBottomPositionX > (field_worldWidth - field_padHorizontalSize.y) / 2)
		{
			field_padBottomPositionX = (field_worldWidth - field_padHorizontalSize.y) / 2;
		}
		if (field_padBottomPositionX < -(field_worldWidth - field_padHorizontalSize.y) / 2)
		{
			field_padBottomPositionX = -(field_worldWidth - field_padHorizontalSize.y) / 2;
		}
		PadBottom.transform.position = new Vector3(field_padBottomPositionX, field_worldRightBottom.y + PadPadding * field_screenDpi * field_screenToWorldY, PadBottom.transform.position.z);
	}
	public enum GameStateIs
	{
		UNKNOWN,
		DEMO,
		STOPPED,
		PAUSED,
		RUNNING
	}
}
