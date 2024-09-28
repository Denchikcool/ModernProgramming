#include "pch.h"
#include "CppUnitTest.h"
#include "../lab3/Library.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace TestsLab3
{
	TEST_CLASS(TestsLab3)
	{
	public:
		
		TEST_METHOD(FindMax1)
		{
			NumberOperations numberOperations;
			//arrange
			int first = 52;
			int second = 0;
			int third = -87;
			int expected = 52;
			//act
			int actual = numberOperations.FindMax(first, second, third);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMax2)
		{
			NumberOperations numberOperations;
			//arrange
			int first = 0;
			int second = 52;
			int third = -87;
			int expected = 52;
			//act
			int actual = numberOperations.FindMax(first, second, third);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMax3)
		{
			NumberOperations numberOperations;
			//arrange
			int first = 0;
			int second = -87;
			int third = 52;
			int expected = 52;
			//act
			int actual = numberOperations.FindMax(first, second, third);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMax4)
		{
			NumberOperations numberOperations;
			//arrange
			int first = 0;
			int second = 0;
			int third = 0;
			int expected = 0;
			//act
			int actual = numberOperations.FindMax(first, second, third);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMax5)
		{
			NumberOperations numberOperations;
			//arrange
			int first = 52;
			int second = 52;
			int third = 52;
			int expected = 52;
			//act
			int actual = numberOperations.FindMax(first, second, third);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(ExtractEvenDigitsReversed1)
		{
			//arrange
			int a = -9467;
			//act
			auto func = [a] {
				NumberOperations numberOperations;
				numberOperations.ExtractEvenDigitsReversed(a);
				};
			//assert
			Assert::ExpectException<NumberOperations::invalid_argument_1>(func);
		}

		TEST_METHOD(ExtractEvenDigitsReversed2)
		{
			//arrange
			int a = 12345;
			int expected = 42;
			//act
			int actual = NumberOperations::ExtractEvenDigitsReversed(a);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMinDigit1)
		{
			//arrange
			int a = 62543;
			int expected = 2;
			//act
			int actual = NumberOperations::FindMinDigit(a);
			//assert
			Assert::AreEqual(expected, actual);
		}

		TEST_METHOD(FindMinDigit2)
		{
			//arrange
			int a = -62543;
			//act
			auto func = [a] {
				NumberOperations numberOperations;
				numberOperations.FindMinDigit(a);
				};
			//assert
			Assert::ExpectException<NumberOperations::invalid_argument_1>(func);
		}

		TEST_METHOD(SumOddBelowDiagonal1)
		{
			//arrange
			int n = 3;
			int** a = new int* [n];
			a[0] = new int[n] {1, 2, 3};
			a[1] = new int[n] {4, 5, 6};
			a[2] = new int[n] {7, 8, 9};
			int expected = 7;
			//act
			int actual = NumberOperations::SumOddBelowDiagonal(a, n);
			//assert
			Assert::AreEqual(expected, actual);
			delete[] a[0];
			delete[] a[1];
			delete[] a[2];
			delete[] a;
		}

		TEST_METHOD(SumOddBelowDiagonal2)
		{
			//arrange
			int n = 0;
			int** a = new int*[3];
			a[0] = new int[n];
			a[1] = new int[n];
			a[2] = new int[n];
			//act
			auto func = [a] {
				NumberOperations numberOperations;
				int size = 0;
				numberOperations.SumOddBelowDiagonal(a, size);
				};
			//assert
			Assert::ExpectException<NumberOperations::invalid_argument_2>(func);
			delete[] a[0];
			delete[] a[1];
			delete[] a[2];
			delete[] a;
		}

		TEST_METHOD(SumOddBelowDiagonal3)
		{
			//arrange
			int n = 3;
			int** a = new int* [n];
			a[0] = new int[n] {1, 2, 3};
			a[1] = nullptr;
			a[2] = new int[n] {4, 5, 6};
			//act
			auto func = [a] {
				NumberOperations numberOperations;
				numberOperations.SumOddBelowDiagonal(a, 3);
				};
			//assert
			Assert::ExpectException<NumberOperations::invalid_argument_3>(func);
			delete[] a[0];
			delete[] a[1];
			delete[] a[2];
			delete[] a;
		}
	};
}
