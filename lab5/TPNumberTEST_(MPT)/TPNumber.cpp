#include "pch.h"
#include "../PNumber_(MPT5)/TPNumber.h"
#include <cmath>
#include <stdexcept>

using namespace std;

TPNumber::TPNumber() {
    this->number = 1.0;
    this->base = 10;
    this->currency = 1;
}

TPNumber::TPNumber(double a, int b, int c) {
    if (b >= 2 && b <= 16 && c >= 0) {
        this->number = a;
        this->base = b;
        this->currency = c;
    }
    else {
        this->number = 0.0;
        this->base = 10;
        this->currency = 0;
    }
}

TPNumber::TPNumber(string a, string b, string c) {
    double numberTemp = stod(a);
    int baseTemp = stoi(b);
    int precisionTemp = stoi(c);

    if (baseTemp >= 2 && baseTemp <= 16 && precisionTemp >= 0) {
        this->number = numberTemp;
        this->base = baseTemp;
        this->currency = precisionTemp;
    }
    else {
        this->number = 0.0;
        this->base = 10;
        this->currency = 0;
    }
}

TPNumber TPNumber::copy() {

    return { number, base, currency };
}

TPNumber TPNumber::add(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number + right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator+(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number + right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::mult(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number * right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator*(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number * right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::subtr(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number - right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator-(TPNumber right) {
    if (this->base == right.base && this->currency == right.currency) {
        return { this->number - right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::div(TPNumber right) {
    if (right.number == 0.0)
        throw std::logic_error("Division by zero");
    else if (this->base == right.base && this->currency == right.currency) {
        return { this->number / right.number, this->base, this->currency };
    }
    else return { 0.0, 10, 0 };
}

TPNumber TPNumber::operator/(TPNumber right) {
    if (right.number == 0.0)
        throw std::logic_error("Division by zero");
    else if (this->base == right.base && this->currency == right.currency) {
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

string TPNumber::getNumberString() {
    double tempNumber = fabs(this->number);
    int leftPart = (int)floor(tempNumber); // Целая часть числа
    double rightPart = tempNumber - floor(tempNumber); // Дробная часть числа
    string result;

    while (leftPart > 0) {
        int ost = leftPart % this->base;
        result.insert(0, 1, symbols[ost]);
        leftPart /= this->base;
    }

    if (result.empty()) result = "0";

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

TPNumber::~TPNumber() {}