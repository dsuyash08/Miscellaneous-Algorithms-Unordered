# Uses python3
import sys

def get_optimal_value(capacity, weights, values):
    value = 0
    # write your code here
    pairs = list(map(list,zip(values, weights)))
    sortedpairs = list(sorted(
        pairs, key = lambda x: x[0]/x[1], reverse = True
        ))
    for i in range(len(sortedpairs)):
        if(capacity == 0):
            return value
        a = min(capacity, sortedpairs[i][1]) 
        value += a * (sortedpairs[i][0]/sortedpairs[i][1])
        capacity = capacity - a
        sortedpairs[i][1] = sortedpairs[i][1] - a
    return value


if __name__ == "__main__":
    data = list(map(int, sys.stdin.read().split()))
    n, capacity = data[0:2]
    values = data[2:(2 * n + 2):2]
    weights = data[3:(2 * n + 2):2]
    opt_value = get_optimal_value(capacity, weights, values)
    print("{:.10f}".format(opt_value))
