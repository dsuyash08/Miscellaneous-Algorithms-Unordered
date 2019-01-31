# Uses python3
def calc_fib_naive(n):
    if (n <= 1):
        return n

    return calc_fib(n - 1) + calc_fib(n - 2)

def calc_fib(n):
    temp = []
    if(n < 1):
        return 0
    temp.append(0)
    temp.append(1)
    for i in range(2,n + 1):
        temp.append((temp[i-1] + temp[i-2])%10)
    return temp[n]

n = int(input())
print(calc_fib(n))
