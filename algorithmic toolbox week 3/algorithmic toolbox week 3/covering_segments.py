# Uses python3
import sys
from collections import namedtuple

Segment = namedtuple('Segment', 'start end')

def optimal_points(segment):
    segments = sorted(segment, key = lambda x : x[0])
    p = []
    i = 0
    l = segments[0][1]
    s = 1
    while(i < len(segments)):
        l = segments[i][1]
        while(i < len(segments) and segments[i][0] <= l):
            if(segments[i][1]<= l):
                l = segments[i][1]
            i += 1
        p.append([s, l])
        s += 1
    return p

if __name__ == '__main__':
    input = sys.stdin.read()
    n, *data = map(int, input.split())
    segments = list(map(lambda x: Segment(x[0], x[1]), zip(data[::2], data[1::2])))
    points = optimal_points(segments)
    print(len(points))
    for p in points:
        print(p[1], end=' ')
