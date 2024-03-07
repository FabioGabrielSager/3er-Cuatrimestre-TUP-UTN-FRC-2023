[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/S8-HIoDs)
# Challenge "Strings 3"

This exercise is to test your understanding of Java Strings. A sample String declaration:

```
String myString = "Hello World!"
```

The elements of a String are called characters. The number of characters in a String is called the length, 
and it can be retrieved with the String.length() method.

Given two strings of lowercase English letters **_a_** and **_b_**, perform the following operations:

1. Sum the lengths of **_a_** and **_b_**.
2. Determine if **_a_** is lexicographically larger than **_b_** (i.e.: does **_b_** come before **_a_** in the dictionary?).
3. Capitalize the first letter in **_a_** and **_b_** and print them on a single line, separated by a space.

## Input Format

The first line contains a string **_a_**. The second line contains another string **_b_**. 
The strings are comprised of only lowercase English letters.

## Output Format

There are three lines of output:

For the first line, sum the lengths of **_a_** and **_b_**.

For the second line, write **Yes** if **_a_** is lexicographically greater than **_b_** 
otherwise print **No** instead.

For the third line, capitalize the first letter in both **_a_** and **_b_** and print them on a 
single line, separated by a space.

## Sample Input 0

```
hello
java
```

## Sample Output 0

```
9
No
Hello Java
```

## Explanation 0

String **_a_** is "hello" and **_b_** is "java".

**_a_** has a length of **_5_**, and **_b_** has a length of **_4_**; the sum of their lengths is **_9_**.

When sorted alphabetically/lexicographically, "hello" precedes "java"; therefore, **_a_** is not greater than **_b_** and the answer is **No**.

When you capitalize the first letter of both **_a_** and **_b_** and then print them separated by a space, you get "Hello Java".