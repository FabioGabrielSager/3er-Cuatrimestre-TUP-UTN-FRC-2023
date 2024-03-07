# Challenge "Inheritance"

In this exercise we need to practice inheritance. 
To do this we are going to work with some geometric figures

In this case, the main method should not be modified, 
we will only work on the classes that will implement the inheritance.

The "Figure" class is provided which contains 2 methods to be implemented.
You must create the classes "Square", "Rectangle" and "Circle" that will extend "Figure".

## Constructors

* **Square**: need to implement a constructor that request the size of your sides.
* **Rectangle**: will request base and height
* **Circle**: the constructor will request the radius.

## Getters & Setters

Getters and Setters need to be implemented.

## Extra Methods

Additionally, all classes must implement the "isGreater" method that will 
receive another figure as a parameter and will return "true" or "false" 
if the consulted figure has a larger area than the one passed by parameter.

--------------

## Input Format

N/A

## Output Format

All methods to be implemented need to use **_BigDecimal_** type and return a representation
of this number with 2 decimal.

## Sample Input

```
N/A
```

## Sample Output

```
I'm a Square
	My area is: 100.00
	My perimeter is: 40.00
I'm a Rectangle
	My area is: 200.00
	My perimeter is: 60.00
I'm a Circle
	My area is: 314.16
	My perimeter is: 62.83
The grater figure is : Circle
```
