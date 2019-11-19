// 变量赋值与表达式
pi = 3.1415926
r = 20
area = pi * r * r

// 函数定义与使用
fib = (uint n) {
    if(n == 1 || n == 2) return 1;
    return fib(n-1) + fib(n-2);
}
fib5 = fib(5)

// 函数库的使用
win = Window()
win.Title = "画板"
canvas = win.Canvas
paint = canvas.Paint
paint.Color = "#000"
canvas.Draw.Rect(0, 0, 20, 20)

win.Show

// 斐波那契数列
// 斐波那契数列第n个数
// 1 1 2 3 5 8 13
math.fib = (uint n) {
    if(n == 1 || n == 2) return 1;
    return fib(n-1) + fib(n-2);
}
fib(3)
math.fib(3)