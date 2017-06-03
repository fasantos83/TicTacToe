using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;

	private string playerSide;

	private void Awake(){
		playerSide = "X";
		SetControllerReferenceOnButtons();
	}

	public void SetControllerReferenceOnButtons(){
		for (int i = 0; i < buttonList.Length; i++) {
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}
	}

	public string GetPlayerSide(){
		return playerSide;
	}

	public void EndTurn(){
		if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide ||
		    buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide ||
		    buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide ||
		    buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide ||
		    buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide ||
		    buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide ||
		    buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide ||
		    buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) {
			GameOver();
		} else {
			ChangeSides();
		}
	}

	private void ChangeSides(){
		playerSide = playerSide == "X" ? "O": "X";
	}

	private void GameOver(){
		for (int i = 0; i < buttonList.Length; i++) {
			buttonList[i].GetComponentInParent<Button>().interactable = false;
		}
	}
}
