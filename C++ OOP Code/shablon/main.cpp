#include <iostream>
#include "super_vector.h"
using namespace std;

int main()
{


	vector <int> a(5);
	vector <double> b(10);



	
	a.set_array_input();
	cout << a;
	b.print_vector();

	cin >> a;



}