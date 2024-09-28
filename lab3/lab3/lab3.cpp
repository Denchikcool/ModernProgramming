#include <iostream>
#include <Windows.h>
#include <ctime>
#include <cstdlib>
#include "Library.h"
using namespace std;

int NumberOperations::FindMax(int a, int b, int c) {

    if (a == b && b == c) return a;

    int max = a;

    if (b > max) {
        max = b;
    }
    if (c > max) {
        max = c;
    }
    return max;
}

int NumberOperations::ExtractEvenDigitsReversed(int a) {
    const char* s1 = "Число должно быть неотрицательно.";
    if (a < 0) {
        throw invalid_argument_1(s1);
    }

    int b = 0;
    int digit;

    while (a > 0) {
        digit = a % 10;
        if (digit % 2 == 0) {
            b = b * 10 + digit;
        }
        a /= 10;
    }
    return b;
}

int NumberOperations::FindMinDigit(int a) {
    const char* s1 = "Число должно быть неотрицательно.";
    if (a < 0) {
        throw invalid_argument_1(s1);
    }
    int min = 9;
    int digit;
    while (a > 0) {
        digit = a % 10;
        if (digit < min) {
            min = digit;
        }
        a /= 10;
    }
    return min;
}

int NumberOperations::SumOddBelowDiagonal(int** A, int n) {
    const char* s2 = "Матрица не может быть пустым.";
    const char* s4 = "Матрица должен быть квадратным.";

    if (A == nullptr || n == 0) {
        throw invalid_argument_2(s2);
    }

    for (int i = 1; i < n; i++) {
        if (A[i] == nullptr) {
            throw invalid_argument_3(s4);
        }
    }

    long sum = 0;

    for (int i = 1; i < n; i++) {
        for (int j = 0; j < i; j++) {
            if (A[i][j] % 2 != 0) {
                sum += A[i][j];
            }
        }
    }
    return sum;
}

int main()
{

    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    NumberOperations numberOperations = NumberOperations();
    int numbers[] = {3, -17, 8};
    int task1 = numberOperations.FindMax(numbers[0], numbers[1], numbers[2]);
    cout << "==========================Task 1==========================" << endl;
    cout << "Максимальное число из набора (" << numbers[0] << ", " << numbers[1] << ", " << numbers[2] << ")" << " = " << task1 << endl;
    cout << "==========================================================" << endl << endl;
    
    int a = 12345;
    int task2 = numberOperations.ExtractEvenDigitsReversed(a);
    cout << "==========================Task 2==========================" << endl;
    cout << "Исходное число a = " << a << endl;
    cout << "Число b, полученное путем склеивания четных цифр из числа a (" << a << "), следующих в обратном порядке = " << task2 << endl;
    cout << "==========================================================" << endl << endl;

    int r = 62543;
    int task3 = numberOperations.FindMinDigit(r);
    cout << "==========================Task 3==========================" << endl;
    cout << "Исходное число a = " << r << endl;
    cout << "Число r (минимальное значение из всех разрядов числа a = " << r << ") = " << task3 << endl;
    cout << "==========================================================" << endl << endl;

    srand(time(0));
    int n = rand() % 5 + 3;
    int** A = new int* [n];
    for (int i = 0; i < n; i++) {
        A[i] = new int[n];
        for (int j = 0; j < n; j++) {
            A[i][j] = rand() % 20;
        }
    }
    cout << "==========================Task 4==========================" << endl;
    cout << "Матрица A с размерностью n = " << n << ": " << endl << endl;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            cout << A[i][j] << " | ";
        }
        cout << endl;
    }

    int task4 = numberOperations.SumOddBelowDiagonal(A, n);

    cout << endl << "Сумма нечётных значений ниже диагонали = " << task4 << endl;
    cout << "==========================================================" << endl;
    return 0;
}