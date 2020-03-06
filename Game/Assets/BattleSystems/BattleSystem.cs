using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public Button quitButton;
    public Button continueButton;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerPlatform;
    public Transform enemyPlatform;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private int playerAttack;

    public BattleState state;

    private InputField input;

    //sounds
    public GameObject megamanhead;
    public GameObject background;
    public AudioSource megamanblaster;

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

    IEnumerator Attack() {
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
        dialogueText.text = "You dealt " + playerAttack + " damage!";
      }
      else {
        dialogueText.text = "The attack was ineffective";
      }

      yield return new WaitForSeconds(1.5f);

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
      }
      else if(state == BattleState.LOST) {
        dialogueText.text = "You were defeated.";
      }

      yield return new WaitForSeconds(1f);
      quitButton.transform.position = new Vector3(0, -1, 0);
      continueButton.transform.position = new Vector3(0, 1, 0);
    }

    public void GetInput(string test) {
      input.Select();
      input.ActivateInputField();
      int userInput = Int32.Parse(test);
      StartCoroutine(obtainAttack(userInput));
      input.text = "";
    }

    IEnumerator obtainAttack(int x) {
      int attackCount = 0;
      playerHUD.SetAttack(attackCount);
      yield return new WaitForSeconds(.5f);
      if(!linesExecuted[0]) {
        Instantiate(megamanhead, Line1Pos.position, Line1Pos.rotation);
        megamanblaster.Play();
        attackCount++;
        playerHUD.SetAttack(attackCount);
        yield return new WaitForSeconds(.5f);
        linesExecuted[0] = true;
      }
      if(x > 3) {
        if(!linesExecuted[1]) {
          Instantiate(megamanhead, Line2Pos.position, Line2Pos.rotation);
          megamanblaster.Play();
          attackCount++;
          playerHUD.SetAttack(attackCount);
          yield return new WaitForSeconds(.5f);
          linesExecuted[1] = true;
        }
        if(x > 6) {
          if(!linesExecuted[2]) {
            Instantiate(megamanhead, Line3Pos.position, Line3Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[2] = true;
          }
          playerAttack = attackCount;
          StartCoroutine(Attack());
          yield return new WaitForSeconds(4f);
          playerHUD.SetAttack(0);
          yield break;
          // return x + 1;
        }
        else if(x > 5) {
          if(!linesExecuted[3]) {
            Instantiate(megamanhead, Line4Pos.position, Line4Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[3] = true;
          }

          if(!linesExecuted[4]) {
            Instantiate(megamanhead, Line5Pos.position, Line5Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[4] = true;
          }

          if(!linesExecuted[5]) {
            Instantiate(megamanhead, Line6Pos.position, Line6Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[5] = true;
          }

          playerAttack = attackCount;
          StartCoroutine(Attack());
          yield return new WaitForSeconds(4f);
          playerHUD.SetAttack(0);
          yield break;
          // return x + 2;
        }
        if(!linesExecuted[3]) {
          Instantiate(megamanhead, Line4Pos.position, Line4Pos.rotation);
          megamanblaster.Play();
          attackCount++;
          playerHUD.SetAttack(attackCount);
          yield return new WaitForSeconds(.5f);
          linesExecuted[3] = true;
        }
        if(!linesExecuted[4]) {
          Instantiate(megamanhead, Line5Pos.position, Line5Pos.rotation);
          megamanblaster.Play();
          attackCount++;
          playerHUD.SetAttack(attackCount);
          yield return new WaitForSeconds(.5f);
          linesExecuted[4] = true;
        }
        if(!linesExecuted[6]) {
          Instantiate(megamanhead, Line7Pos.position, Line7Pos.rotation);
          megamanblaster.Play();
          attackCount++;
          playerHUD.SetAttack(attackCount);
          yield return new WaitForSeconds(.5f);
          linesExecuted[6] = true;
        }
        if(!linesExecuted[7]) {
          Instantiate(megamanhead, Line8Pos.position, Line8Pos.rotation);
          megamanblaster.Play();
          attackCount++;
          playerHUD.SetAttack(attackCount);
          yield return new WaitForSeconds(.5f);
          linesExecuted[7] = true;
        }
        playerAttack = attackCount;
        StartCoroutine(Attack());
        yield return new WaitForSeconds(4f);
        playerHUD.SetAttack(0);
        yield break;
        // return x + 3;
      }
      if(!linesExecuted[8]) {
        Instantiate(megamanhead, Line9Pos.position, Line9Pos.rotation);
        megamanblaster.Play();
        attackCount++;
        playerHUD.SetAttack(attackCount);
        yield return new WaitForSeconds(.5f);
        linesExecuted[8] = true;
      }

      playerAttack = attackCount;
      StartCoroutine(Attack());
      yield return new WaitForSeconds(4f);
      playerHUD.SetAttack(0);
    }
}
