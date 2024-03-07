package ar.edu.utn.frc.tup.lciii;

import java.beans.PropertyEditorSupport;
import java.util.Scanner;

/**
 * Loops & Math 2!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        Scanner in = new Scanner(System.in);
        String result = "";

        int t = in.nextInt();
        for(int i=0;i<t;i++){
            int a = in.nextInt();
            int b = in.nextInt();
            int n = in.nextInt();

            int aux = a;
            for(int j=0;j<n;j++){
                aux += (int)Math.pow(2, j)*b;
                if (j != 0)
                    result +=  " ";
		        result += aux;
            }
	        result += "\n";
        }
        System.out.print(result);
        in.close();
    }
}
