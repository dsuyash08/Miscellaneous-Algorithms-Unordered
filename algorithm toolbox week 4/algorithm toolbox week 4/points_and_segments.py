# Uses python3
import sys
import operator

'''def fast_count_segments(starts, ends, points):
    cnt = [0] * len(points)
    sorted_points = sorted(list(zip(starts,ends)),key = operator.itemgetter[0])
    for i in range(len(points)):
       k = binary_search(sorted_points,points[i], 0, len(ends) - 1)
       if(k != -1):
            temp = k - 1
            while(True):
                check = 0
                if(k < len(ends) and points[i] >= sorted_points[k][0] and points[i] <= sorted_points[k][1]):
                    cnt[i] += 1
                    k += 1
                    check = 1
                if(temp >= 0 and points[i] >= sorted_points[temp][0] and points[i] <= sorted_points[temp][1]):
                    cnt[i] += 1
                    temp -= 1
                    check = 1
                if(check == 0):
                    break
    return cnt 
'''

def fast_count_segments2(starts, ends, points):
    cnt = [0] * len(points)
    lists = []
    res = {}
    for i in range(len(starts)):
        lists.append([starts[i], 'l'])
        lists.append([ends[i], 'r'])
    for j in range(len(points)):
        lists.append([points[j], 'p'])
        if(points[j] not in res):
            res[points[j]] = [j] 
        else:
            res[points[j]].append(j)

    lists.sort(key = lambda x : (x[0] , x[1]))
    count = 0
    for [i, j] in lists:
        if(j == 'l'):
            count += 1
        elif(j == 'r'):
            count -= 1
        else:
            if(len(res[i]) > 1):
                for j in range(len(res[i])):
                    cnt[res[i][j]] = count
            else:
                cnt[res[i][0]] = count
    return cnt

def binary_search(sorted_points, i, left, right):
    while(True):
        if(left > right):
            return -1
        mid = (left + right) // 2
        if(sorted_points[mid][0] <= i and sorted_points[mid][1] >= i):
            return mid
        if(sorted_points[mid][0] > i):
            right = mid - 1
        if(sorted_points[mid][0] < i):
            left = mid + 1
    

def naive_count_segments(starts, ends, points):
    cnt = [0] * len(points)
    for i in range(len(points)):
        for j in range(len(starts)):
            if starts[j] <= points[i] <= ends[j]:
                cnt[i] += 1
    return cnt

if __name__ == '__main__':
    input = sys.stdin.read()
    data = list(map(int, input.split()))
    n = data[0]
    m = data[1]
    starts = data[2:2 * n + 2:2]
    ends   = data[3:2 * n + 2:2]
    points = data[2 * n + 2:]
    #use fast_count_segments
    cnt = fast_count_segments2(starts, ends, points)
    for x in cnt:
        print(x, end=' ')
