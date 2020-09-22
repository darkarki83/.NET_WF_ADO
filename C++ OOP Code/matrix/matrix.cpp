#include <iostream>
#include "matrix.h"
using namespace std;

//constructors--------------------------------------------
matrix::matrix()
{
	size_y = 3;
	size_x = 5;
	pole = new int*[size_y];
	for (size_t i = 0; i < size_y; i++)
	{
		pole[i] = new int[size_x] {0};
	}
}

matrix::matrix(size_t _y, size_t _x)
{
	size_y = _y;
	size_x = _x;
	pole = new int*[size_y];
	for (size_t i = 0; i < size_y; i++)
		pole[i] = new int[size_x] {0};
}

matrix::matrix(matrix &_first)
{
	size_y = _first.size_y;
	size_x = _first.size_x;
	pole = new int*[size_y];
	for (size_t i = 0; i < size_y; i++)
	{
		pole[i] = new int[size_x] {0};
		for (size_t j = 0; j < size_x; j++)
		{
			get(i, j) = _first.get(i, j);
		}
	}
}
//destructor----------------------------------------------
matrix::~matrix()
{
	for (size_t i = 0; i < size_y; i++)
		delete[] pole[i];
	delete[] pole;
	cout << "delete posmotret" << endl;
}
//geters--------------------------------------------------
int &matrix::get(size_t const _y, size_t const _x)
{
	//cout << pole[_y][_x] << endl;
	return pole[_y][_x];
}

int matrix::get(size_t const _y, size_t const _x) const
{
	return pole[_y][_x];
}
//seters--------------------------------------------------
void matrix::set_size_matrix(size_t _y, size_t _x)
{
	size_y = _y;
	size_x = _x;
	if (*pole != nullptr)
	{
		for (size_t i = 0; i < size_y; i++)
			delete[] pole[i];
		delete[] pole;
	}
	pole = new int*[size_y];
	for (size_t i = 0; i < size_y; i++)
	{
		pole[i] = new int[size_x] {0};
	}
}
//metods--------------------------------------------------
void matrix::print() const
{
	for (size_t i = 0; i < size_y; i++)
	{
		for (size_t j = 0; j < size_x; j++)
		{
			cout << get(i,j) << ' ' ;
		}
		cout << endl;
	}
}
//peregruzka----------------------------------------------
matrix matrix::operator=(matrix &_second)
{
	if (this == &_second)
		return *this;
	size_t _y, _x;
	_y = _second.get_size_y();
	_x = _second.get_size_x();
	set_size_matrix(_y, _x);
	for (size_t i = 0; i < size_y; i++)
	{
		for (size_t j = 0; j < size_x; j++)
		{
			get(i, j) = _second.get(i, j);
		}
	}
	return *this;
}

/*matrix matrix::operator()(matrix &_second)
{

}
matrix matrix::operator[](matrix &_second)
{

}*/

matrix &matrix::operator+=(matrix &_second)
{
	if ((get_size_y() >= _second.get_size_y()) && (get_size_x() >= _second.get_size_x()))
	{
		for (size_t i = 0; i < _second.get_size_y(); i++)
		{
			for (size_t j = 0; j < _second.get_size_x(); j++)
			{

				get(i, j) += _second.get(i, j);
			}
		}
	}
	else
	{
		cout << "could not have plus this matrix " << endl;
	}
	return *this;
}

matrix &matrix::operator-=(matrix &_second)
{
	if ((get_size_y() >= _second.get_size_y()) && (get_size_x() >= _second.get_size_x()))
	{
		for (size_t i = 0; i < _second.get_size_y(); i++)
		{
			for (size_t j = 0; j < _second.get_size_x(); j++)
			{

				get(i, j) -= _second.get(i, j);
			}
		}
	}
	else
	{
		cout << "could not have minus this matrix " << endl;
	}
	return *this;
}

matrix &matrix::operator*=(matrix &_second)
{
	matrix temp(get_size_y(), get_size_x());
	temp += _second;
	if (get_size_x() >= _second.get_size_y())
	{
		for (size_t i = 0; i < _second.get_size_y(); i++)
		{
			for (size_t j = 0; j < _second.get_size_x(); j++)
			{

				get(i, j) -= _second.get(i, j);
			}
		}
	}
	else
	{
		cout << "could not have minus this matrix " << endl;
	}
	return *this;
}
/*
matrix &matrix::operator/=(matrix &_second)
{

}*/
//function-----------------------------------------------------------
ostream &operator<<(ostream &os, const matrix _first)
{
	for (size_t i = 0; i < _first.get_size_y(); i++)
	{
		for (size_t j = 0; j < _first.get_size_x(); j++)
		{
			os << _first.get(i, j) << ' ';
		}
		cout << endl;
	}
	return os;
}

matrix operator+(matrix &_first, matrix &_second)
{
	matrix temp(_first);
	if ((_first.get_size_y() >= _second.get_size_y()) && (_first.get_size_x() >= _second.get_size_x()))
	{
		for (size_t i = 0; i < _second.get_size_y(); i++)
		{
			for (size_t j = 0; j < _second.get_size_x(); j++)
			{

				temp.get(i, j) +=_second.get(i, j);
			}
		}
	}
	else
	{
		cout << "could not have plus this matrix " << endl;
	}
	return temp;
}

matrix operator-(matrix &_first, matrix &_second)
{
	matrix temp(_first);
	if ((_first.get_size_y() >= _second.get_size_y()) && (_first.get_size_x() >= _second.get_size_x()))
	{
		for (size_t i = 0; i < _second.get_size_y(); i++)
		{
			for (size_t j = 0; j < _second.get_size_x(); j++)
			{

				temp.get(i, j) -= _second.get(i, j);
			}
		}
	}
	else
	{
		cout << "could not have minus this matrix " << endl;
	}
	return temp;
}
/*
matrix operator*(matrix &_first, matrix &_second)
{

}
matrix operator/(matrix &_first, matrix &_second)
{

}*/

istream &operator>>(istream &is, matrix &_first)
{
	size_t _y, _x;
	cout << "write size array y :";
	is >> _y;
	cout << "write size array x :";
	is >> _x;
	_first.set_size_matrix(_y, _x);
	for (size_t i = 0; i < _first.get_size_y(); i++)
	{
		for (size_t j = 0; j < _first.get_size_x(); j++)
		{
			int temp;
			cout << "[ " << i << " ] [ " << j << " ] : ";
			is >> temp;
			_first.get(i, j) = temp;
		}
		cout << endl;
	}
	return is;
}
