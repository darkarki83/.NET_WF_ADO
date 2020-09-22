#include <iostream>
#include "var.h"
#include "str.h"
using namespace std;

var::var(size_t new_case)
{
	_case = new_case;
	if (_case == 1)
		_var.number = 0;
	else if (_case == 2)
		_var.real = 0;
	else if (_case == 3)
		_var.str = nullptr;
}



/*var::~var()
{
	if (_case == 3)
		_var.str->~m_srting();
}*/





void var::set_str(m_srting *_str)
{

	*_var.str = *_str;
}















var operator+(const var &_first, const var &_second)
{
	var temp;
	if (_first.get_case() == _second.get_case())
	{
		temp.set_case(_first.get_case());
		if (temp.get_case() == 1)
			temp.set_number(_first.get_number() + _second.get_number());
		else if (temp.get_case() == 2)
			temp.set_real(_first.get_real() + _second.get_real());
		else if (temp.get_case() == 3)
		{
			m_srting new_str(20);
			new_str = (*(_first.get_str()) + *(_second.get_str()));
			temp.set_str(&new_str);
		}
	}
	return temp;
}


ostream &operator<<(ostream &os, const var &_some_one)
{
	if (_some_one.get_case() == 1)
		os << _some_one.get_number() << endl;
	else if (_some_one.get_case() == 2)
		os << _some_one.get_real() << endl;
	else if (_some_one.get_case() == 3)
		os << *_some_one.get_str() << endl;
	return os;
}
istream &operator>>(istream &is, var &_some_one)
{
	cout << "write what do you want to input :";
	if (_some_one.get_case() == 1)
	{
		int temp;
		is >> temp;
		_some_one.set_number((int)temp);
	}
	else if (_some_one.get_case() == 2)
	{
		double temp;
		is >> temp;
		_some_one.set_real((double)temp);
	}
	else if (_some_one.get_case() == 3)
	{
		m_srting temp;
		is >> temp;
		_some_one.set_str((m_srting*)&temp);
	}
	return is;
}