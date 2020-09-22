#include <iostream>
#include "vector.h"
using namespace std;

int main()
{

	vector a;
	vector b(5);
	int aaa[4] = { 12,11,12,11 };
	int n = 3;
	vector c(b);
	//cansol_nemager_vector::print_vector(b);
	//cansol_nemager_vector::print_vector(c);
	//a = b;

	//cansol_nemager_vector::print_vector(a);
	cansol_nemager_vector::print_vector(a);
	cansol_nemager_vector::print_vector(b);

	cin >> a;
	//b.set_array_input(3);
	//a += b;
	//cansol_nemager_vector::print_vector(a);

	c = n + a;
	//-b;
	cout << c;

	cout << c[3] << endl;

	cin >> c[4];

	cout << c[4] << endl;

	c(4);
	cout << c;

	//cansol_nemager_vector::print_vector(b);

	//cansol_nemager_vector::print_vector(c);

	//c.set_array(4);

	//cansol_nemager_vector::print_vector(c);
	/*
	b.set_array();

	cansol_nemager_vector::print_vector(b);

	b.sort(1);

	cansol_nemager_vector::print_vector(b);

	cout << b.search(10) <<endl;

	cout << b.count_vector_in_array(10) << endl;

	//b.add_vector(12);*/

	//cansol_nemager_vector::print_vector(b);

	//b.add_vector(3, 25);

	//cansol_nemager_vector::print_vector(b);
	/*b.delete_vector(2);
	cansol_nemager_vector::print_vector(b);

	b.change_one_vector(1, 120);
	cansol_nemager_vector::print_vector(b);

	//b.copy_in(aaa);
	a.copy_from(aaa, 4);
	//for (size_t i = 0; i < b.get_size_array(); i++)
	//{
	//	cout << "array [ " << i << " ] = " << aaa[i] << endl;
	//}
	*/
	//cansol_nemager_vector::print_vector(a);
























}