# Uses python3
import sys

def optimal_sequence1(n):
    sequence = []
    while n >= 1:
        sequence.append(n)
        if n % 3 == 0:
            n = n // 3
        elif n % 2 == 0:
            n = n // 2
        else:
            n = n - 1
    return reversed(sequence)

def optimal_sequence(m):
    t = [0,0]
    seq = []

    for i in range(2,m+1):
        t.append(t[i-1] + 1)
        if(i % 2 == 0):
            t[i] = min(t[i], t[i//2] + 1)
        if(i % 3 == 0):
            t[i] = min(t[i], t[i//3] + 1)
    seq.append(m)

    while(m > 1):
        minm = m - 1
        if(m % 2 == 0):
            if(t[m//2] < t[minm]):
                minm = m//2
        if(m % 3 == 0):
            if(t[m//3] < t[minm]):
                minm = m//3
        m = minm
        seq.append(m)

    return reversed(seq)


input = sys.stdin.read()
n = int(input)
sequence = list(optimal_sequence(n))
print(len(sequence) - 1)
for x in sequence:
    print(x, end=' ')
