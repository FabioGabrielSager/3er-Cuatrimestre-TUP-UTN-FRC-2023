package ar.edu.utn.frc.tup.lciii;

import java.util.*;

/**
 * Hello Map!
 *
 */
public class App 
{

    /**
     * This is the main program
     * 
     */
    public static void main( String[] args ) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. */
        Map<String, String> phoneBook = new HashMap<>();
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();

        scanner.nextLine();
        for (int i = 0; i < n; i++) {
            String name = scanner.nextLine();
            String phoneNumber = scanner.nextLine();
            while (phoneNumber.length() != 8 || phoneNumber.charAt(0) == '0'){
                phoneNumber = scanner.nextLine();
            }
            phoneBook.put(name, phoneNumber);
        }

        while (scanner.hasNext()) {
            String query = scanner.nextLine();
            String phoneNumber = phoneBook.get(query);
            System.out.println(phoneNumber == null ? "Not found":query + "=" + phoneNumber);
        }

        scanner.close();
    }
}
