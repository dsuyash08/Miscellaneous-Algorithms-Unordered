#Uses python3

import sys

def lcs2(s, t):
    d = [[0]*(len(s)+ 1)for i in range(len(t) + 1)]
    
    for j in range(1, len(t) + 1):
        for k in range(1, len(s) + 1):
            ins = d[j][k-1]
            dels = d[j-1][k]
            mismatch = d[j-1][k-1]
            match = d[j-1][k-1] + 1
            if(s[k - 1] == t[j - 1]):
                d[j][k] = max(ins, dels, match)
            else:
                d[j][k] = max(ins, dels, mismatch)
    return d[len(t)][len(s)]

if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))

    n = data[0]
    data = data[1:]
    a = data[:n]

    data = data[n:]
    m = data[0]
    data = data[1:]
    b = data[:m]

    print(lcs2(a, b))
