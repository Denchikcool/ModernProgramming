#include "TPNumber.h"

#include <cmath>
#include <stdexcept>

using namespace std;

TPNumber::TPNumber() {
    this->number = 1.0;
    this->base = 10;
    this->currency = 1;
}

TPNumber::TPNumber(double a, int b, int c) {
    if (a != 0 && b >= 2 && b <= 16 && c >= 0) {
        this->number = a;
        this->base = b;
        this->currency = c;
    }
    else {
        throw std::invalid_argument("Некорректные значения для создания объекта TPNumber: число равно 0, основание равно 10, а точность равна 0.");
    }
}

TPNumber::TPNumber(string a, string b, string c) {
    //double numberTemp = stod(a);
    int baseTemp = stoi(b);
    int precisionTemp = stoi(c);

    if (baseTemp >= 2 && baseTemp <= 16 && precisionTemp >= 0) {
        this->number = stringToNumber(a, baseTemp);
        this->base = baseTemp;
        this->currency = precisionTemp;
    }
    else {
        throw std::invalid_argument("Некорректные значения для создания объекта TPNumber: число равно 0, основание равно 10, а точность равна 0.");
    }
}

double TPNumber::stringToNumber(const std::string& str, int base) {
    double result = 0;
    int power = 0;
    for (int i = str.length() - 1; i >= 0; --i) {
        char digit = str[i];
        if (digit >= '0' && digit <= '9') {
            result += (digit - '0') * std::pow(base, power);
        }
        else if (digit >= 'A' && digit <= 'F') {
            result += (digit - 'A' + 10) * std::pow(base, power);
        }
        else {
            throw std::invalid_argument("Недопустимый символ в строке.");
        }
        power++;
    }
    return result;
}

// Метод для преобразования числа в строку с заданным основанием и точностью
string TPNumber::numberToString(double number, int base, int precision) {
    std::string result;
    if (number == 0) {
        return "0";
    }

    // Обработка целой части
    long long intPart = static_cast<long long>(number);
    while (intPart > 0) {
        int digit = intPart % base;
        if (digit < 10) {
            result = static_cast<char>(digit + '0') + result;
        }
        else {
            result = static_cast<char>(digit - 10 + 'A') + result;
        }
        intPart /= base;
    }

    // Обработка дробной части
    if (precision > 0) {
        result += '.';
        double fracPart = number - intPart;
        for (int i = 0; i < precision; ++i) {
            fracPart *= base;
            int digit = static_cast<int>(fracPart);
            if (digit < 10) {
                result += static_cast<char>(digit + '0');
            }
            else {
                result += static_cast<char>(digit - 10 + 'A');
            }
            fracPart -= digit;
        }
    }

    return result;
}


TPNumber TPNumber::copy() {

    return { number, base, currency };
}

TPNumber TPNumber::add(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number + right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator+(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number + right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::mult(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number * right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator*(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number * right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::subtr(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number - right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator-(TPNumber right) {
    if (equal(*this, right)) {
        return { this->number - right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::div(TPNumber right) {
    if (right.number == 0.0)
        throw std::logic_error("Division by zero");
    else if (equal(*this, right)) {
        return { this->number / right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator/(TPNumber right) {
    if (right.number == 0.0)
        throw std::logic_error("Division by zero");
    else if (equal(*this, right)) {
        return { this->number / right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::inverse() {
    return { 1 / this->number, this->base, this->currency };
}

TPNumber TPNumber::square() {
    return { this->number * this->number, this->base, this->currency };
}

double TPNumber::getNumber() {
    return this->number;
}

string TPNumber::getLeftPartString() {
    double tempNumber = fabs(this->number);
    int leftPart = (int)floor(tempNumber); // Целая часть числа
    string result;

    while (leftPart > 0) {
        int ost = leftPart % this->base;
        result.insert(0, 1, symbols[ost]);
        leftPart /= this->base;
    }

    if (result.empty()) result = "0";

    return result;
}

string TPNumber::getRightPartString() {
    double tempNumber = fabs(this->number);
    double rightPart = tempNumber - floor(tempNumber); // Дробная часть числа
    string result;

    if (rightPart == 0.0) return result;
    else {
        result.append(1, '.');
        for (int i = 1; i <= currency; i++) {
            rightPart *= base;
            result.append(1, symbols[(int)floor(rightPart)]);
            rightPart -= floor(rightPart);
            if (rightPart == 0.0) break;
        }
    }

    return result;
}

string TPNumber::getNumberString() {
    string result = getLeftPartString();
    string rightPart = getRightPartString();
    if (!rightPart.empty()) {
        result.append(rightPart);
    }
    if (this->number < 0) result = result = "-" + result;

    return result;
}

int TPNumber::getBase() {
    return this->base;
}

string TPNumber::getBaseString() {
    return to_string(this->base);
}

int TPNumber::getPrecision() {
    return this->currency;
}

string TPNumber::getPrecisionString() {
    return to_string(this->currency);
}

void TPNumber::setBase(int newBase) {
    if (newBase >= 2 && newBase <= 16) this->base = newBase;
}

void TPNumber::setBase(string stringBase) {
    int newBase = stoi(stringBase);
    if (newBase >= 2 && newBase <= 16) this->base = newBase;
}

void TPNumber::setPrecision(int newPrecision) {
    if (newPrecision >= 0) this->currency = newPrecision;
}

void TPNumber::setPrecision(string stringPrecision) {
    int newPrecision = stoi(stringPrecision);
    if (newPrecision >= 0) this->currency = newPrecision;
}


bool TPNumber::equal(TPNumber num1, TPNumber num2) {
    if (num1.base == num2.base && num1.currency == num2.currency) {
        return true;
    }
    return false;
}


TPNumber::~TPNumber() {}