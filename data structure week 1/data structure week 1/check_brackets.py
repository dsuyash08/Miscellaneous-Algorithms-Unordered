# python3

from collections import namedtuple

Bracket = namedtuple("Bracket", ["char", "position"]) 

def are_matching(left, right):
    return (left + right) in ["()", "[]", "{}"]


def find_mismatch(text):
    opening_brackets_stack = []
    for i, next in enumerate(text):
        if next in "([{":           
            opening_brackets_stack.append(Bracket(next,i+1))
            pass
        if next in ")]}":            
            if(len(opening_brackets_stack) >= 1):
                if(not are_matching(opening_brackets_stack.pop()[0], next)):
                        return i + 1
            else:
                return i + 1
            pass
    if len(opening_brackets_stack) == 0:
        return -1
    else:
        return opening_brackets_stack.pop()[1]



def main():
    text = input()
    mismatch = find_mismatch(text)
    # Printing answer, write your code here
    if mismatch == -1:
        print("Success")
    else:
        print(mismatch)


if __name__ == "__main__":
    main()
