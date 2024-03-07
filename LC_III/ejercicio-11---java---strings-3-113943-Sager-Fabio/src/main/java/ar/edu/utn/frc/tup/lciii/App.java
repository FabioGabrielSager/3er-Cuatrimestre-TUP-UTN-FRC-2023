package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * Hello Strings 3!
 *
 */
public class App 
{

    /**
     * This is the main program
     * 
     */
    public static void main( String[] args )
    {
        Scanner sc=new Scanner(System.in);
        String a =sc.next();
        String b =sc.next();
        /* Enter your code here. Print output to STDOUT. */
        int legnthsSum = a.length() + b.length();
        String aIsLargerThenb = "No";
        if(a.compareTo(b) > 0)
            aIsLargerThenb = "Yes";

        System.out.println(legnthsSum + "\n" + aIsLargerThenb + "\n" +
        a.toUpperCase().charAt(0) + a.toLowerCase().substring(1, a.length()) + " " +
        b.toUpperCase().charAt(0) + b.toLowerCase().substring(1, b.length()));
    }
}
