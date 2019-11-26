package main;

import java.util.*;

public class Level1 extends SuperGame {

    static final int perfectAttempts = 2;
    static final int linesOfCode = 7;
    static boolean gameOver = false;
    static boolean[] linesExecuted = new boolean[linesOfCode];
    static int score = 0;
    static int input = 0;
    static int attempts = 0;
    static int fails = 0;
    static boolean newLine = false;
    static int returnVal = 0;
    static String[] codeWithoutStars = new String[] {
            "    x = x + 3 ",
            "    if(x < 7 && x > -1 &&( (x + 1) <= 4 || (x % 3) == 0)) {",
            "      return x % 3;",
            "    }",
            "    else if(((x % 7) == 4) &&(x < 6 ) ) {",
            "      return x + 2;",
            "    }"


    };

    public Level1() {

        super(perfectAttempts,linesOfCode,gameOver,
                linesExecuted,score,input,attempts,fails,newLine,returnVal);
    }
    @Override
    public void analyzeInput(int input) {
        int x = input;

        x = x + 3;
        linesExecuted[0] = true;
        if(x < 7 && x > -1 &&( (x + 1) <= 4 || (x % 3) == 0)) {
            linesExecuted[1] = true;
            linesExecuted[2] = true;
            linesExecuted[3] = true;
        }

        else if(((x % 7) == 4) &&(x < 6 ) ) {
            linesExecuted[4] = true;
            linesExecuted[5] = true;
            linesExecuted[6] = true;
        }
    }

    @Override
    public int acquireInput() {
        Scanner takesInput = new Scanner(System.in);
        input = takesInput.nextInt();
        return input;

    }

    public static void main (String[] args) {
        SuperGame superGame = new Level1();

        System.out.println(SuperGame.gameDes + "\n\n"); // prints out game description
        System.out.println(SuperGame.levelDes + "\n\n");

        while (!gameOver) {
            superGame.printCode(codeWithoutStars);
            superGame.analyzeInput(superGame.acquireInput());
            superGame.updateScore();
            superGame.checkGameOver();
        }
       superGame.printCode(codeWithoutStars);
        // checks if the user won with least amount of tests possible
        if (attempts == perfectAttempts) {
            System.out.println(perfectMsg);
        }
    }

}
