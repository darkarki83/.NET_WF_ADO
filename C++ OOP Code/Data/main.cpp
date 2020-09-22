#define _CRT_SECURE_NO_WARNINGS
#include <string.h>
#include<iostream>
#include<string>
#include"Date.h"

using namespace std;

int main()
{
	Date proverca;
	const int size = 11;
	char temp[size];
	Date My(5, 3, 2);
	Date Parametr(25,05,2017);

	proverca = My + Parametr;
	proverca.PrintDate();
	
	if (My == Parametr)		
		cout << "true" << endl;
	else
		cout << "false" << endl;
	if (My > Parametr)
		cout << "true" << endl;
	else
		cout << "false" << endl;
	if (My < Parametr)
		cout << "true" << endl;
	else
		cout << "false" << endl;
	if (My != Parametr)
		cout << "true" << endl;
	else
		cout << "false" << endl;
	My -= Parametr;
	My.PrintDate();
	My += Parametr;
	My.PrintDate();

	strcpy(temp,Parametr.dey_of_week());
	cout << "today is : " << temp << endl;

	cout << My;
	cin >> My;
	cout << My;

	My(1, 2, 2020);

	cout << My;


}