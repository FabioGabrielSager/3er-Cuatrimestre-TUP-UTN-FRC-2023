package ar.edu.utn.frc.tup.lciii;

import java.math.BigDecimal;
import java.util.*;

/**
 * Hello Inheritance!
 *
 */
public class App 
{

    /**
     * This is the main program
     * 
     */
    public static void main( String[] args ) {
        Figure square = new Square(BigDecimal.valueOf(10));
        Figure rectangle = new Rectangle(BigDecimal.valueOf(10), BigDecimal.valueOf(20));
        Figure circle = new Circle(BigDecimal.valueOf(10));
        List<Figure> figures = Arrays.asList(square, rectangle, circle);
        Figure greater = square;
        for(Figure figure : figures) {
            System.out.println("I'm a " + figure.getClass().getSimpleName());
            System.out.println("\tMy area is: " + figure.getArea());
            System.out.println("\tMy perimeter is: " + figure.getPerimeter());
            if(figure.isGreater(greater)) {
                greater = figure;
            }
        }
        System.out.println("The grater figure is : " + greater.getClass().getSimpleName());
    }
}
