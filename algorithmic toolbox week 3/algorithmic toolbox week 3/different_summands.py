# Uses python3
import sys

def optimal_summands(n):
    summands = []
    sum = 0
    for i in range(1,n+1):
        if(sum == n):
            break
        if(n - sum >= i and n - (sum + i) >= i + 1):
            sum = sum + i
            summands.append(i)
        else:
            summands.append(n - sum)
            sum = n
    return summands

if __name__ == '__main__':
    input = sys.stdin.read()
    n = int(input)
    summands = optimal_summands(n)
    print(len(summands))
    for x in summands:
        print(x, end=' ')
