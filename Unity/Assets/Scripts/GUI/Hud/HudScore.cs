using AnimationOrTween;
using UnityEngine;
using System.Collections;

public class HudScore : Hud
{
	public GameObject PlayerOneScore;
	public GameObject PlayerTwoScore;

	private UILabel field_playerOneScoreText;
	private UILabel field_playerTwoScoreText;

	private TweenColor field_playerOneScoreTextTweenColor;
	private TweenColor field_playerTwoScoreTextTweenColor;

	private int field_playerOneScore;
	private int field_playerTwoScore;

	void Start ()
	{
		field_playerOneScoreText = PlayerOneScore.GetComponent<UILabel>();
		field_playerTwoScoreText = PlayerTwoScore.GetComponent<UILabel>();

		field_playerOneScoreTextTweenColor = PlayerOneScore.GetComponent<TweenColor>();
		field_playerTwoScoreTextTweenColor = PlayerTwoScore.GetComponent<TweenColor>();

		//field_playerOneScoreTextTweenColor.enabled = true;
		//field_playerTwoScoreTextTweenColor.enabled = true;

		//field_playerOneScoreTextTweenColor.PlayReverse();
		//field_playerTwoScoreTextTweenColor.PlayReverse();

		Global.ScoreManager.OnScoreChange += SetScore;
	}

	void Update ()
	{
		;
	}

	void OnDisable()
	{
		//if (field_playerOneScoreTextTweenColor != null)
		//	field_playerOneScoreTextTweenColor.value = field_playerOneScoreTextTweenColor.from;
		//if (field_playerTwoScoreTextTweenColor != null)
		//	field_playerTwoScoreTextTweenColor.value = field_playerTwoScoreTextTweenColor.from;
	}
	void OnEnable()
	{
		//if (field_playerOneScoreTextTweenColor != null)
		//	field_playerOneScoreTextTweenColor.value = field_playerOneScoreTextTweenColor.from;
		//if (field_playerTwoScoreTextTweenColor != null)
		//	field_playerTwoScoreTextTweenColor.value = field_playerTwoScoreTextTweenColor.from;
	}

	void SetScore(int param_playerOneScore, int param_playerTwoScore)
	{
		bool isScoreReset = param_playerOneScore == 0 && param_playerTwoScore == 0;

		if (field_playerOneScore != param_playerOneScore)
		{
			field_playerOneScore = param_playerOneScore;
			field_playerOneScoreText.text = field_playerOneScore.ToString();
			field_playerOneScoreTextTweenColor.ResetToBeginning();
			if (!isScoreReset)
				field_playerOneScoreTextTweenColor.PlayForward();
		}
		if (field_playerTwoScore != param_playerTwoScore)
		{
			field_playerTwoScore = param_playerTwoScore;
			field_playerTwoScoreText.text = field_playerTwoScore.ToString();
			field_playerTwoScoreTextTweenColor.ResetToBeginning();
			if (!isScoreReset)
				field_playerTwoScoreTextTweenColor.PlayForward();
		}
	}
}
