[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Hcd-4r03)
# Challenge "Loops 2"

We use the integers **_a_**, **_b_** and **_n_** to create the following series:

![series](/docs/_images/img.png)

You are given **_q_** queries in the form of **_a_**, **_b_** and **_n_**. 
For each query, print the series corresponding to the given 
**_a_**, **_b_** and **_n_** values as a single line of **_n_** space-separated integers.

## Input Format

The first line contains an integer **_q_**, denoting the number of queries.

Each line **_i_** of the **_q_** subsequent lines contains three space-separated 
integers describing the respective 
**_a_**<sub>**_i_**</sub>, **_b_**<sub>**_i_**</sub> and **_n_**<sub>**_i_**</sub> values for that query.

## Constraints

![2 <= n <= 20](/docs/_images/img_1.png)

## Output Format

For each query, print the corresponding series on a new line. 
Each series must be printed in order as a single line of **_n_** space-separated integers.

## Sample Input

```
2
0 2 10
5 3 5
```

## Sample Output

```
2 6 14 30 62 126 254 510 1022 2046
8 14 26 50 98
```

## Explanation

We have two queries:

1. We use **_a = 0_**, **_b = 2_** and **_n = 10_** to produce some series
**_S_**<sub>**_0_**</sub>, **_S_**<sub>**_1_**</sub>, ... , **_S_**<sub>**_n_**</sub>:

* **_S_**<sub>**_0_**</sub> = 0 + 1 * 2 = 2
* **_S_**<sub>**_1_**</sub> = 0 + 1 * 2 + 2 * 2 = 6
* **_S_**<sub>**_2_**</sub> = 0 + 1 * 2 + 2 * 2 + 4 * 2 = 14

    ... and so on.

    Once we hit **_n = 10_**, we print the first ten terms as a single line of space-separated integers.

2. We use **_a = 5_**, **_b = 3_** and **_n = 5_** to produce some series
**_S_**<sub>**_0_**</sub>, **_S_**<sub>**_1_**</sub>, ... , **_S_**<sub>**_n_**</sub>:

* **_S_**<sub>**_0_**</sub> = 5 + 1 * 3 = 8
* **_S_**<sub>**_1_**</sub> = 5 + 1 * 3 + 2 * 3 = 14
* **_S_**<sub>**_2_**</sub> = 5 + 1 * 3 + 2 * 3 + 4 * 3 = 26
* **_S_**<sub>**_2_**</sub> = 5 + 1 * 3 + 2 * 3 + 4 * 3 + 8 * 3 = 50
* **_S_**<sub>**_2_**</sub> = 5 + 1 * 3 + 2 * 3 + 4 * 3 + 8 * 3 + 16 * 3 = 98

    We then print each element of our series as a single line of space-separated values.
