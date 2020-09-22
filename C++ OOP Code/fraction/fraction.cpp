#include <iostream>
#include "fraction.h"
using namespace std;


// конструкторы ---------------------------------------
fraction::fraction()
{
	numerator = 0;
	denominator = 1;
}

fraction::fraction(int _num, int _den)
{
	numerator = _num;

	if (_den)
		denominator = _den;
	else
		cout << "wrong input, try again" << endl;
}
// сетеры ---------------------------------------------
void fraction::set_numerator(int _num)
{
	numerator = _num;
}

void fraction::set_denominator(int _den)
{
	if (_den)
		denominator = _den;
	else
		cout << "wrong input, try again" << endl;
}

void fraction::set(int _num, int _den)
{
	set_numerator(_num);
	set_denominator(_den);
}

// разные хорошие методы  ----------------------------------------------------

void fraction::print() const
{
	cout << get_numerator() << '/' << get_denominator() << endl;
}

void fraction::input()
{
	int _num, _den;

	cout << "write numerator :";
	cin >> _num;
	set_numerator(_num);
	do
	{
		cout << "write denominator :";
		cin >> _den;
	} while (!_den);
	denominator = _den;
}

//методы перегрузка

fraction &fraction::operator-()
{
	set_numerator(-get_numerator());
	return *this;
}
fraction fraction::operator+(const fraction &_second)
{
	return fraction(get_numerator() * _second.get_denominator()
		+ _second.get_numerator() * get_denominator(),
		get_denominator() * _second.get_denominator());
}
fraction fraction::operator-(const fraction &_second)
{
	return fraction(get_numerator() * _second.get_denominator()
		- _second.get_numerator() * get_denominator(),
		get_denominator() * _second.get_denominator());
}
fraction fraction::operator*(const fraction &_second)
{
	return fraction(get_numerator() * _second.get_numerator(),
		get_denominator() * _second.get_denominator());
}
fraction fraction::operator/(const fraction &_second)
{
	return fraction(get_numerator() * _second.get_denominator(),
		get_denominator() * _second.get_numerator());
}

fraction fraction::operator+(int const _second)
{
	return fraction(get_numerator() + _second * get_denominator(),
		            get_denominator());
}
fraction fraction::operator-(int const _second)
{
	return fraction(get_numerator() - _second * get_denominator(),
                    get_denominator());
}
fraction fraction::operator*(int const _second)
{
	return fraction(get_numerator() * _second, get_denominator());
}
fraction fraction::operator/(int const _second)
{
	return fraction(get_numerator(), get_denominator() * _second);
}

fraction &fraction::operator+=(const fraction &_second)
{
	set_numerator(get_numerator() * _second.get_denominator()
		+ _second.get_numerator() * get_denominator());
	set_denominator(get_denominator() * _second.get_denominator());
	return *this;
}
fraction &fraction::operator-=(const fraction &_second)
{
	set_numerator(get_numerator() * _second.get_denominator()
		- _second.get_numerator() * get_denominator());
	set_denominator(get_denominator() * _second.get_denominator());
	return *this;
}
fraction &fraction::operator*=(const fraction &_second)
{
	set_numerator(get_numerator() * _second.get_denominator());
	set_denominator(get_denominator() * _second.get_numerator());
	return *this;
}
fraction &fraction::operator/=(const fraction &_second)
{
	set_numerator(get_numerator() * _second.get_numerator());
	set_denominator(get_denominator() * _second.get_denominator());
	return *this;
}
fraction &fraction::operator+=(int n)
{
	set_numerator(get_numerator() + n * get_denominator());
	set_denominator(get_denominator());
	return *this;
}
fraction &fraction::operator-=(int n)
{
	set_numerator(get_numerator() - n * get_denominator());
	set_denominator(get_denominator());
	return *this;
}
fraction &fraction::operator*=(int n)
{
	set_numerator(get_numerator() * n);
	set_denominator(get_denominator());
	return *this;
}
fraction &fraction::operator/=(int n)
{
	set_numerator(get_numerator());
	set_denominator(n * get_denominator());
	return *this;
}

fraction &fraction::operator++()
{
	set_numerator(get_numerator() + get_denominator());
	return *this;
}
fraction &fraction::operator--()
{
	set_numerator(get_numerator() - get_denominator());
	return *this;
}
fraction fraction::operator++(int)
{
	fraction temp = *this;
	set_numerator(get_numerator() + get_denominator());
	return temp;
}
fraction fraction::operator--(int)
{
	fraction temp = *this;
	set_numerator(get_numerator() - get_denominator());
	return temp;
}

void fraction::operator()(int _num, int _den)
{
	set(_num, _den);
}


//глобальные функции  перегрузка операций

fraction operator+(const fraction &_first, const fraction &_second)
{
	return fraction(_first.get_numerator() * _second.get_denominator()
		+ _second.get_numerator() * _first.get_denominator(),
		_first.get_denominator() * _second.get_denominator());
}
fraction operator-(const fraction &_first, const fraction &_second)
{
	return fraction(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator(),
		_first.get_denominator() * _second.get_denominator());
}
fraction operator*(const fraction &_first, const fraction &_second)
{
	return fraction(_first.get_numerator() * _second.get_numerator(),
		_first.get_denominator() * _second.get_denominator());
}
fraction operator/(const fraction &_first, const fraction &_second)
{
	return fraction(_first.get_numerator() * _second.get_denominator(),
		_first.get_denominator() * _second.get_numerator());
}

fraction operator+(const fraction &_first, int const _second)
{
	return fraction(_first.get_numerator() + _second * _first.get_denominator(),
		_first.get_denominator());
}
fraction operator-(const fraction &_first, int const _second)
{
	return fraction(_first.get_numerator() - _second * _first.get_denominator(),
		_first.get_denominator());
}
fraction operator*(const fraction &_first, int const _second)
{
	return fraction(_first.get_numerator() * _second,
		_first.get_denominator());
}
fraction operator/(const fraction &_first, int const _second)
{
	return fraction(_first.get_numerator(),
		_first.get_denominator() * _second);
}

fraction &operator-(fraction &_first)
{
	_first.set_numerator(-_first.get_numerator());
	return _first;
}

bool operator==(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator() 
		- _second.get_numerator() * _first.get_denominator() == 0);
}
bool operator!=(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator() != 0);
}
bool operator>=(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator() >= 0);
}
bool operator<=(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator() <= 0);
}
bool operator>(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator() > 0);
}
bool operator<(const fraction &_first, const fraction &_second)
{
	return(_first.get_numerator() * _second.get_denominator()
		- _second.get_numerator() * _first.get_denominator() < 0);
}

//ситуации когда это становиться так- эти ситуации 
//бинарные аперации первым аперандом является не наш класс
fraction operator+(int _first, const fraction &_second)
{
	return (_second + _first);
}
fraction operator-(int _first, const fraction &_second)
{
	return (_second - _first);
}
fraction operator*(int _first, const fraction &_second)
{
	return (_second * _first);
}
fraction operator/(int _first, const fraction &_second)
{
	return (_second / _first);
}

ostream &operator<<(ostream &os, const fraction &_second)
{
	os << _second.get_numerator() << '/' << _second.get_denominator() << endl;
	return os;
}
istream &operator>>(istream &is, fraction &_second)
{
	int num, den;
	cout << "write numerator :";
	is >> num;
	cout << "write denominator :";
	is >> den;
	_second.set_numerator(num);
	_second.set_denominator(den);
	return is;
}

