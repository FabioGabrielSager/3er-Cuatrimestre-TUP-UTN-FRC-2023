package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * Sub-Strings!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        Scanner in = new Scanner(System.in);
        String s = in.next();
        int start = in.nextInt();
        int end = in.nextInt();

        System.out.println(s.substring(start, end));

        in.close();
    }
}
