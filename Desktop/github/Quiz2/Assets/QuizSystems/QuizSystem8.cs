using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem8 : MonoBehaviour
{

    private InputField input;
    public UnityEngine.UI.Text displayPanel;

    int inputCount = 0;
    static int numOfLines = 13;
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
    public Transform Line12;
    public Transform Line13;



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
      int [] arr = new int[x];
      int sum = 0;
      if(!linesExecuted[0]) { //int sum = 0;
        linesExecuted[0] = true;
        Instantiate(white_dot, Line1.position, Line1.rotation);
      }
      if(!linesExecuted[1]) { // int [] arr= new int[x];
          linesExecuted[1] = true;
          Instantiate(white_dot, Line2.position, Line2.rotation);
      }
      if ( x > 0) {
        if(!linesExecuted[2]) { //outer for
            linesExecuted[2] = true;
            Instantiate(white_dot, Line3.position, Line3.rotation);
        }
        if ( x > 1) {
            if(!linesExecuted[3]) { // inner for
                linesExecuted[3] = true;
                Instantiate(white_dot, Line4.position, Line4.rotation);
            }
            if(!linesExecuted[4]) { // sum = sum + (i*j);
                linesExecuted[4] = true;
                Instantiate(white_dot, Line5.position, Line5.rotation);
            }
        }
        if(!linesExecuted[5]) { //inner loop end }
          linesExecuted[5] = true;
          Instantiate(white_dot, Line6.position, Line6.rotation);
        }
        if(!linesExecuted[6]) { // arr[i] = sum;
            linesExecuted[6] = true;
            Instantiate(white_dot, Line7.position, Line7.rotation);
        }
        if(!linesExecuted[7]) { //sum = 0;
            linesExecuted[7] = true;
            Instantiate(white_dot, Line8.position, Line8.rotation);
        }

      }
      if(!linesExecuted[8]) { // end } outer loop
       linesExecuted[8] = true;
       Instantiate(white_dot, Line9.position, Line9.rotation);
      }
      for(int i =0; i < x; i++) {
          for(int j =0; j < x/2; j++) {
              sum = sum + (i*j);
          }
          arr[i] = sum;
          sum = 0;
      }
      if( x > 2){
        if(!linesExecuted[9]) { //if(arr[2] == 2)
            linesExecuted[9] = true;
            Instantiate(white_dot, Line10.position, Line10.rotation);
        }
        if(arr[2] == 2){
            if(!linesExecuted[10]) { //return x;
                linesExecuted[10] = true;
                Instantiate(white_dot, Line11.position, Line11.rotation);
            }
            return;
        }
      }
      if(!linesExecuted[11]) { //end }
        linesExecuted[11] = true;
        Instantiate(white_dot, Line12.position, Line12.rotation);
      }
      if(!linesExecuted[12]) { //return x + 1;
        linesExecuted[12] = true;
        Instantiate(white_dot, Line13.position, Line13.rotation);
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

    }
}
