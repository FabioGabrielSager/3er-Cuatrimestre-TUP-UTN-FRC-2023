package ar.edu.utn.frc.tup.lciii;

import java.awt.desktop.SystemEventListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

/**
 * Hello List!
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
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. */
        Scanner scanner = new Scanner(System.in);

        int N = scanner.nextInt();
        scanner.nextLine();
        String[] elements = scanner.nextLine().split("\\s+");
        List<Integer> L = new ArrayList<Integer>();
        for(int i=0; i<N;i++){
            L.add(Integer.parseInt(elements[i]));
        }

        int Q = scanner.nextInt();
        scanner.nextLine();
        for(int i=0; i<Q; i++){
            String query = scanner.nextLine();
            if(query.contentEquals("Insert")){
                String[] indexAndElement = scanner.nextLine().split("\\s+");
                int index = Integer.parseInt(indexAndElement[0]);
                int element = Integer.parseInt(indexAndElement[1]);
                if(index <= N && index >= 0){
                    L.add(index, element);
                }
            } else if (query.contentEquals("Delete")) {
                int index = scanner.nextInt();
                scanner.nextLine();
                if(index >= 0 && index <= N){
                    L.remove(index);
                }
            }
        }
        scanner.close();
        String result = L.toString().replaceAll("\\[|\\]", "").replace(",", "");
        System.out.println(result);
    }
}
