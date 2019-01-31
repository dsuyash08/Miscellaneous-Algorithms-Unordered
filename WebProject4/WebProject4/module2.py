#!/bin/python3

import math
import os
import random
import re
import sys

# Complete the time_delta function below.
def time_delta(t1, t2):
    tx = t1.split()
    ty = t2.split()
    x = tx[5]
    y = ty[5]
    if((x[1] == '+' and y[1] == '+') or (x[1] == '-' and y[1] == '-')):
        diff = (3600*(int)(x[1:3]) + 60*(x[3:5])) - (3600*(int)(y[1:3]) + 60*(y[3:5]))
    else:
        diff = (3600*(int)(x[1:3]) + 60*(x[3:5])) + (3600*(int)(y[1:3]) + 60*(y[3:5]))
    return math.fabs(diff)


if __name__ == '__main__':
    #fptr = open(os.environ['OUTPUT_PATH'], 'w')

    t = int(input())

    for t_itr in range(t):
        t1 = input()

        t2 = input()

        delta = time_delta(t1, t2)

        fptr.write(delta + '\n')

    fptr.close()

