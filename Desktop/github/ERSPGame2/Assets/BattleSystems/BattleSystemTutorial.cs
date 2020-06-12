using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum BattleState { START, PLAYERTURN, WON, LOST }
public class BattleSystemTutorial : MonoBehaviour
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

    // tutorial assets
    public Text tutorialDisplay;
    public GameObject tutorialPanel;
    public Image blackPanel;
    public Button tutorialContinue;

    public GameObject playerArrow;
    private GameObject arrow;

    public GameObject enemyArrow;
    private GameObject arrow2;

    public GameObject playerImage;
    private GameObject playerPic;

    public GameObject enemyImage;
    private GameObject enemyPic;

    private GameObject arrow3;
    private GameObject arrow4;
    public GameObject playerHUDArrow;
    public GameObject enemyHUDArrow;
    public GameObject playerHUDImage;
    public GameObject enemyHUDImage;
    private GameObject playerHUDPic;
    private GameObject enemyHUDPic;

    private GameObject arrow5;
    public GameObject codeArrow;

    private GameObject arrow6;
    public GameObject inputArrow;

    public GameObject canvas;
    // end tutorial assets

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private int playerAttack;

    public BattleState state;

    private InputField input;

    //sounds
    public GameObject megamanhead;
    public GameObject background;
    public AudioSource megamanblaster;
    public AudioSource megamansplash;
    public AudioSource victory;
    public AudioSource death;

    public Transform Line2Pos;
    public Transform Line3Pos;
    public Transform Line4Pos;
    public Transform Line5Pos;

    //animations
    public Transform firePoint;
    public GameObject bulletPrefab;

    private bool[] linesExecuted = new bool[5];

    private string[] TutorialText = {"Hello, Welcome to CodeBot! ",
                                     "This is your character . . .",
                                     ". . . and this is the enemy.",
                                     "You both have health and attack displayed here",
                                     "In order to attack the enemy, you must execute the lines over here",
                                     "Your attack value will be equal to the total amount of lines you execute each input",
                                     "Now, input the value '4' as the argument and press 'Enter'",
                                     "",
                                     "As you see, you dealt 2 damage because 2 new lines were executed",
                                     "As long as you deal damage each turn you won't take any damage",
                                     "Finish the tutorial and start your adventure! Good Luck!",
                                     ""};
    private int currTutText = 0;


    void Awake() {
      input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        showTutorial();
        StartCoroutine(SetupBattle());
        input.Select();
        input.ActivateInputField();
    }

    void showTutorial() {
      tutorialDisplay.text = TutorialText[currTutText];
    }

    public void nextTutText() {
      currTutText++;
      //Display next tutorial text
      tutorialDisplay.text = TutorialText[currTutText];

      if(currTutText == 1) {
        tutorialPanel.transform.position = new Vector3(-4, 0, 0);

        //Displays arrow image
        arrow = Instantiate(playerArrow);
        arrow.transform.SetParent(canvas.transform, false);

        // Displays player image
        playerPic = Instantiate(playerImage);
        playerPic.transform.SetParent(canvas.transform, false);
      }

      if(currTutText == 2) {
        tutorialPanel.transform.position = new Vector3(0, 0, 0);

        Destroy(arrow.gameObject);
        Destroy(playerPic.gameObject);

        //Creates arrow image
        arrow2 = Instantiate(enemyArrow);
        arrow2.transform.SetParent(canvas.transform, false);

        // Creates player image
        enemyPic = Instantiate(enemyImage);
        enemyPic.transform.SetParent(canvas.transform, false);
      }

      if(currTutText == 3) {
        Destroy(arrow2.gameObject);
        Destroy(enemyPic.gameObject);

        tutorialPanel.transform.position = new Vector3(4, -1, 0);

        //Creates playerHUDarrow image
        arrow3 = Instantiate(playerHUDArrow);
        arrow3.transform.SetParent(canvas.transform, false);

        // Creates enemyHUDarrow image
        arrow4 = Instantiate(enemyHUDArrow);
        arrow4.transform.SetParent(canvas.transform, false);

        //Creates arrow image
        playerHUDPic = Instantiate(playerHUDImage);
        playerHUDPic.transform.SetParent(canvas.transform, false);

        // Creates player image
        enemyHUDPic = Instantiate(enemyHUDImage);
        enemyHUDPic.transform.SetParent(canvas.transform, false);
      }

      if(currTutText == 4) {
        Destroy(arrow3.gameObject);
        Destroy(playerHUDPic.gameObject);
        Destroy(arrow4.gameObject);
        Destroy(enemyHUDPic.gameObject);

        tutorialPanel.transform.position = new Vector3(-4, -3, 0);

        //Creates arrow image
        arrow5 = Instantiate(codeArrow);
        arrow5.transform.SetParent(canvas.transform, false);
      }

      if(currTutText == 5) {
        Destroy(arrow5.gameObject);
      }

      if(currTutText == 6) {
        tutorialPanel.transform.position = new Vector3(0, 0, 0);

        //Creates arrow image
        arrow6 = Instantiate(inputArrow);
        arrow6.transform.SetParent(canvas.transform, false);
      }

      if(currTutText == 7) {
        blackPanel.enabled = false;
        Destroy(arrow6);
        tutorialPanel.SetActive(false);
        tutorialContinue.transform.position = new Vector3(20, 0, 0);
      }

      if(currTutText == 8) {
        blackPanel.enabled = true;
        tutorialPanel.SetActive(true);
        tutorialContinue.transform.position = new Vector3(0, -3, 0);
      }

      if(currTutText == 9) {
        blackPanel.enabled = true;
        tutorialPanel.SetActive(true);
        tutorialContinue.transform.position = new Vector3(0, -3, 0);
      }

      if(currTutText == 10) {
        tutorialPanel.SetActive(true);
        tutorialContinue.transform.position = new Vector3(0, -3, 0);
      }

      if(currTutText == 11) {
        blackPanel.enabled = false;
        tutorialPanel.SetActive(false);
        tutorialContinue.transform.position = new Vector3(0, 100, 0);
      }
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
      dialogueText.text = "Waiting to attack . . . ";
    }

    IEnumerator Attack() {
      bool playerIsDead = false;
      dialogueText.text = "You're attacking!";
      playerUnit.setAttack(playerAttack);

      yield return new WaitForSeconds(1f);

      bool enemyIsDead = enemyUnit.TakeDamage(playerUnit.attack);
      enemyHUD.SetHP(enemyUnit.currentHP);

      if(playerUnit.attack != 0) {
        dialogueText.text = "You dealt " + playerAttack + " damage!";
        for(int i = 0; i < playerAttack; i++){
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            megamansplash.Play();
            yield return new WaitForSeconds(.5f);
        }
      }
      else {
        dialogueText.text = "The attack was ineffective";
      }
      yield return new WaitForSeconds(1.5f);

      if(playerUnit.attack == 0) {
        dialogueText.text = "The enemy is attacking!";
        playerUnit.TakeDamage(enemyUnit.attack);
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(.5f);
      }

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
        victory.Play();
      }
      else if(state == BattleState.LOST) {
        dialogueText.text = "You were defeated.";
        death.Play();
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


      if(!linesExecuted[1]) {
        Instantiate(megamanhead, Line2Pos.position, Line2Pos.rotation);
        megamanblaster.Play();
        attackCount++;
        playerHUD.SetAttack(attackCount);
        yield return new WaitForSeconds(.5f);
        linesExecuted[1] = true;
      }

      if(x > 3) {
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
        nextTutText();
        playerHUD.SetAttack(0);

        yield break;
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

      playerAttack = attackCount;
      StartCoroutine(Attack());
      yield return new WaitForSeconds(4f);
      playerHUD.SetAttack(0);
    }
}
