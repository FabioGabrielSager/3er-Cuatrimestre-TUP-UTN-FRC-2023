package ar.edu.utn.frc.tup.lciii;

import java.util.*;

/**
 * Hello Stack!
 *
 */
public class App 
{

    /**
     * This is the main program
     * 
     */
    public static boolean isStringBalanced(String string){
        Stack<Character> stack = new Stack<Character>();
        Map<Character, Character> parenthesesMap = Map.of('(', ')','{', '}','[', ']');
        for (int i=0; i < string.length(); i++) {
            Character currentChar = string.charAt(i);
            if ("({[".contains(String.valueOf(currentChar))) {
                stack.push(currentChar);
            }
            else if (stack.isEmpty() || parenthesesMap.get(stack.pop()) != currentChar) {
                return false;
            }
        }

        return stack.isEmpty();
    }
    public static void main( String[] args ) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. */
        Scanner scanner = new Scanner(System.in);

        while(scanner.hasNextLine()) {
            String string = scanner.nextLine();
            System.out.println(isStringBalanced(string));
        }
        scanner.close();
    }
}
