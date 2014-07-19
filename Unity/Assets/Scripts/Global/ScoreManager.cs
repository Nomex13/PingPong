using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	private bool field_inited = false;

	private int field_playerOneScore;
	public int PlayerOneScore
	{
		get
		{
			return field_playerOneScore;
		}
		set
		{
			field_playerOneScore = value;

			if (OnScoreChange != null)
				OnScoreChange(field_playerOneScore, field_playerTwoScore);
		}
	}
	private int field_playerTwoScore;
	public int PlayerTwoScore
	{
		get
		{
			return field_playerTwoScore;
		}
		set
		{
			field_playerTwoScore = value;

			if (OnScoreChange != null)
				OnScoreChange(field_playerOneScore, field_playerTwoScore);
		}
	}

	public delegate void ScoreChange(int param_playerOnewScore, int param_playerTwoScore);
	public event ScoreChange OnScoreChange;

	void Start()
	{
		;
	}
	
	void Update()
	{
		;
	}

	public void Init()
	{
		if (field_inited)
			return;

		field_inited = true;
	}

	public void SetScore(int param_playerOneScore, int param_playerTwoScore)
	{
		field_playerOneScore = param_playerOneScore;
		field_playerTwoScore = param_playerTwoScore;

		if (OnScoreChange != null)
			OnScoreChange(field_playerOneScore, field_playerTwoScore);
	}
}
