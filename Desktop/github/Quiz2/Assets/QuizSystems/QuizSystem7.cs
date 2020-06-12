using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem7 : MonoBehaviour
{
    public Button continueButton;
    private InputField input;
    public UnityEngine.UI.Text displayPanel;

    int inputCount = 0;
    static int numOfLines = 11;
    private int[] inputArray = new int[25];
    private bool[] linesExecuted = new bool[numOfLines];

    string displayText = "";

    public GameObject white_dot;

    public Transform Line1;
    public Transform Line2;
    public Transform Line3;
    public Transform Line4;
    public Transform Line5;
    public Transform Line6;
    public Transform Line7;
    public Transform Line8;
    public Transform Line9;
    public Transform Line10;
    public Transform Line11;



    void Awake() {
      input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
      input.Select();
      input.ActivateInputField();
    }

    public void GetInput(string inputStr) {
      input.Select();
      input.ActivateInputField();
      inputArray[inputCount] = Int32.Parse(inputStr);
      calculateLines();
      displayOutput();
      inputCount++;
    }

    void calculateLines() {
      int x = inputArray[inputCount];
      int sum = 0;
      if(!linesExecuted[0]) { //int sum = 0;
        linesExecuted[0] = true;
        Instantiate(white_dot, Line1.position, Line1.rotation);
      }
     if( x > 0) {
      if(!linesExecuted[1]) { // for (int i =0; i < x; i++) {}
          linesExecuted[1] = true;
          Instantiate(white_dot, Line2.position, Line2.rotation);
      }
      if(!linesExecuted[2]) { // sum = sum + i
        linesExecuted[2] = true;
        Instantiate(white_dot, Line3.position, Line3.rotation);
      }
     }
     if(!linesExecuted[3]) { // end }
        linesExecuted[3] = true;
        Instantiate(white_dot, Line4.position, Line4.rotation);
      }
      for(int i =0; i < x; i++) {
          sum = sum + i;
      }
      if(!linesExecuted[4]) { // if statement
        linesExecuted[4] = true;
        Instantiate(white_dot, Line5.position, Line5.rotation);
      }
      if((sum % 3 == 1) && x > 10) { //return x;;
        if(!linesExecuted[5]) {
          linesExecuted[5] = true;
          Instantiate(white_dot, Line6.position, Line6.rotation);
        }
          return;
      }
      if(!linesExecuted[6]) { //end }
        linesExecuted[6] = true;
        Instantiate(white_dot, Line7.position, Line7.rotation);
      }
      if(!linesExecuted[7]) { //if ( sum == 10)
        linesExecuted[7] = true;
        Instantiate(white_dot, Line8.position, Line8.rotation);
      }
      if(sum == 10) { //return x + 1;
        if(!linesExecuted[8]) {
          linesExecuted[8] = true;
          Instantiate(white_dot, Line9.position, Line9.rotation);
        }
          return;
      }
      if(!linesExecuted[9]) { //end }
        linesExecuted[9] = true;
        Instantiate(white_dot, Line10.position, Line10.rotation);
      }
      if(!linesExecuted[10]) { //end }
        linesExecuted[10] = true;
        Instantiate(white_dot, Line11.position, Line11.rotation);
      }
      return;


    }

    void displayOutput() {
      // calculate number of correct lines
      int index = 0;
      int correctLines = 0;

      for(; index < numOfLines; index++) {
        if(linesExecuted[index])
          correctLines++;
      }

      if(correctLines == numOfLines) {
        // tell the user they're correct
        displayText += "Good Job!\nYou executed all of the lines.";
       }
      else {
        // tell user to try again
        displayText += "Input another value";
      }

      displayText += "\n\nPrevious Input:\n";

      index = 0;
      while(index <= inputCount) {
        displayText += "" + inputArray[index] + "  ";
        index++;
      }

      displayPanel.text = displayText;
      displayText = "";
      if(correctLines == numOfLines){
        continueButton.transform.position = new Vector3(6, -4, 1);
      }
    }
}
