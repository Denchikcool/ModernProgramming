#include "pch.h"
#include "CppUnitTest.h"

#include "../PNumber_(MPT5)/TPNumber.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace TPNumberTESTMPT
{
	TEST_CLASS(TPNumberTest)
	{
	public:
		TEST_METHOD(testDefaultConstructor)
		{
			// Arrange
			TPNumber number;
			double expectedNum = 1.0;
			int expectedBase = 10;
			int expectedPrecision = 1;

			// Act
			double num = number.getNumber();
			int base = number.getBase();
			int precision = number.getPrecision();

			// Assert
			Assert::AreEqual(expectedNum, num);
			Assert::AreEqual(expectedBase, base);
			Assert::AreEqual(expectedPrecision, precision);
		}

		TEST_METHOD(testConstructorWithValidValues)
		{
			// Arrange
			TPNumber number(25.5, 10, 3);
			double expectedNum = 25.5;
			int expectedBase = 10;
			int expectedPrecision = 3;

			// Act
			double num = number.getNumber();
			int base = number.getBase();
			int precision = number.getPrecision();

			// Assert
			Assert::AreEqual(expectedNum, num);
			Assert::AreEqual(expectedBase, base);
			Assert::AreEqual(expectedPrecision, precision);
		}

		TEST_METHOD(testConstructorWithInvalidValues)
		{
			// Arrange
			TPNumber number(25.5, 20, -1); // Неверная база и точность
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			double num = number.getNumber();
			int base = number.getBase();
			int precision = number.getPrecision();

			// Assert
			Assert::AreEqual(expectedNum, num);
			Assert::AreEqual(expectedBase, base);
			Assert::AreEqual(expectedPrecision, precision);
		}

		TEST_METHOD(testConstructorSTRWithValidValues)
		{
			// Arrange
			TPNumber number("25.5", "10", "3");
			double expectedNum = 25.5;
			int expectedBase = 10;
			int expectedPrecision = 3;

			// Act
			double num = number.getNumber();
			int base = number.getBase();
			int precision = number.getPrecision();

			// Assert
			Assert::AreEqual(expectedNum, num);
			Assert::AreEqual(expectedBase, base);
			Assert::AreEqual(expectedPrecision, precision);
		}

		TEST_METHOD(testCopy)
		{
			// Arrange
			TPNumber number(4.0, 10, 2);
			TPNumber expectedCopy = number;

			// Act
			TPNumber copy = number.copy();

			// Assert
			Assert::AreEqual(expectedCopy.getNumber(), copy.getNumber());
			Assert::AreEqual(expectedCopy.getBase(), copy.getBase());
			Assert::AreEqual(expectedCopy.getPrecision(), copy.getPrecision());
		}

		TEST_METHOD(testAddWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 10, 2);
			double expectedNum = 26.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1.add(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testAddWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1.add(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testMultWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(5, 2, 2);
			TPNumber num2(5, 2, 2);
			double expectedNum = 25.0;
			int expectedBase = 2;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1.mult(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testMultWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1.mult(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testSubtrWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 10, 2);
			double expectedNum = -5.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1.subtr(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testSubtrWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1.subtr(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testDivWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(5, 10, 2);
			TPNumber num2(5, 10, 2);
			double expectedNum = 1.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1.div(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testDivWithZeroDiv)
		{
			// Arrange
			TPNumber numerator(20.0, 10, 2);
			TPNumber denominator(0.0, 10, 2);

			// Act & Assert
			Assert::ExpectException<std::logic_error>([&]() { numerator.div(denominator); });
		}

		TEST_METHOD(testDivWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1.div(num2);

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testAddOPERWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 10, 2);
			double expectedNum = 26.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1 + num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testAddOPERWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1 + num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testMultOPERWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(5, 10, 2);
			TPNumber num2(5, 10, 2);
			double expectedNum = 25.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1 * num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testMultOPERWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1 * num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testSubtrOPERWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 10, 2);
			double expectedNum = -5.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1 - num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testSubtOPERrWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1 - num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testDivOPERWithEqualBaseAndPrecision)
		{
			// Arrange
			TPNumber num1(5, 10, 2);
			TPNumber num2(5, 10, 2);
			double expectedNum = 1.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = num1 / num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testDivOPERWithZeroDiv)
		{
			// Arrange
			TPNumber numerator(20.0, 10, 2);
			TPNumber denominator(0.0, 10, 2);

			// Act & Assert
			Assert::ExpectException<std::logic_error>([&]() { numerator / denominator; });
		}

		TEST_METHOD(testDivOPERWithDifferentBase)
		{
			// Arrange
			TPNumber num1(10.5, 10, 2);
			TPNumber num2(15.5, 2, 2);
			double expectedNum = 0.0;
			int expectedBase = 10;
			int expectedPrecision = 0;

			// Act
			TPNumber result = num1 / num2;

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testInverse)
		{
			// Arrange
			TPNumber number(4.0, 10, 2);
			double expectedNum = 0.25;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = number.inverse();

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(testSquare)
		{
			// Arrange
			TPNumber number(4.0, 10, 2);
			double expectedNum = 16.0;
			int expectedBase = 10;
			int expectedPrecision = 2;

			// Act
			TPNumber result = number.square();

			// Assert
			Assert::AreEqual(expectedNum, result.getNumber());
			Assert::AreEqual(expectedBase, result.getBase());
			Assert::AreEqual(expectedPrecision, result.getPrecision());
		}

		TEST_METHOD(GETNUM)
		{
			// Arrange
			TPNumber a(2.0, 10, 2);
			double expected = 2.0;

			// Act
			double result = a.getNumber();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETNUMST)
		{
			// Arrange
			TPNumber number(15, 16, 2);
			std::string expected = "F";

			// Act
			std::string result = number.getNumberString();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETNUMST_WithRightPartZeroBreak)
		{
			// Arrange
			TPNumber number(25.125, 10, 5);
			std::string expected = "25.125";

			// Act
			std::string result = number.getNumberString();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETNUMST_WithIntegerNumber)
		{
			// Arrange
			TPNumber number(25.0, 10, 5);
			std::string expected = "25";

			// Act
			std::string result = number.getNumberString();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETBASE_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			int expected = 16;

			// Act
			int result = a.getBase();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETBASESTR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			std::string expected = "16";

			// Act
			std::string result = a.getBaseString();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETPR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			int expected = 2;

			// Act
			int result = a.getPrecision();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(GETPRSTR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			std::string expected = "2";

			// Act
			std::string result = a.getPrecisionString();

			// Assert
			Assert::AreEqual(expected, result);
		}

		TEST_METHOD(SET_BASE_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			int expected = 5;

			// Act
			a.setBase(expected);

			// Assert
			Assert::AreEqual(expected, a.getBase());
		}

		TEST_METHOD(SET_BASE_STR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			std::string baseStr = "5";
			int expected = 5;

			// Act
			a.setBase(baseStr);

			// Assert
			Assert::AreEqual(expected, a.getBase());
		}

		TEST_METHOD(SET_PR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			int expected = 3;

			// Act
			a.setPrecision(expected);

			// Assert
			Assert::AreEqual(expected, a.getPrecision());
		}

		TEST_METHOD(SET_PR_STR_1)
		{
			// Arrange
			TPNumber a(10, 16, 2);
			std::string precisionStr = "3";
			int expected = 3;

			// Act
			a.setPrecision(precisionStr);

			// Assert
			Assert::AreEqual(expected, a.getPrecision());
		}
	};
}