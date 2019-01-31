#Uses python3

import sys

def maxcheck(i, max):
    if((int)(max) < 0 or (int)(i + max) > (int)(max + i) ):
        return True
    else:
        return False

def largest_number(a):
    #write your code here
    res = ""
    while(len(a)!= 0):
        max = -1
        for i in a:
            if(maxcheck(i,max)):
                max = i
        res = res + max
        a.remove(max)
    return res



if __name__ == '__main__':
    input = sys.stdin.read()
    data = input.split()
    a = data[1:]
    print(largest_number(a))
    
