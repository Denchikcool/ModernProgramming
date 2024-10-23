#pragma once
#include <string>

using namespace std;

const string symbols = "0123456789ABCDEF";

class TPNumber
{
private:
    double number;
    int base, currency;
public:
    TPNumber();
    ~TPNumber();
    TPNumber(double, int, int);
    TPNumber(string, string, string);
    double stringToNumber(const std::string& str, int base);
    string numberToString(double number, int base, int precision);

    TPNumber copy();
    TPNumber inverse();
    TPNumber square();

    TPNumber add(TPNumber);
    TPNumber operator+(TPNumber);
    TPNumber subtr(TPNumber);
    TPNumber operator-(TPNumber);
    TPNumber mult(TPNumber);
    TPNumber operator*(TPNumber);
    TPNumber div(TPNumber);
    TPNumber operator/(TPNumber);

    double getNumber();
    string getLeftPartString();
    string getRightPartString();
    string getNumberString();

    int getBase();
    string getBaseString();

    int getPrecision();
    string getPrecisionString();

    void setBase(int);
    void setBase(string);

    void setPrecision(int);
    void setPrecision(string);

    bool equal(TPNumber, TPNumber);
};