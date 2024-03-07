package ar.edu.utn.frc.tup.lciii;

import javax.sound.midi.SysexMessage;
import java.util.Scanner;

/**
 * Hello Strings 2!
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
        String a = sc.nextLine();
        a = a.replaceAll("\\s+", "");
        /* Enter your code here. Print output to STDOUT. */
        boolean esUnPalindromo = true;
        int i = 0;
        int cantidadDeIteracionesAdar = a.length()/2;
        while(esUnPalindromo && i < cantidadDeIteracionesAdar){
            if(a.toLowerCase().charAt(i) != a.toLowerCase().charAt(a.length()-i-1)) {
                esUnPalindromo = false;
            }
            i++;
        }
        if(esUnPalindromo)
            System.out.println("Yes");
        else
            System.out.println("No");
        sc.close();

    }
}
