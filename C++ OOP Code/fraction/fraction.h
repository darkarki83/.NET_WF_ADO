#pragma once

class fraction
{
private:
	int numerator;
	int denominator;
public:
	// конструкторы ----------------------------------------------
	fraction();
	fraction(int _num, int _den);

	//гетеры ------------------------------------------------------
	int get_numerator() const { return numerator; }
	int get_denominator() const { return denominator; }

	// сетеры  ----------------------------------------------------
	void set_numerator(int _num);
	void set_denominator(int _den);
	void set(int _num, int _den);

	// разные хорошие методы  ----------------------------------------------------
	void print() const;
	void input();

	int get_int() const { return get_numerator() / get_denominator(); }
	double get_double() const { return (double)(get_numerator() / get_denominator()); }
	//методы перегрузка
	operator int() const { return get_int(); }
	operator double() const { return get_double(); }; // потом спрасить

	fraction &operator-();
	fraction operator+(const fraction &_second);
	fraction operator-(const fraction &_second);
	fraction operator*(const fraction &_second);
	fraction operator/(const fraction &_second);

	fraction operator+(int const _second);
	fraction operator-(int const _second);
	fraction operator*(int const _second);
	fraction operator/(int const _second);

	//все с помоцью метода  так как меняем левую переменую
	fraction &operator+=(const fraction &_second);
	fraction &operator-=(const fraction &_second);
	fraction &operator*=(const fraction &_second);
	fraction &operator/=(const fraction &_second);
	fraction &operator+=(int n);
	fraction &operator-=(int n);
	fraction &operator*=(int n);
	fraction &operator/=(int n);

	fraction &operator++();
	fraction &operator--(); // прификсный
	fraction operator++(int);
	fraction operator--(int); // прификсный


	const int &operator[](size_t index) const;
	void operator()(int _num, int _den);

};

inline const int &fraction::operator[](size_t index) const
{ return (index == 0 ? get_numerator() : get_denominator()); }
//глобальные функции  переорузка операций

fraction operator+(const fraction &_first, const fraction &_second);
fraction operator-(const fraction &_first, const fraction &_second);
fraction operator*(const fraction &_first, const fraction &_second);
fraction operator/(const fraction &_first, const fraction &_second);

fraction operator+(const fraction &_first, int const _second);
fraction operator-(const fraction &_first, int const _second);
fraction operator*(const fraction &_first, int const _second);
fraction operator/(const fraction &_first, int const _second);

fraction &operator-(fraction &_first);

bool operator==(const fraction &_first, const fraction &_second);
bool operator!=(const fraction &_first, const fraction &_second);
bool operator>=(const fraction &_first, const fraction &_second);
bool operator<=(const fraction &_first, const fraction &_second);
bool operator>(const fraction &_first, const fraction &_second);
bool operator<(const fraction &_first, const fraction &_second);


//ситуации когда это становиться так- эти ситуации 
//бинарные аперации первым аперандом является не наш класс
fraction operator+(int _first, const fraction &_second);
fraction operator-(int _first, const fraction &_second);
fraction operator*(int _first, const fraction &_second);
fraction operator/(int _first, const fraction &_second);

ostream &operator<<(ostream &os, const fraction &_second);
istream &operator>>(istream &is, fraction &_second);




