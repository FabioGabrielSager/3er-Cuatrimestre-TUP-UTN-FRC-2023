[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/bnV7xmy1)
# Challenge "Strings"

Two strings **__a__** and **__b__** are called anagrams if they contain all the same characters 
in the same frequencies. For this challenge, the test **is not case-sensitive**. 
For example, the anagrams of **CAT** are **CAT**, **ACT**, **tac**, **TCA**, **aTC**, and **CtA**.

## Function Description

Complete the isAnagram function in the editor.

isAnagram has the following parameters:

* string a: the first string
* string b: the second string

## Returns

* Boolean: If **__a__** and **__b__** are case-insensitive anagrams, return true. Otherwise, return false.

## Input Format

* The first line contains a string **__a__**.
* The second line contains a string **__b__**.

## Constraints

* 1 <= length(a), length(b) <= 50  
* Strings **__a__** and **__b__** consist of English alphabetic characters.
* The comparison should **NOT** be case sensitive.


## Sample Input 0

```
anagram
margana
```

## Sample Output 0

```
Anagrams
```

## Explanation 0

| Character	 | Frequency: anagram	 | Frequency: margana |
|:----------:|:-------------------:|:------------------:|
|  A or a	   |         3	          |         3          |
|  G or g	   |         1	          |         1          |
|  N or n	   |         1	          |         1          |
|  M or m	   |         1	          |         1          |
|  R or r	   |         1	          |         1          |

The two strings contain all the same letters in the same frequencies, so we print "Anagrams".

## Sample Input 1

```
anagramm
marganaa
```

## Sample Output 1

```
Not Anagrams
```

## Explanation 1

| Character	 | Frequency: anagram	 | Frequency: margana |
|:----------:|:-------------------:|:------------------:|
|  A or a	   |         3	          |         4          |
|  G or g	   |         1	          |         1          |
|  N or n	   |         1	          |         1          |
|  M or m	   |         2	          |         1          |
|  R or r	   |         1	          |         1          |

The two strings don't contain the same number of a's and m's, so we print "Not Anagrams".

## Sample Input 2

```
Hello
hello
```

## Sample Output 2

```
Anagrams
```

## Explanation 2

| Character	 | Frequency: anagram	 | Frequency: margana |
|:----------:|:-------------------:|:------------------:|
|  E or e	   |         1	          |         1          |
|  H or h	   |         1	          |         1          |
|  L or l	   |         2	          |         2          |
|  O or o	   |         1	          |         1          |

The two strings contain all the same letters in the same frequencies, so we print "Anagrams".
