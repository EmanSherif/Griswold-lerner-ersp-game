import java.util.*;

public class TestLevelOne extends SuperGame{
  private static final int perfectAttempts = 4;
  private static final int linesOfCode = 10;
  static boolean gameOver = false;
  static boolean[] linesExecuted = new boolean[linesOfCode];
  static int score = 0;
  static int input = 0;
  static int attempts = 0;
  static int fails = 0;
  static boolean newLine = false;
  static int returnVal = 0;

  private static final String[] codeWithoutStars = new String[] { 
									"  if(x > 3) {",
	  							"    if(x > 6) {",
								  "      return x + 1;",
								  "    }",
								  "    else if(x > 5) {",
								  "      return x + 2;",
								  "    }",
								  "    return x + 3;",
								  "  }",
								  "  return x;"};

	static String methodHeader = "int levelOne( int x ) {";
  
	public TestLevelOne() {
		super(perfectAttempts, linesOfCode, gameOver, linesExecuted, score, input,
						attempts, fails, newLine, returnVal);
	}

	public static void main(String[] args) {
		SuperGame levelOne = new TestLevelOne();

		levelOne.printStartingMessage();

    while(!levelOne.getGameOver()) {
      levelOne.printCode(codeWithoutStars, methodHeader);
      levelOne.acquireInput();
			levelOne.analyzeInput();
      levelOne.updateScore();
      levelOne.checkGameOver();
    }

		levelOne.printCode(codeWithoutStars, methodHeader);
		levelOne.checkPerfectAttempts();
		levelOne.printEndingMessage();
  }

	public void acquireInput() {
    Scanner takesInput = new Scanner(System.in);
    input = takesInput.nextInt();
	}
  
	public void analyzeInput() {

    if(!linesExecuted[0]) {
      newLineExecuted();
    }

    linesExecuted(0); // if(x > 3) {
    if(input > 3) {
      if(!linesExecuted[1]) {
        newLineExecuted();
      }

      linesExecuted(1); // if(x > 6) {
      if(input > 6) {
        if(!linesExecuted[2]) {
          newLineExecuted();
        }
        
        linesExecuted(2); // return x + 1;
        setReturnVal(input + 1);
        return;
      }

      if(!linesExecuted[3] || !linesExecuted[4]) {
        newLineExecuted();
      }

      linesExecuted(3);
      linesExecuted(4);
      
      if(input > 5) {
        if(!linesExecuted[5]) {
          newLineExecuted();
        }

        linesExecuted(5);
        setReturnVal(input + 2);
        return;
      }

      if(!linesExecuted[6] || !linesExecuted[7]) {
        newLineExecuted();
      }

      linesExecuted(6);
      linesExecuted(7);
      setReturnVal(input + 3);
      return;
    }

    if(!linesExecuted[8] || !linesExecuted[9]) {
      newLineExecuted();
    }

    linesExecuted(8);
    linesExecuted(9);
    setReturnVal(input);
    return;
  }
}
