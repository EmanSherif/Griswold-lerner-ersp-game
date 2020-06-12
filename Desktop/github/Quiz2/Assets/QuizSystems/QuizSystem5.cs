using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem5 : MonoBehaviour
{
    public Button continueButton;
    private InputField input;
    public UnityEngine.UI.Text displayPanel;

    int inputCount = 0;
    static int numOfLines = 8;
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
      x = x + 3;
      if(!linesExecuted[0]) { //x = x + 3;
        linesExecuted[0] = true;
        Instantiate(white_dot, Line1.position, Line1.rotation);
      }
      if(!linesExecuted[1]) { //if(x % 7 ==6)
          linesExecuted[1] = true;
          Instantiate(white_dot, Line2.position, Line2.rotation);
      }

     if(x % 7 == 6) { //return x;
        if(!linesExecuted[2]) {
        linesExecuted[2] = true;
        Instantiate(white_dot, Line3.position, Line3.rotation);
        return;
      }
     }
      if(!linesExecuted[3]) { // end }
        linesExecuted[3] = true;
        Instantiate(white_dot, Line4.position, Line4.rotation);
      }
        if(!linesExecuted[4]) { //if(x == 5)
          linesExecuted[4] = true;
          Instantiate(white_dot, Line5.position, Line5.rotation);
        }
        if(x == 2) { //return x +1;
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
        if(!linesExecuted[7]) { //return x + 2;
          linesExecuted[7] = true;
          Instantiate(white_dot, Line8.position, Line8.rotation);
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
