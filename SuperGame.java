public abstract class SuperGame {
     /**
     * Different colored text
     */
    public static final String ANSI_RESET = "\u001B[0m";
    private static final String ANSI_BLACK = "\u001B[30m";
    private static final String ANSI_RED = "\u001B[31m";
    public static final String ANSI_GREEN = "\u001B[32m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    private static final String ANSI_BLUE = "\u001B[34m";
    private static final String ANSI_PURPLE = "\u001B[35m";
    private static final String ANSI_CYAN = "\u001B[36m";
    private static final String ANSI_WHITE = "\u001B[37m";

    /**
     * Different colored backgrounds
     */
    private static final String ANSI_BLACK_BACKGROUND = "\u001B[40m";
    private static final String ANSI_RED_BACKGROUND = "\u001B[41m";
    private static final String ANSI_GREEN_BACKGROUND = "\u001B[42m";
    private static final String ANSI_YELLOW_BACKGROUND = "\u001B[43m";
    private static final String ANSI_BLUE_BACKGROUND = "\u001B[44m";
    private static final String ANSI_PURPLE_BACKGROUND = "\u001B[45m";
    private static final String ANSI_CYAN_BACKGROUND = "\u001B[46m";
    private static final String ANSI_WHITE_BACKGROUND = "\u001B[47m";

    private static String perfectMsg = ANSI_GREEN + "Congratulations!" + ANSI_RESET + " You solved the" +
            " level with the least amount of attempts!";

    private static String gameDes = "\n\nThe objective of the game is to execute " +
      "each line of code that you see at least once. You have infinite attempts,\n" + 
	    "however the fewer attempts you take, the higher your score will be. Try to execute the code\n" +
	    "with the least amount of tries to maximize your score! To play, type only the parameters in the \n" +
	    "terminal separated by a space if need be and press 'Enter'. Good Luck!";
    
    private int perfectAttempts;
    public int linesOfCode;
    private boolean gameOver;
    private boolean[] linesExecuted;
    public int score;
    private int input;
    public int attempts;
    public int fails;
    private boolean newLine;
    private int returnVal;

    public SuperGame(int perfectAttempts,int linesOfCode, boolean gameOver, boolean[] linesExecuted,
                     int score, int input, int attempts,int fails, boolean newLine, int returnVal) {
        this.gameOver = gameOver;
        this.perfectAttempts = perfectAttempts;
        this.linesOfCode = linesOfCode;
        this.attempts = attempts;
        this.fails = fails;
        this.newLine = newLine;
        this.linesExecuted = linesExecuted;
        this.score = score;
        this.input = input;
        this.returnVal = returnVal;
    }

    // abstract methods for each level to implement
    public abstract void analyzeInput();
    public abstract void acquireInput();
    public abstract void printLeaderboard();

    public void printStartingMessage() {
      System.out.println(gameDes + "\n\n");
    }

    public void printCode (String[] codeWithoutStars, String methodName) {
        System.out.println(methodName); 

        for(int i = 0; i < linesOfCode; i++) {
            System.out.print(linesExecuted[i] ? "*" : " ");
            System.out.println(codeWithoutStars[i]);

        }

        System.out.println("}\n"); // prints end curly bracket
    }


    public void checkGameOver(){
        for(int i = 0; i < linesExecuted.length; i++) {
	    if(!linesExecuted[i]) {
                return; // if one line hasn't been executed, game is NOT over
            }
        }

        gameOver = true;
        return;
    }

    public void newLineExecuted() {
      this.newLine = true;
    }

    public void setReturnVal(int returnVal) {
      this.returnVal = returnVal;
    }

    public void linesExecuted(int index) {
      linesExecuted[index] = true;
    }

    public boolean getGameOver() {
      return gameOver;
    }

    public int getScore() {
      return score;
    }

    public void updateScore(){
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

    public boolean checkPerfectAttempts() {
      if(attempts == perfectAttempts) {
        System.out.println(perfectMsg);
	return true;
      }
      return false;
    }

    public void printEndingMessage() {
      score = linesOfCode - attempts - fails;
      System.out.println("Level Complete! Your score was " + (score));
      System.out.println("Total Attempts: " + attempts);	
    }

}
