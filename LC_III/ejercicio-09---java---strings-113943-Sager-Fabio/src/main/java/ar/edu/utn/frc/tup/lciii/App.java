package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * Hello Strings!
 *
 */
public class App 
{

    /**
     * This is the main program, the solution need to be whited
     * in method AnagramsHandler.isAnagram
     * 
     */
    public static void main( String[] args )
    {
        Scanner sc = new Scanner(System.in);
        System.out.println( "Hello to Strings" );
        do {
            try {
                System.out.println("Please enter the first String or the word 'end' to finish");
                String a = sc.next();
                if (a.equals("end")) {
                    break;
                }
                System.out.println("Please enter the second String to check if is an anagram");
                String b = sc.next();
                Boolean result = AnagramsHandler.isAnagram(a, b);
                if(result == null) {
                    System.out.println("The result is null, Do you change the return statement? ;) ");
                } else {
                    System.out.println("The result is:");
                    System.out.println( (result) ? "Anagrams" : "Not Anagrams" );
                }
            } catch (Exception e) {
                System.out.println("The value it's not correct, please try again!");
                sc.next();
            }
        } while (true);
        System.out.println( "End of program!" );
    }
}
