# Uses python3
import sys

def get_change(m):
    c = [1,3,4]
    t = [0]
    for i in range(1,m+1):
        t.append(100000000)
        for j in c:
            if i - j >= 0:
                t[i] = min(t[i], t[i-j] + 1)           

    return t[len(t) - 1]

if __name__ == '__main__':
    m = int(sys.stdin.read())
    print(get_change(m))
