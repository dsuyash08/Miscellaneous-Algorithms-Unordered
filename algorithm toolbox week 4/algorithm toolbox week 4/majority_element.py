# Uses python3
import sys

def get_majority_element(a, left, right ):
    
    if(left >= right):
        return a[left]
    mid = (left + right) // 2
    l = get_majority_element(a, left, mid)
    r = get_majority_element(a, mid + 1, right)

    if(l == r):
         return l 
    cl,cr = 0,0
    for i in range(left , right + 1):
        if(l == a[i]):
            cl += 1
        if(r == a[i]):
            cr += 1
    if(cl > (right - left + 1)//2):
        return l
    if(cr > (right - left + 1)//2):
        return r
    return -1


if __name__ == '__main__':
    input = sys.stdin.read()
    n, *a = list(map(int, input.split()))
    if get_majority_element(a, 0, n - 1) != -1:
        print(1)
    else:
        print(0)
