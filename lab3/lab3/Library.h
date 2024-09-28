#pragma once
#include <stdexcept>
class NumberOperations {

public:

	class invalid_argument_1 : public std::invalid_argument {
	public:
		invalid_argument_1(const char* s) : invalid_argument(s) { }
	};

	class invalid_argument_2 : public std::invalid_argument {
	public:
		invalid_argument_2(const char* s) : invalid_argument(s) { }
	};

	class invalid_argument_3 : public std::invalid_argument {
	public:
		invalid_argument_3(const char* s) : invalid_argument(s) { }
	};

	class invalid_argument_4 : public std::invalid_argument {
	public:
		invalid_argument_4(const char* s) : invalid_argument(s) { }
	};

	static int FindMax(int a, int b, int c);
	static int ExtractEvenDigitsReversed(int a);
	static int FindMinDigit(int a);
	static int SumOddBelowDiagonal(int** A, int n);
};