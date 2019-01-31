# Uses python3
import sys

def get_change(m):
    c = 0
    while(m > 0):
        if(m >= 10):
            c, m= c+m//10, m%10
        elif(m >= 5):
            c , m= c + m// 5, m % 5
        else:
            c += m
            m = 0

    return c

if __name__ == '__main__':
    m = int(sys.stdin.read())
    print(get_change(m))
