#include <iostream>
#include "str.h"
using namespace std;

int m_srting::creat_object;

int main()
{
	m_srting a;
	//m_srting b(10);
	//string_consol_manager manager3(b);
	//manager3.print();
	cin >> a;
   m_srting b;
	//cin >> b;
    b = a;
	
	cout << b;
	b(20);  // не очень работает
	a[5] = 'A';

	cout << a[5];
	cout << a;
	cout << b;

	b("arkadi\0");

	cout << b;
	/*m_srting c(b);
	
	string_consol_manager manager1(a);
	manager1.print();

	string_consol_manager manager2(b);
	manager2.print();

	string_consol_manager manager3(b);
	manager3.print();

	manager3.input();
	manager3.print();*/

	
	char artem[11] = { 'b','s','d','f','a','g','f','d','s','a','\0'};
	char new_aaa[5] = { 'a', 'a', 'x', 'g', '\0' };
	//b.set_array_chars(artem);
	//manager3.print();
	//b.concotnation(5, new_aaa);
	if (a > b)
		cout << " a > b" << endl;
	else
		cout << " a < b" << endl;
	if (a < b)
		cout << " a < b" << endl;
	else
		cout << " a > b" << endl;
	if (a >= b)
		cout << " a >= b" << endl;
	else
		cout << " a < b" << endl;
	if (a <= b)
		cout << " a <= b" << endl;
	else
		cout << " a > b" << endl;
	if (a == b)
		cout << " a == b" << endl;
	else
		cout << " a != b" << endl;
	if (a != b)
		cout << " a != b" << endl;
	else
		cout << " a == b" << endl;

	cout << b;
	//cout << b;
	//cin >> b;
	//cout << b;
	//manager3.print();
	//cout << "how many creating : " << m_srting::get_creat_object() << endl;
	//cout << b.search_in_string('a') << endl;

	//cout << b.search_in_string_index('a') << endl;

	//cout << b.count_symbol_in_array('a') << endl;
}