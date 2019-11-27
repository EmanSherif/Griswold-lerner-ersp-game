import java.util.*;

public class TestLevelOne {
  private static final int perfectAttempts = 4;
  private static final int linesOfCode = 10;
  private static final String perfectMsg = "Congratulations! You solved the " +
    "level with the least amount of attempts!";

  private static final String gameDes = "\n\nThe objective of the game is to execute\n" +
    "each line of code that you see at least once. For each attempt you will get\n" +
    "one point if you execute a new line of code and if not then you will get one\n" +
    "point deducted. Try to execute the code with the least amount of tries to\n" +
    "maximize your score! Input parameters in the terminal separated by a space.\n" +
    "Good Luck!";

  private static final String[] codeWithoutStars = new String[] { "  if(x > 3) {",
	  							  "    if(x > 6) {",
								  "      return x + 1;",
								  "    }",
								  "    else if(x > 5) {",
								  "      return x + 2;",
								  "    }",
								  "    return x + 3;",
								  "  }",
								  "  return x;"};

  private static final String[] codeWithStars = new String[] {  "* if(x > 3) {",
                                                                "*   if(x > 6) {",
                                                                "*     return x + 1;",
                                                                "*   }",
                                                                "*   else if(x > 5) {",
                                                                "*     return x + 2;",
                                                                "*   }",
                                                                "*   return x + 3;",
                                                                "* }",
                                                                "* return x;"};


  static boolean gameOver = false;
  static boolean[] linesExecuted = new boolean[linesOfCode];
  static int score = 0;
  static int input = 0;
  static int attempts = 0;
  static int fails = 0;
  static boolean newLine = false;
  static int returnVal = 0;

  public static void main(String[] args) {
    System.out.println(gameDes + "\n\n"); // prints out game description
    while(!gameOver) {
      printCode();
      analyzeInput();
      updateScore();
      checkGameOver();
    }

    // checks if the user won with least amount of tests possible
    if(attempts == perfectAttempts) {
      System.out.println(perfectMsg);
    }
  }

  static void updateScore() {
    if(!newLine) {
      fails++; // increases total attempts to penalize the player
      System.out.println("\nOops! That one didn't execute a new line");
    }
    else {
      System.out.println("\nGood one! You executed a new line!");
    }

    System.out.println("Returned Value: " + returnVal + "\n");
    // reset newLine
    newLine = false;
    attempts++;
  }

  static void checkGameOver() {
    for(int i = 0; i < linesExecuted.length; i++) {
      if(!linesExecuted[i]) {
        return; // if one line hasn't been executed, game is NOT over
      }
    }

    gameOver = true;
    return;
  }

  static void analyzeInput() {
    Scanner takesInput = new Scanner(System.in);
    input = takesInput.nextInt();

    if(input <= 3) {
      // checks if a new line was executed
      if(!linesExecuted[0] || !linesExecuted[9]) {
        newLine = true;
      }

      linesExecuted[0] = true; // if(x > 3) {
      linesExecuted[8] = true; // }
      linesExecuted[9] = true; // return x;
      returnVal = input;
      return;
    }

    if(input == 4 || input == 5) {
      // checks if a new line was executed
      if(!linesExecuted[0] || !linesExecuted[1] || !linesExecuted[3] ||
         !linesExecuted[4] || !linesExecuted[6] || !linesExecuted[7]) {
        newLine = true;
      }

      linesExecuted[0] = true; // if(x > 3) {
      linesExecuted[1] = true; // if(x > 6) {
      linesExecuted[3] = true; // }
      linesExecuted[4] = true; // else if(x > 5) {
      linesExecuted[6] = true; // }
      linesExecuted[7] = true; // return x + 3;
      returnVal = input + 3;
      return;
    }

    if(input == 6) {
      // checks if a new line was executed
      if(!linesExecuted[0] || !linesExecuted[1] || !linesExecuted[3] ||
         !linesExecuted[4] || !linesExecuted[5]) {
        newLine = true;
      }

      linesExecuted[0] = true; // if(x > 3) {
      linesExecuted[1] = true; // if(x > 6) {
      linesExecuted[3] = true; // }
      linesExecuted[4] = true; // else if(x > 5) {
      linesExecuted[5] = true; // return x + 2;
      returnVal = input + 2;
      return;
    }

    if(input >= 7) {
      // checks if a new line was executed
      if(!linesExecuted[0] || !linesExecuted[1] || !linesExecuted[2]) {
        newLine = true;
      }

      linesExecuted[0] = true; // if(x > 3) {
      linesExecuted[1] = true; // if(x > 6) {
      linesExecuted[2] = true; // return x + 1;
      returnVal = input + 1;
      return;
    }
  }

  static void printCode() {
    // function name print
    System.out.println("int levelOne(int x) {");

    for(int i = 0; i < linesOfCode; i++) {
      if (linesExecuted[i]) {
        System.out.println(codeWithStars[i]);
      }
      else {
	System.out.println(codeWithoutStars[i]);
      }
    }

    System.out.println("}\n"); // prints end curly bracket
  }
}
