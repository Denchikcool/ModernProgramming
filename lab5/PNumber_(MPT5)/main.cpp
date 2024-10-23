#include "TPNumber.h"
#include <iostream>
#include <Windows.h>

using namespace std;

int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    TPNumber firstNumber("1BC", "13", "5"); // Число 21 в восьмиричной системе с точностью 5 знаков
    TPNumber secondNumber("A1A", "13", "5"); // Число 31.4 в восьмиричной системе с точностью 5 знаков
    
    try {
        TPNumber num3(0, 10, 2);
    }
    catch (const std::invalid_argument& e) {
        std::cerr << "Ошибка: " << e.what() << std::endl;
        cout << "=============================================\n";
    }
    cout << "=============================================\n";
    cout << "firstNumber: " << firstNumber.getNumberString() << " (основание: " << firstNumber.getBaseString() << ", точность: " << firstNumber.getPrecisionString() << ")" << endl;
    cout << "secondNumber: " << secondNumber.getNumberString() << " (основание: " << secondNumber.getBaseString() << ", точность: " << secondNumber.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";

    TPNumber sum = firstNumber + secondNumber;
    cout << "Сумма: " << sum.getNumberString() << " (основание: " << sum.getBaseString() << ", точность: " << sum.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";
    TPNumber multiply = firstNumber * secondNumber;
    cout << "Произведение: " << multiply.getNumberString() << " (основание: " << multiply.getBaseString() << ", точность: " << multiply.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";
    TPNumber substring = firstNumber - secondNumber;
    cout << "Вычитание: " << substring.getNumberString() << " (основание: " << substring.getBaseString() << ", точность: " << substring.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";
    TPNumber del;
    try {
        del = firstNumber / secondNumber;
        cout << "Деление: " << del.getNumberString() << " (основание: " << del.getBaseString() << ", точность: " << del.getPrecisionString() << ")" << endl;
        cout << "=============================================\n";
    }
    catch (const logic_error& e) {
        cerr << "Error: " << e.what() << endl;
        cout << "=============================================\n";
    }

    TPNumber squared = firstNumber.square();
    cout << "Квадрат firstNumber: " << squared.getNumberString() << " (основание: " << squared.getBaseString() << ", точность: " << squared.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";
    squared.setBase(11);
    cout << "Новое основание у squared: " << squared.getNumberString() << " (основание: " << squared.getBaseString() << ", точность: " << squared.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";
    TPNumber squared1 = squared.copy();
    cout << "Копирование объекта squared: " << squared1.getNumberString() << " (основание: " << squared1.getBaseString() << ", точность: " << squared1.getPrecisionString() << ")" << endl;
    cout << "=============================================\n";

    TPNumber temp1 = squared1.inverse();
    cout << "Обратное число скопированного объекта squared: " << temp1.getNumberString() << " (основание: " << temp1.getBaseString() << ", точность: " << temp1.getPrecisionString() << ")" << endl;
    return 0;
}
