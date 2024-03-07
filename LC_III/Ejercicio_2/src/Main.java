import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
       Scanner keyboard = new Scanner(System.in);

       System.out.print("Ingrese una cadena:");
       // El método next no acepta espacios mientras que nextLine si:
       // keyboard.next()
       String myString = keyboard.nextLine();
       System.out.println();
       System.out.print("Ingrese un entero:");
       int myInt = keyboard.nextInt();

       System.out.println("My string is: " + myString);
       System.out.println("My int is: " + myInt);
    }
}