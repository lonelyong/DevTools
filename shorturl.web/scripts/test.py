import re
import sys
x = 1
y = 2
c = '3'
s = c * y
print(x+y)
print(c + s)
print((y + 1) // 1 % 2)
if x+y == 3:
    print("x+y=" + "3")
x = {1, 2, 3}
for i in x:
    print("i=%i" % (i))
else:
    print("for good bye!")
while y >= 1:
    print(y)
    y -= 1
else:
    print("while good bye")
for i in range(1, 10, 2):
    print(i)
arr = ["a", "b", "c"]
for i in range(len(arr)):
    print(arr[i])
lst = list(range(5))
print(lst)
print(range(5))
iter1 = iter(lst)
for var in iter1:
    print(var)
iter1 = iter(list(range(10)))
while True:
    try:
        print(next(iter1))
    except StopIteration:
        break


class IterClass:
    def __iter__(self):
        self.index = 1
        print(type(self))
        return self

    def __next__(self):
        if self.index <= 10:
            self.index += 1
            return self.index
        else:
            raise StopIteration


ic = IterClass()
iter1 = iter(ic)
for var in iter1:
    print(var)


def iterCreater(n):
    a, b, count = 0, 1, 0
    while True:
        if(count < n):
            yield a
            a, b, count = b, a+b, count+1
        else:
            break


xiter = iterCreater(10)
for var in xiter:
    print(var)
