package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * Hello Substrings 2!
 *
 */
public class App 
{

    /**
     * This is the main program, the solution need to be whited
     * in method SubStringHandler.getSmallestAndLargest
     * 
     */
    public static void main( String[] args )
    {
        Scanner sc = new Scanner(System.in);
        System.out.println( "Hello to Strings - Exercise level 2!" );
        do {
            try {
                System.out.println("Please enter a String or the word 'end' to finish");
                String s = sc.next();
                if (s.equals("end")) {
                    break;
                }
                System.out.println("Please enter the length (a number) of the substrings to find");
                int k = sc.nextInt();
                System.out.println("The result is:");
                System.out.println(SubStringHandler.getSmallestAndLargest(s, k));
            } catch (Exception e) {
                System.out.println("The value it's not correct, please try again!");
                System.out.println(e.getMessage());
                sc.next();
            }
        } while (true);
        System.out.println( "End of program!" );
    }
}
