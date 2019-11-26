package com.company;

public abstract class SuperGame {
    int perfectAttempts;
    int linesOfCode;
    static String perfectMsg = "Congratulations! You solved the " +
            "level with the least amount of attempts!";
    static String gameDes = "\n\nThe objective of the game is to execute\n" +
            "each line of code that you see at least once. For each attempt you will get\n" +
            "one point if you execute a new line of code and if not then you will get one\n" +
            "point deducted. Try to execute the code with the least amount of tries to\n" +
            "maximize your score! Input parameters in the terminal separated by a space.\n" +
            "Good Luck!";
    static String levelDes = "\n\nTo play this level input different\n" +
            "parameters into the function that would allow you to reach all the lines\n"+
            "After passing in one parameter press enter. You may have to input multiple\n"+
            "parameters to reach all lines. Have Fun!! ";
    boolean gameOver;
    boolean[] linesExecuted;
    int score;
    int input;
    int attempts;
    int fails;
    boolean newLine;
    int returnVal;
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
    public abstract void analyzeInput();
    public abstract void acquireInput();

    public void printCode (String[] codeWithoutStars) {
        System.out.println("int levelTwo(int x) {");

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

}
