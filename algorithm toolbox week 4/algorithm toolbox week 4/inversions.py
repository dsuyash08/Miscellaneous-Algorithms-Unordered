# Uses python3
import sys
import random

def get_number_of_inversions(a, left, right):
    n = 0
    if left >= right:
        return 0
    ave = (left + right) // 2
    n += get_number_of_inversions(a, left, ave)
    n += get_number_of_inversions(a, ave + 1, right)   
    n += merge(a, left, ave + 1, right)
    return n

def merge(a, left,ave,right):
    d = []
    n = 0
    l,av = left,ave
    while(left < av and ave <= right):
        if(a[left] <= a[ave]):
            d.append(a[left])
            left += 1            
        else:
            d.append(a[ave])
            n += av - left
            ave += 1
    d.extend(a[left:av])
    d.extend(a[ave:right + 1])
    for i in d:
        a[l] = i
        l += 1
    return n





if __name__ == '__main__':
    
    while(True):
        input = sys.stdin.read()       
        n, *a = list(map(int, input.split()))      
        print(get_number_of_inversions(a, 0, len(a) - 1))
        