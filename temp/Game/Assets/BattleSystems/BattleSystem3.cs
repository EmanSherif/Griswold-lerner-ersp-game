using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState3 { START, PLAYERTURN, WON, LOST }

public class BattleSystem3 : MonoBehaviour
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
    public Text flag;

    public Color green;
    public Color red;

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
    public Transform Line10Pos;
    public Transform Line11Pos;
    public Transform Line12Pos;
    public Transform Line13Pos;
    public Transform Line14Pos;

    private bool[] linesExecuted = new bool[14];


    void Awake()
    {
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

        playerUnit.setNewMaxHP(15);

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        Instantiate(megamanhead, Line1Pos.position, Line1Pos.rotation);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Enter an input to attack . . .";
    }

    IEnumerator Attack()
    {
      bool playerIsDead = false;
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

      if(playerUnit.attack == 0) {
        dialogueText.text = "The enemy is attacking!";
        yield return new WaitForSeconds(1f);

        playerUnit.TakeDamage(enemyUnit.attack);
        playerIsDead = Unit.playerTakeDamage(enemyUnit.attack);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(.5f);
      }

      if (playerIsDead)
      {
          state = BattleState.LOST;
          StartCoroutine(EndBattle());
          yield break;
      }

      if (enemyIsDead)
      {
          state = BattleState.WON;
          StartCoroutine(EndBattle());
      }
      else
      {
          PlayerTurn();
      }

    }

    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }

        yield return new WaitForSeconds(1f);
        quitButton.transform.position = new Vector3(0, -1, 0);
        continueButton.transform.position = new Vector3(0, 1, 0);
    }

    public void GetInput(string test)
    {
        input.Select();
        input.ActivateInputField();
        int userInput = Int32.Parse(test);
        StartCoroutine(obtainAttack(userInput));
        input.text = "";
    }

    bool check = false;

    IEnumerator obtainAttack(int x)
    {
        int attackCount = 0;
        playerHUD.SetAttack(attackCount);
        yield return new WaitForSeconds(.5f);

        if (!linesExecuted[1])
        {
            Instantiate(megamanhead, Line2Pos.position, Line2Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[1] = true;
        }

        if (!linesExecuted[2])
        {
            Instantiate(megamanhead, Line3Pos.position, Line3Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[2] = true;
        }

        if (x % 2 == 0)
        {

            for (int i = 0; i < 3; i++)
            {
                x = x * 2;
            }

            if (!linesExecuted[3])
            {
                Instantiate(megamanhead, Line4Pos.position, Line4Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[3] = true;
            }

            if (!linesExecuted[4])
            {
                Instantiate(megamanhead, Line5Pos.position, Line5Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[4] = true;
            }

            x = x + 16;

            if (!linesExecuted[5])
            {
                Instantiate(megamanhead, Line6Pos.position, Line6Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[5] = true;
            }

            if (!linesExecuted[6])
            {
                Instantiate(megamanhead, Line7Pos.position, Line7Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[6] = true;
            }

            if (!linesExecuted[7])
            {
                Instantiate(megamanhead, Line8Pos.position, Line8Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[7] = true;
            }

            if ( x == 0 ) {
               check = true;
                flag.text = "// TRUE";
                flag.color = green;
            }

            //return x;

            if (!linesExecuted[8])
            {
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
            yield break;
            //return w/o flag true
        }

        if (!linesExecuted[9])
        {
            Instantiate(megamanhead, Line10Pos.position, Line10Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[9] = true;
        }

        if ( check == true )
        {
            if (!linesExecuted[10])
            {
                Instantiate(megamanhead, Line11Pos.position, Line11Pos.rotation);
                megamanblaster.Play();
                attackCount++;
                playerHUD.SetAttack(attackCount);
                yield return new WaitForSeconds(.5f);
                linesExecuted[10] = true;
            }

            if ( (x % 2) != 0 ) {

              if (!linesExecuted[11])
              {
                  Instantiate(megamanhead, Line12Pos.position, Line12Pos.rotation);
                  megamanblaster.Play();
                  attackCount++;
                  playerHUD.SetAttack(attackCount);
                  yield return new WaitForSeconds(.5f);
                  linesExecuted[11] = true;
              }

              playerAttack = attackCount;
              StartCoroutine(Attack());
              yield return new WaitForSeconds(4f);
              playerHUD.SetAttack(0);
              yield break;
              //return x;
            }
        }
        if (!linesExecuted[12])
        {
            Instantiate(megamanhead, Line13Pos.position, Line13Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[12] = true;
        }

        if (!linesExecuted[13])
        {
            Instantiate(megamanhead, Line14Pos.position, Line14Pos.rotation);
            megamanblaster.Play();
            attackCount++;
            playerHUD.SetAttack(attackCount);
            yield return new WaitForSeconds(.5f);
            linesExecuted[13] = true;
        }

        playerAttack = attackCount;
        StartCoroutine(Attack());
        yield return new WaitForSeconds(4f);
        playerHUD.SetAttack(0);
        yield break;
        }
      }
