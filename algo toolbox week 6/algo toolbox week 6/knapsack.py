# Uses python3
import sys

def optimal_weight(W, w):
    # write your code here
    result = 0
    d = [[0]*(W + 1)for i in range(len(w) + 1)]    
    for i in range(1,len(w) + 1):
        for j in range(1, W + 1):
            d[i][j] = d[i-1][j]
            if(j >= w[i - 1]):
                if(d[i - 1][j-w[i - 1]] + w[i -1]) > d[i][j]:
                    d[i][j] = (d[i - 1][j-w[i - 1]] + w[i -1])
    return d[len(w)][W]

if __name__ == '__main__':
    input = sys.stdin.read()
    W, n, *w = list(map(int, input.split()))
    print(optimal_weight(W, w))
