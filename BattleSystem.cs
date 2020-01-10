using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Button quitButton;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPlatform;
    public Transform enemyPlatform;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    private InputField input;

    public GameObject whiteStar;

    public Transform Line1Pos;
    public Transform Line2Pos;
    public Transform Line3Pos;
    public Transform Line4Pos;
    public Transform Line5Pos;
    public Transform Line6Pos;
    public Transform Line7Pos;
    public Transform Line8Pos;
    public Transform Line9Pos;

    private bool[] linesExecuted = new bool[9];


    void Awake() {
      input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        input.Select();
        input.ActivateInputField();
    }

    IEnumerator SetupBattle()
    {
      GameObject playerGO = Instantiate(playerPrefab, playerPlatform);
      playerUnit = playerGO.GetComponent<Unit>();

      GameObject enemyGO = Instantiate(enemyPrefab, enemyPlatform);
      enemyUnit = enemyGO.GetComponent<Unit>();

      dialogueText.text = "An enemy approaches . . . ";

      playerHUD.SetHUD(playerUnit);
      enemyHUD.SetHUD(enemyUnit);

      yield return new WaitForSeconds(2f);

      state = BattleState.PLAYERTURN;
      PlayerTurn();
    }

    void PlayerTurn() {
      dialogueText.text = "Enter an input to attack . . .";
    }

    IEnumerator Attack(int playerAttack) {
      dialogueText.text = "The enemy is attacking!";
      yield return new WaitForSeconds(1f);

      bool playerIsDead = playerUnit.TakeDamage(enemyUnit.attack);
      playerHUD.SetHP(playerUnit.currentHP);

      yield return new WaitForSeconds(.5f);

      dialogueText.text = "You're attacking!";
      playerUnit.setAttack(playerAttack);

      yield return new WaitForSeconds(1f);

      bool enemyIsDead = enemyUnit.TakeDamage(playerUnit.attack);
      enemyHUD.SetHP(enemyUnit.currentHP);

      if(playerUnit.attack != 0) {
        dialogueText.text = "The attack is successful!";
      }
      else {
        dialogueText.text = "The attack was ineffective";
      }

      yield return new WaitForSeconds(2f);

      if(playerIsDead) {
        state = BattleState.LOST;
        StartCoroutine(EndBattle());
        yield break;
      }

      if(enemyIsDead) {
        state = BattleState.WON;
        StartCoroutine(EndBattle());
      }
      else {
        PlayerTurn();
      }

    }

    IEnumerator EndBattle() {
      if(state == BattleState.WON) {
        dialogueText.text = "You won the battle!";
        yield return new WaitForSeconds(1f);
        quitButton.transform.position = new Vector3(0, 0, 0);
      }
      else if(state == BattleState.LOST) {
        dialogueText.text = "You were defeated.";
        yield return new WaitForSeconds(1f);
        quitButton.transform.position = new Vector3(0, 0, 0);
      }
    }

    public void GetInput(string test) {
      input.Select();
      input.ActivateInputField();
      int userInput = Int32.Parse(test);
      int playerAttack = obtainAttack(userInput);
      StartCoroutine(Attack(playerAttack));
      input.text = "";
    }

    int obtainAttack(int x) {
      int attackCount = 0;
      if(!linesExecuted[0]) {
        Instantiate(whiteStar, Line1Pos.position, Line1Pos.rotation);
        attackCount++;
        linesExecuted[0] = true;
      }
      if(x > 3) {
        if(!linesExecuted[1]) {
          Instantiate(whiteStar, Line2Pos.position, Line2Pos.rotation);
          attackCount++;
          linesExecuted[1] = true;
        }
        if(x > 6) {
          if(!linesExecuted[2]) {
            Instantiate(whiteStar, Line3Pos.position, Line3Pos.rotation);
            attackCount++;
            linesExecuted[2] = true;
          }
          // return x + 1;
        }
        else if(x > 5) {
          if(!linesExecuted[3]) {
            Instantiate(whiteStar, Line4Pos.position, Line4Pos.rotation);
            attackCount++;
            linesExecuted[3] = true;
          }
          if(!linesExecuted[4]) {
            Instantiate(whiteStar, Line5Pos.position, Line5Pos.rotation);
            attackCount++;
            linesExecuted[4] = true;
          }
          if(!linesExecuted[5]) {
            Instantiate(whiteStar, Line6Pos.position, Line6Pos.rotation);
            attackCount++;
            linesExecuted[5] = true;
          }
          // return x + 2;
        }
        if(!linesExecuted[3]) {
          Instantiate(whiteStar, Line4Pos.position, Line4Pos.rotation);
          attackCount++;
          linesExecuted[3] = true;
        }
        if(!linesExecuted[4]) {
          Instantiate(whiteStar, Line5Pos.position, Line5Pos.rotation);
          attackCount++;
          linesExecuted[4] = true;
        }
        if(!linesExecuted[6]) {
          Instantiate(whiteStar, Line7Pos.position, Line7Pos.rotation);
          attackCount++;
          linesExecuted[6] = true;
        }
        if(!linesExecuted[7]) {
          Instantiate(whiteStar, Line8Pos.position, Line8Pos.rotation);
          attackCount++;
          linesExecuted[7] = true;
        }
        // return x + 3;
      }
      if(!linesExecuted[8]) {
        Instantiate(whiteStar, Line9Pos.position, Line9Pos.rotation);
        attackCount++;
        linesExecuted[8] = true;
      }
      return attackCount;
    }
}
