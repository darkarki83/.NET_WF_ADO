#pragma once
#include <iostream>
#include "str.h"

union variable
{
	int number;
	double real;
	m_srting *str ;
};

class var
{
private:
	size_t _case;
	variable _var;
public:
	var() { _case = 3, _var.str = nullptr; }
	var(size_t new_case);
	var(int _number) { _case = 1, _var.number = _number; }
	var(double _real) { _case = 2, _var.real = _real;}
	var(m_srting *_str) { _case = 3, _var.str = _str; }
	//destructor------------------------------------------------------------------
	//~var();
	//geters----------------------------------------------------------------------
	int get_number() const { return _var.number; }
	double get_real() const { return _var.real; }
	m_srting *get_str() const { return _var.str; }

	int get_case() const { return _case; }
	//seters----------------------------------------------------------------------

	void set_number(int _number) { _var.number = _number; }
	void set_real(double _real) { _var.real = _real; }
	void set_str(m_srting *_str);
	void set_case(size_t new_case) { _case = new_case; }
	//metods----------------------------------------------------------------------





	// перегрузка------------------------------------------------------
	

};

var operator+(const var &_first, const var &_second);
ostream &operator<<(ostream &os, const var &_some_one);
istream &operator>>(istream &is, var &_some_one);