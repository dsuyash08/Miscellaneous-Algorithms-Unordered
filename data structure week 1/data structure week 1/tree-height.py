# python3

import sys, threading
from collections import deque
sys.setrecursionlimit(10**7) # max depth of recursion
threading.stack_size(2**27)  # new thread will get stack of such size


class TreeHeight:
        def read(self):
                self.n = int(sys.stdin.readline())
                self.parent = list(map(int, sys.stdin.readline().split()))

       
        
            
        def compute_height(self):
                # Replace this code with a faster implementation
                nodes= [[]]
                for i in range(self.n):
                    nodes.append([])
                for i in range(self.n):
                    if self.parent[i] == -1:
                        root = i
                        pass
                    nodes[self.parent[i]].append(i)


                maxHeight = 0
                q = deque()
                index = 0
                q.append(nodes[root])
                while(len(q) != 0):
                    index = len(q)
                    while(index > 0):
                        temp = q.popleft()
                        index -= 1
                        for i in temp:
                            q.append(nodes[i])
                    maxHeight += 1
                    
                return maxHeight;

def main():
  tree = TreeHeight()
  tree.read()  
  print(tree.compute_height())

threading.Thread(target=main).start()
