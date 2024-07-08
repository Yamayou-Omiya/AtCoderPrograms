#フィボナッチ数列を求める関数
def fib(n):
    a, b = 0, 1
    while b < n:
        print(b, end=' ')
        a, b = b, a+b
    print()
# フィボナッチ数列の第n項を求める関数
def fib_nth(n):
    if n <= 0:
        return 0
    elif n == 1:
        return 1
    else:
        a, b = 0, 1
        for _ in range(2, n):
            a, b = b, a + b
        return b

def main():
    print(fib_nth(100))

if __name__ == '__main__':
    main()