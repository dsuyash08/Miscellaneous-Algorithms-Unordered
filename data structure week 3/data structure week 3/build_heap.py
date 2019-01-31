# python3

class HeapBuilder:
  def __init__(self):
    self._swaps = []
    self._data = []

  def ReadData(self):
    n = int(input())
    self._data = [int(s) for s in input().split()]
    assert n == len(self._data)

  def WriteResponse(self):
    n,swaps = self.buildheap()
    print(n)
    for swap in swaps:
      print(swap[0], swap[1])
    
    
  def buildheap(self):
      swaps = []
      n = 0
      for i in range(len(self._data)//2,-1, -1):
          n += self.shiftdown(i, swaps)
      return n,swaps

  def shiftdown(self,i, swaps):
      count = 0
      min = i
      if 2*i + 1 < len(self._data) and self._data[min] > self._data[2*i + 1]:
          min = 2*i + 1
      if 2*i + 2 < len(self._data) and self._data[min] > self._data[2*i + 2]:
          min = 2*i + 2
      if min != i:
          count += 1
          self._data[i],self._data[min] = self._data[min],self._data[i]
          swaps.append([i,min])
          count += self.shiftdown(min,swaps)
      return count

  def Solve(self):
    self.ReadData()
    self.WriteResponse()

if __name__ == '__main__':
    heap_builder = HeapBuilder()
    heap_builder.Solve()
