# Uses python3
import sys

def get_fibonacci_huge_naive(n, m):
    if n <= 1:
        return n

    previous = 0
    current  = 1

    for _ in range(n - 1):
        previous, current = current, previous + current

    return current % m

def get_fibonacci_huge(n, m):
    if(n <= 1):
        return n
    temp = []
    temp.append(0)
    temp.append(1)
    for i in range(2,n + 1):
        temp.append((temp[i-1] +temp[i-2])%m)
        if(i == n):
            return temp[n]            
        if(temp[i] == 1 and temp[i-1] == 0):
            return temp[n %(i-1)]



if __name__ == '__main__':
    input = sys.stdin.read();
    n, m = map(int, input.split())
    print(get_fibonacci_huge(n, m))
