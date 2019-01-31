# python3
from collections import namedtuple

workers = namedtuple("workers",["index","time"])
class JobQueue:
    def read_data(self):
        self.num_workers, m = map(int, input().split())
        self.jobs = list(map(int, input().split()))
        assert m == len(self.jobs)

    def write_response(self):
        for i in range(len(self.jobs)):
          print(self.assigned_workers[i], self.start_times[i]) 

    def assign_jobs(self):
        w = []
        for i in range(self.num_workers):
            w.append([i,0])
        for i in self.jobs:
            print(w[0][0],w[0][1])
            w[0][1] += i
            self.changepriority(0,w)

    def changepriority(self,i,w):
        self.shiftdown(i,w)
        #for j in range(len(w)//2,-1,-1):
           # self.shift(j,w)
    
    def shift(self,i,w):
        min = i
        l,r = 2*i + 1, 2*i + 2
        if l < len(w)  and w[min][1] >= w[l][1]:
          if w[min][1] == w[l][1]:
              if w[min][0] > w[l][0]:
                min = l
          else:
              min = l
        if r < len(w) and w[min][1] >= w[r][1]:
          if w[min][1] == w[r][1]:
              if w[min][0] > w[r][0]:
                min = r
          else:
              min = r
        
        

        if min != i:
          w[i],w[min] = w[min],w[i]
          self.shift(min,w)

    def shiftdown(self,i, w):
      min = i
      l,r = 2*i + 1, 2*i + 2
      if l < len(w) and w[min][1] >= w[l][1]:
          if w[min][1] == w[l][1]:
              if w[min][0] > w[l][0]:
                min = l
          else:
              min = l
      if r < len(w) and w[min][1] >= w[r][1]:
          if w[min][1] == w[r][1]:
              if w[min][0] > w[r][0]:
                min = r
          else:
              min = r    
      if min != i:
          w[i],w[min] = w[min],w[i]
          self.shiftdown(min,w)
      

    def solve(self):
        self.read_data()
        self.assign_jobs()

if __name__ == '__main__':
    job_queue = JobQueue()
    job_queue.solve()

