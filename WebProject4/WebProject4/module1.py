import math
def minion_game(string):
    # your code goes here
    Stuart,Kevin = 0,0
    t = []
    for i in range(len(string)):      
            t.append([string[i],len(string) - i])  
    vowels = ['A','E','I','O','U']
    for i in t:
        if((str)(i[0]) in vowels):
            Kevin += i[1]
        else:
            Stuart+= i[1]
    if( Kevin > Stuart):
        print("Kevin",Kevin, sep = " ")
    elif(Kevin == Stuart):
        print("Draw")
    else:
        print("Stuart",Stuart, sep = " ")
minion_game(input())
