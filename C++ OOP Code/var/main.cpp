#include <iostream>
#include "str.h"
#include "var.h"
using namespace std;

int m_srting::creat_object;

int main()
{

	int a;
	double b;
	m_srting _str(20);
	_str.set_array_chars("artem");
	m_srting *p = &_str;
	var first(4);
	var second(3.2);
	var therth(p);

	cout << first;

	var four(p);
	var five(p);


	five = therth + four;

	cout << five;






}