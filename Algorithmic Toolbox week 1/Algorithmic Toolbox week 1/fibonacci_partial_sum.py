# Uses python3
import sys

def fibonacci_partial_sum_naive(from_, to):
    sum = 0

    current = 0
    next  = 1

    for i in range(to + 1):
        if i >= from_:
            sum += current

        current, next = next, current + next

    return sum % 10

def fab(from_,to):
    sum = []
    sum.append(0)
    sum.append(1)
    prev,curr = 0,1
    for i in range(2, to + 1, 1):
        prev,curr = curr, (curr + prev)%10
        sum.append((sum[i-1] + curr)%10)
        if(sum[i] == 1 and sum[i-1] == 0):
            break
    if(len(sum) < to - 1):
        if(from_ < 1):
            start = sum[(temp)%(len(sum)-2)]
        else:
            start = sum[(from_ -1)%(len(sum) -2)]
        end = sum[(to)%(len(sum)-2)]
    elif(from_ < 1):
        start = sum[from_] 
        end =  sum[to]
    else:
        end =  sum[to]
        start = sum[from_ - 1]
    if(end < start):
        return (end + 10 - start)%10
    else:
        return end - start

if __name__ == '__main__':
    input = sys.stdin.read();
    from_, to = map(int, input.split())
    print(fab(from_, to))