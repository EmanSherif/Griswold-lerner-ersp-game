using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem3 : MonoBehaviour
{
    public Button continueButton;
    private InputField input;
    public UnityEngine.UI.Text displayPanel;
    public UnityEngine.UI.Text flag;

    int inputCount = 0;
    static int numOfLines = 13;
    private int[] inputArray = new int[25];
    private bool[] linesExecuted = new bool[numOfLines];
    bool check = false;

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
    public Transform Line12;


    void Awake() {
      input = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("Start");
      input.Select();
      input.ActivateInputField();
      Debug.Log("input");
    }

    public void GetInput(string inputStr) {
      Debug.Log("GetInput");
      input.Select();
      input.ActivateInputField();
      inputArray[inputCount] = Int32.Parse(inputStr);
      calculateLines();
      displayOutput();
      inputCount++;
    }

    void calculateLines() {
      int x = inputArray[inputCount];
 
      if(!linesExecuted[0]) {
        linesExecuted[0] = true;
        Instantiate(white_dot, Line0.position, Line0.rotation);
      }
      if(x % 2 == 0) {
        if(!linesExecuted[1]) {
          linesExecuted[1] = true;
          Instantiate(white_dot, Line1.position, Line1.rotation);
        }
        if(!linesExecuted[2]) {
          linesExecuted[2] = true;
          Instantiate(white_dot, Line2.position, Line2.rotation);
        }
        if(!linesExecuted[3]) {
          linesExecuted[3] = true;
          Instantiate(white_dot, Line3.position, Line3.rotation);
        }
        if(!linesExecuted[4]) {
          linesExecuted[4] = true;
          Instantiate(white_dot, Line4.position, Line4.rotation);
        }
        if(!linesExecuted[5]) {
          linesExecuted[5] = true;
          Instantiate(white_dot, Line5.position, Line5.rotation);
        }

        for(int i = 0; i < 3; i++) {
          x = x * 2;
        }

        x = x + 16;

        if(x == 0) {
          check = true;
          flag.text = "//TRUE";
          if(!linesExecuted[6]) {
            linesExecuted[6] = true;
            Instantiate(white_dot, Line6.position, Line6.rotation);
          }
        }
        if(!linesExecuted[7]) {
          linesExecuted[7] = true;
          Instantiate(white_dot, Line7.position, Line7.rotation);
        }
        if(!linesExecuted[8]) {
          linesExecuted[8] = true;
          Instantiate(white_dot, Line8.position, Line8.rotation);
        }
      }

      if(check) {
        if(!linesExecuted[9]) {
          linesExecuted[9] = true;
          Instantiate(white_dot, Line9.position, Line9.rotation);
        }
          
        if((x % 2) != 0) {
          if(!linesExecuted[10]) {
            linesExecuted[10] = true;
            Instantiate(white_dot, Line10.position, Line10.rotation);
          }
          return;
          // return x * 5
        }
      }
      if(!linesExecuted[11]) {
          linesExecuted[11] = true;
          Instantiate(white_dot, Line11.position, Line11.rotation);
      }
      if(!linesExecuted[12]) {
          linesExecuted[12] = true;
          Instantiate(white_dot, Line12.position, Line12.rotation);
      }
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
      if(correctLines == numOfLines){
        continueButton.transform.position = new Vector3(6, -4, 1);
      } 
    }
}
