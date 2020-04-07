using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;

public class QuizSystem4 : MonoBehaviour
{
    private InputField input;
    public UnityEngine.UI.Text displayPanel;
    public UnityEngine.UI.Text flag1Text;
    public UnityEngine.UI.Text flag2Text;

    int inputCount = 0;
    static int numOfLines = 10;
    private int[] inputArray = new int[25];
    private bool[] linesExecuted = new bool[numOfLines];

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

    bool flag1 = false;
    bool flag2 = false;

    void calculateLines() {
      int x = inputArray[inputCount];

      if(!linesExecuted[0]) {
        linesExecuted[0] = true;
        Instantiate(white_dot, Line0.position, Line0.rotation);
      }
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

      double count = 1.5;
      for(int i = 0; i < x; i++) {
        count = count * 2;
      }

      if(flag1 && (count % 5 == 2)) {
        flag2 = true;
        flag2Text.text = "// TRUE";
        if(!linesExecuted[5]) {
          linesExecuted[5] = true;
          Instantiate(white_dot, Line5.position, Line5.rotation);
        }
      }
      Debug.Log("count = " + count);

      if(!linesExecuted[6]) {
        linesExecuted[6] = true;
        Instantiate(white_dot, Line6.position, Line6.rotation);
      }

      Debug.Log("flag1?");
      if(count == 6) {
        flag1 = true;
        Debug.Log("flag1 is true");
        flag1Text.text = "// TRUE";
      }

      if(!linesExecuted[7]) {
        linesExecuted[7] = true;
        Instantiate(white_dot, Line7.position, Line7.rotation);
      }

      Debug.Log("flag2?");
      if(flag2) {
        Debug.Log("flag2 is true => line8");
        if(!linesExecuted[8]) {
          linesExecuted[8] = true;
          Instantiate(white_dot, Line8.position, Line8.rotation);
        }
        Debug.Log("return1");
        return;
        // return x
      }

      Debug.Log("line9");
      if(!linesExecuted[9]) {
        linesExecuted[9] = true;
        Instantiate(white_dot, Line9.position, Line9.rotation);
      }
      Debug.Log("return2");
      return;
      // return 0
    }

    void displayOutput() {
      Debug.Log("displayOutput");
      // calculate number of correct lines
      int index = 0;
      int correctLines = 0;
     
      for(; index < numOfLines; index++) {
        if(linesExecuted[index])
          correctLines++;
      }

      Debug.Log("correctLines = " + correctLines);
      if(correctLines == numOfLines) {
        // tell the user they're correct
        Debug.Log("Correct!!!");
        displayText += "Good Job!\nYou've finished the program!";
      }
      else {
        // tell user to try again
        Debug.Log("Try Again");
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
    }
}
