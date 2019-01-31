#uses python3

import sys
import threading

# This code is used to avoid stack overflow issues
sys.setrecursionlimit(10**6) # max depth of recursion
threading.stack_size(2**26)  # new thread will get stack of such size


class Vertex:
    def __init__(self, weight):
        self.weight = weight
        self.fun = -1
        self.children = []


def ReadTree():
    size = int(input())
    tree = [Vertex(w) for w in map(int, input().split())]
    for i in range(1, size):
        a, b = list(map(int, input().split()))
        tree[a - 1].children.append(b - 1)
        tree[b - 1].children.append(a - 1)
    return tree


def dfs(tree, vertex, parent):
    if tree[vertex].fun == -1:
        if len(tree[vertex].children) == 1 and vertex != 0:
            tree[vertex].fun = tree[vertex].weight
        else:
            m1 = tree[vertex].weight
            m2 = 0
            for child in tree[vertex].children:
                if child != parent:
                    m2 = m2 + dfs(tree, child, vertex)
                    for granchild in tree[child].children:
                        if granchild != vertex:
                            m1 = m1 + dfs(tree, granchild, child)
            tree[vertex].fun = max(m1,m2)
    return tree[vertex].fun


    # This is a template function for processing a tree using depth-first search.
    # Write your code here.
    # You may need to add more parameters to this function for child processing.


def MaxWeightIndependentTreeSubset(tree):
    size = len(tree)
    if size == 0:
        return 0
    fun = dfs(tree, 0, -1)
    # You must decide what to return.
    return fun


def main():
    tree = ReadTree();
    weight = MaxWeightIndependentTreeSubset(tree);
    print(weight)


# This is to avoid stack overflow issues
threading.Thread(target=main).start()
