[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/H9ZKLgRQ)
# Challenge "Map"

You are given a phone book that consists of people's names and their 
phone number. After that you will be given some person's name as query. 
For each query, print the phone number of that person.

## Input Format

The first line will have an integer **_n_** denoting the number of 
entries in the phone book. Each entry consists of two lines: a name 
and the corresponding phone number.

After these, there will be some queries. Each query will contain a 
person's name. Read the queries until end-of-file.

## Constraints

A person's name consists of only lower-case English letters and it 
may be in the format 'first-name last-name' or in the format 
'first-name'. Each phone number has exactly 8 digits without any 
leading zeros.

![img](/docs/_images/img.png)

## Output Format

For each case, print "Not found" if the person has no entry in the phone 
book. Otherwise, print the person's name and phone number. See sample 
output for the exact format.

To make the problem more entertaining and difficult, write your own from scratch.

## Sample Input

```
3
uncle sam
99912222
tom
11122222
harry
12299933
uncle sam
uncle tom
harry
```

## Sample Output 0

```
uncle sam=99912222
Not found
harry=12299933
```
