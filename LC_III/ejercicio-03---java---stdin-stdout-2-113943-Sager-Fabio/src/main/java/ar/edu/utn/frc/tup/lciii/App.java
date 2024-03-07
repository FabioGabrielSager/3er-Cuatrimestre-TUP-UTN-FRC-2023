package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * Stdin & Stdout 2!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        Scanner scan = new Scanner(System.in);
        int i = scan.nextInt();
        // Write your code here.
        scan.nextLine();
        String doubleString = scan.nextLine();
        doubleString = doubleString.replace(",", ".");
        double d = Double.parseDouble(doubleString);
        String s = scan.nextLine();
        scan.close();

        System.out.println("String: " + s);
        System.out.println("Double: " + d);
        System.out.println("Int: " + i);
    }
}
