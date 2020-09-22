#pragma once
#include <iostream>
using namespace std;
//const size_t size_x = 5;
//const size_t size_y = 5;


class matrix
{
private:
	size_t size_y;
	size_t size_x;
	int **pole;

	//void set_size_matrix(size_t _y, size_t _x);
public:
	//constructors--------------------------------------------
	matrix();
	matrix(size_t _y, size_t _x);
	matrix(matrix &_first);
	//destructor----------------------------------------------
	~matrix();
	//geters--------------------------------------------------
	size_t get_size_y() const { return size_y; }
	size_t get_size_x() const { return size_x; }

	int &get(size_t _y, size_t _x);
	int get(size_t _y, size_t _x) const;
	//seters--------------------------------------------------
	void set_size_matrix(size_t _y, size_t _x);
	//metods--------------------------------------------------
	void print() const;
	//peregruzka----------------------------------------------
	matrix operator=(matrix &_second);
	/*matrix operator()(matrix &_second);
	//matrix operator[](matrix &_second);*/

	matrix &operator+=(matrix &_second);
	matrix &operator-=(matrix &_second);
	matrix &operator*=(matrix &_second);
	


};

matrix operator+(matrix &_first, matrix &_second);
matrix operator-(matrix &_first, matrix &_second);
matrix operator*(matrix &_first, matrix &_second);




ostream &operator<<(ostream &os, const matrix _first);
istream &operator>>(istream &is, matrix &_first);



