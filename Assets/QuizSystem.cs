using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem : MonoBehaviour
{
    private InputField input;
    public Text displayPanel;

    int inputCount = 0;
    static int numOfLines = 11;
    private int[] inputArray = new int[25];
    private bool[] linesExecuted = new bool[numOfLines];

    private bool newLine;
    string displayText = "";

    public GameObject white_dot;

    public Transform Line0;
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
      calculateLines(inputArray, inputCount);
      displayOutput(inputArray, inputCount);
      inputCount++;
    }

    void calculateLines(int[] inputArray, int inputCount) {
      int x = inputArray[inputCount];
      newLine = false;

      if(!linesExecuted[0]) {
        linesExecuted[0] = true;
        Instantiate(white_dot, Line0.position, Line0.rotation);
        newLine = true;
      }
      if(!linesExecuted[1]) {
        linesExecuted[1] = true;
        Instantiate(white_dot, Line0.position, Line0.rotation);
        newLine = true;
      }
      if(x > 3) {
        if(!linesExecuted[2]) {
          linesExecuted[2] = true;
          Instantiate(white_dot, Line1.position, Line1.rotation);
          newLine = true;
        }
        if(x > 6) {
          if(!linesExecuted[3]) {
          linesExecuted[3] = true;
          Instantiate(white_dot, Line2.position, Line2.rotation);
          newLine = true;
          }
          return;
          // return x + 1;
        }
        else if(x > 5) {
          if(!linesExecuted[4]) {
            linesExecuted[4] = true;
            Instantiate(white_dot, Line3.position, Line3.rotation);
            newLine = true;
          }
          if(!linesExecuted[5]) {
            linesExecuted[5] = true;
            Instantiate(white_dot, Line4.position, Line4.rotation);
            newLine = true;
          }
          if(!linesExecuted[6]) {
            linesExecuted[6] = true;
            Instantiate(white_dot, Line5.position, Line5.rotation);
            newLine = true;
          }
          return;
          // return x + 2;
        }
        if(!linesExecuted[4]) {
          linesExecuted[4] = true;
          Instantiate(white_dot, Line4.position, Line4.rotation);
          newLine = true;
        }
        if(!linesExecuted[5]) {
          linesExecuted[5] = true;
          Instantiate(white_dot, Line4.position, Line4.rotation);
          newLine = true;
        }
        if(!linesExecuted[7]) {
          linesExecuted[7] = true;
          Instantiate(white_dot, Line6.position, Line6.rotation);
          newLine = true;
        }
        if(!linesExecuted[8]) {
          linesExecuted[8] = true;
          Instantiate(white_dot, Line7.position, Line7.rotation);
          newLine = true;
        }
        return;
        // return x + 3;
      } // end if ( x > 3 )
      if(!linesExecuted[9]) {
        linesExecuted[9] = true;
        Instantiate(white_dot, Line8.position, Line8.rotation);
        newLine = true;
      }
    }

    void displayOutput(int[] inputArray, int inputCount) {
      // calculate number of correct lines
      int index = 0;
      int correctLines = 0;
      for(index = 0; index < 9; index++) {
        if(linesExecuted[index] == true)
          correctLines++;
      }

      if(correctLines == 9) {
        // tell the user they're correct
        displayText += "Good Job!\nYou executed all of the lines.";
      }
      else if(!newLine) {
        // tell user that they inputted too many test cases
        displayText += "You didn't execute any new lines.\nTry Again";
        newLine = false;
      }
      else {
        // tell user to try again
        displayText += "Try Again";
      }

      displayText += "\n\nPrevious Input:\n";
      
      index = 0;
      while(index <= inputCount) {
        displayText += "" + inputArray[index] + "  ";
        index++;
      }

      displayPanel.text = displayText;
      displayText = "";

      //reset linesExecuted array
      linesExecuted = Enumerable.Repeat((bool)false,10).ToArray();
    }
}
