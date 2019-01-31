# Uses python3
from sys import stdin

def fibonacci_sum_squares_naive(n):
    if n <= 1:
        return n

    previous = 0
    current  = 1
    sum      = 1

    for _ in range(n - 1):
        previous, current = current, previous + current
        sum += current * current

    return sum % 10

def fibonacci_sum_squares_naive(n):
    sum = []
    sum.append(0)
    sum.append(1)
    prev,curr = 0,1
    for i in range(2, n+1):
        prev,curr = curr, (curr + prev)%10
        sum.append((sum[i-1] + curr*curr)%10)
        if(sum[i] == 1 and sum[i-1] == 0):
            return sum[n %(i-1)]
    return sum[n]

if __name__ == '__main__':
    n = int(stdin.read())
    print(fibonacci_sum_squares_naive(n))
