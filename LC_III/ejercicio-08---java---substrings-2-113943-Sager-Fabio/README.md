[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/WVzA3rCF)
# Challenge "Substrings 2"

We define the following terms:

* <a href="https://en.wikipedia.org/wiki/Lexicographic_order">Lexicographical Order</a>, 
also known as alphabetic or dictionary order, orders characters as follows:

![A < B < ... < Y < Z < a < b < ... < y < z](/docs/_images/img.png)


For example, ball < cat, dog < dorm, Happy < happy, Zoo < ball.

* A <a href="https://en.wikipedia.org/wiki/Substring">substring</a> of a string is a 
contiguous block of characters in the string. For example, the substrings of 
abc are a, b, c, ab, bc, and abc.

Given a string, **_s_** , and an integer, **_k_** , complete the function so that it finds the lexicographically smallest and largest substrings of length .

## Function Description

Complete the getSmallestAndLargest function in the editor below.

getSmallestAndLargest has the following parameters:

* string s: a string
* int k: the length of the substrings to find

## Returns

string: the string ' + "\n" + ' where and are the two substrings

## Input Format

The first line contains a string denoting **_s_**.
The second line contains an integer denoting **_k_**.

## Constraints

![1 <= |s| <= 1000](/docs/_images/img_1.png)


## Sample Input 0

```
welcometojava
3
```

## Sample Output 0

```
ava
wel
```

## Explanation 0

String **_s_ = "welcometojava"** has the following lexicographically-ordered substrings of length :

![eg](/docs/_images/img_2.png)

We then return the first (lexicographically smallest) substring and the last (lexicographically largest) 
substring as two newline-separated values (i.e., ava\nwel).

The stub code in the editor then prints ava as our first line of output and wel as our second line of output.