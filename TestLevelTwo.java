import java.util.Scanner;

public class TestLevelTwo extends SuperGame{
    static final int perfectAttempts = 3;
    static final int linesOfCode = 8;
    static boolean gameOver = false;
    static boolean[] linesExecuted = new boolean[linesOfCode];
    static int score = 0;
    static int input = 0;
    static int attempts = 0;
    static int fails = 0;
    static boolean newLine = false;
    static int returnVal = 0;
    
    static String[] codeWithoutStars = new String[] {
            " x = x + 3 ",
            " if(x < 7 && x > -1 && ((x + 1) <= 4 || (x % 3) == 0)) {",
            "   return x;",
            " }",
            " else if(((x % 7) == 4) && (x < 6 )) {",
            "   return x;",
            " }",
	    " return x;"
    };

    static String methodHeader = "void int TestLevelTwo( int x ) {";

    public TestLevelTwo() {
        super(perfectAttempts, linesOfCode, gameOver,
                linesExecuted, score, input, attempts, fails, newLine, returnVal);
    }
    
    public static void main(String[] args) {
        SuperGame levelTwo = new TestLevelTwo();

        levelTwo.printStartingMessage();

        while (!levelTwo.getGameOver()) {
            levelTwo.printCode(codeWithoutStars, methodHeader);
            levelTwo.acquireInput();
						levelTwo.analyzeInput();
            levelTwo.updateScore();
            levelTwo.checkGameOver();
        }

        levelTwo.printCode(codeWithoutStars, methodHeader);
				levelTwo.checkPerfectAttempts();
				levelTwo.printEndingMessage();
    }

    public void acquireInput() {
        Scanner takesInput = new Scanner(System.in);
        input = takesInput.nextInt();

    }

    public void analyzeInput() {
      int x = input;

      x = x + 3;
      if(!linesExecuted[0] || !linesExecuted[1]) {
        newLine = true;
      }

      linesExecuted(0); // x = x + 3;
      linesExecuted(1); // if(x < 7 && x > -1 &&( (x + 1) <= 4 || (x % 3) == 0)) {
      if(x < 7 && x > -1 && ((x + 1) <= 4 || (x % 3) == 0)) {
        if(!linesExecuted[2]) {
          newLineExecuted();
	}

	linesExecuted(2);
	setReturnVal(x);
        return;
      }
      else if(((x % 7) == 4) && (x < 6)) {
        if(!linesExecuted[5]) {
          newLineExecuted();
        }

	linesExecuted(3);
	linesExecuted(4);
	linesExecuted(5);
	setReturnVal(x);
	return;
      }

      if(!linesExecuted[3] || !linesExecuted[4] || !linesExecuted[6]) {
        newLineExecuted();
      }

      linesExecuted(3);
      linesExecuted(4);
      linesExecuted(6);
      linesExecuted(7);
      setReturnVal(x);
    }
}
