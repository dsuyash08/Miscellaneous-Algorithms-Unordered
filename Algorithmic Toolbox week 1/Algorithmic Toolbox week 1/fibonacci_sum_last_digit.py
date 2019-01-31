# Uses python3
import sys

def fibonacci_sum_naive(n):
    if n <= 1:
        return n

    previous = 0
    current  = 1
    sum      = 1

    for _ in range(n - 1):
        previous, current = current, previous + current
        sum += current

    return sum % 10

def calc_fib(n):
    temp = []
    sum = []
    sum.append(0)
    sum.append(1)
    if(n < 1):
        return 0
    prev = 0
    curr = 1
    for i in range(2,n + 1):
        temp = curr
        curr = (curr + prev)%10
        prev = temp
        sum.append((sum[i-1] + curr)%10)
        if(sum[i] == 1 and sum[i-1] == 0):
            return sum[n %(i-1)]
    return sum[n]



if __name__ == '__main__':
    input = sys.stdin.read()
    n = int(input)
    print(calc_fib(n))
