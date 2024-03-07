package ar.edu.utn.frc.tup.lciii;

import java.util.Scanner;

/**
 * if - else Conditional!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        Scanner scanner = new Scanner(System.in);

        int n = scanner.nextInt();
        scanner.skip("(\r\n|[\n\r\u2028\u2029\u0085])?");
        // Write your code here
        if(n%2 != 0)
            System.out.println("Weird");
        else {
            if (n >= 2 && n <= 5)
                System.out.println("Not Weird");

            if(n >= 6 && n <= 20)
                System.out.println("Weird");

            if (n > 20)
                System.out.println("Not Weird");
        }

        scanner.close();
    }
}
