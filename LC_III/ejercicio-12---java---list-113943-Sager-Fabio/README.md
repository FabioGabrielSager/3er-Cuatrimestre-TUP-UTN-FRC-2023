[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/OC5l08CH)
# Challenge "List"

For this problem, we have **_2_** types of queries you can perform on a [List](https://docs.oracle.com/javase/7/docs/api/java/util/List.html):

1. Insert **_y_** at index **_x_**:

```
Insert
x y
```

2. Delete the element at index **_x_**:

```
Delete
x
```

Given a list **_L_**, of **_N_** integers, perform **_Q_** queries on the list. Once all 
queries are completed, print the modified list as a single line of space-separated integers.

## Input Format

The first line contains an integer **_N_** (the initial number of elements in **_L_**).
The second line contains **_N_** space-separated integers describing **_L_**.
The third line contains an integer, **_Q_** (the number of queries).
The **_2Q_** subsequent lines describe the queries, and each query is described over two lines:

* If the first line of a query contains the String **_Insert_**, then the second line contains 
two space separated integers **_x_** **_y_**, and the value **_y_** must be inserted into **_L_** 
at index **_x_**.
* If the first line of a query contains the String **_Delete_**, then the second line 
contains index **_x_**, whose element must be deleted from **_L_**.

## Constraints

![img](/docs/_images/img.png)

## Output Format

Print the updated list **_L_** as a single line of space-separated integers.

## Sample Input

```
5
12 0 1 78 12
2
Insert
5 23
Delete
0
```

## Sample Output 0

```
0 1 78 12 23
```

## Explanation 0

![img](/docs/_images/img_1.png)

Having performed all **_Q_** queries, we print **_L<sub>1</sub>_** as a single line of space-separated integers.