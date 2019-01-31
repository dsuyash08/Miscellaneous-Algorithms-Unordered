# Uses python3
def edit_distance(s, t):
    d = [[0]*(len(s)+ 1)for i in range(len(t) + 1)]
    for i in range(len(s) + 1):
        d[0][i] = i
    for i in range(len(t) + 1):
        d[i][0] = i
    for j in range(1, len(t) + 1):
        for k in range(1, len(s) + 1):
            ins = d[j][k-1] + 1
            dels = d[j-1][k] + 1
            match = d[j-1][k-1]
            mismatch = d[j-1][k-1] + 1
            if(s[k - 1] == t[j - 1]):
                d[j][k] = min(ins, dels, match)
            else:
                d[j][k] = min(ins, dels, mismatch)
    return d[len(t)][len(s)]

if __name__ == "__main__":
    print(edit_distance(input(), input()))
