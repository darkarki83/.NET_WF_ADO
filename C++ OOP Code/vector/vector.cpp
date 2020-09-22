#include <iostream>
#include "vector.h"
using namespace std;

//vector _temp;

// êîíñòðóêòîðû
vector::vector()
{
	size_array = 0;
	array_vector = nullptr;
}

vector::vector(size_t _size_array)
{
	size_array = _size_array;
	array_vector = size_array > 0 ? new int[size_array] {0} : nullptr;
}

vector::vector(vector &v)
{
	size_array = v.size_array;
	array_vector = new int[size_array];
	for (size_t i = 0; i < size_array; i++)
	{
		array_vector[i] = v.array_vector[i];
	}
}

vector::~vector()
{
	delete[] array_vector;
}

void vector::set_array_input(size_t _size_array)
{
	size_array = _size_array;
	if (array_vector != nullptr)
		delete[] array_vector;
	array_vector = new int[size_array];  
	for (size_t i = 0; i < size_array; i++)  // ýòî íå îáÿçÿòåëüíî ýòî ÿ ñàì äîáàâèë 
	{
		array_vector[i] = cansol_nemager_vector::input_element();
	}
}

void vector::set_array_input()
{
	size_array = cansol_nemager_vector::input_size_array();
	array_vector = new int[size_array];
	for (size_t i = 0; i < size_array; i++)
	{
		array_vector[i] = cansol_nemager_vector::input_element();
	}
}

void vector::set_arrays(size_t _size_array)
{
	size_array = _size_array;
	if (array_vector != nullptr)
		delete[] array_vector;
	array_vector = new int[size_array];
	for (size_t i = 0; i < size_array; i++)   
	{
		array_vector[i] = 0;
	}
}

void vector::sort(bool up_or_down)
{
	if (array_vector != nullptr)
	{
		if (!up_or_down)
		{
			for (size_t i = 0; i < get_size_array(); i++)
			{
				for (size_t j = get_size_array() - 1; j > i; j--)
				{
					if (get(j - 1) > get(j))
					{
						int temp = get(j - 1);
						get(j - 1) = get(j);
						get(j) = temp;
					}
				}
			}
		}
		else
		{
			for (size_t i = 0; i < get_size_array(); i++)
			{
				for (size_t j = get_size_array() - 1; j > i; j--)
				{
					if (get(j - 1) < get(j))
					{
						int temp = get(j - 1);
						get(j - 1) = get(j);
						get(j) = temp;
					}
				}
			}
		}
	}
}

int vector::search(int _value) const
{
	if (array_vector != nullptr)
	{
		size_t i;
		for (i = 0; i < get_size_array(); i++)
		{
			if (get(i) == _value)
			{
				return (int)i;
			}
		}
		if (i == get_size_array())
		{
			return -1;
		}
	}
	else
	{
		cout << "this array nullptr" << endl;
	}
}

size_t vector::count_value(int _value) const
{
	if (array_vector != nullptr)
	{
		size_t count = 0;
		for (size_t i = 0; i < get_size_array(); i++)
		{
			if (get(i) == _value)
			{
				count++;
			}
		}
		return count;
	}
	else
	{
		cout << "this array nullptr" << endl;
	}
}

void vector::add(int _value)
{
	size_array++;
	int *temp = new int[get_size_array()];
	if (array_vector != nullptr)
	{
		for (size_t i = 0; i < get_size_array() - 1; i++)
		{
			temp[i] = array_vector[i];
		}
		delete[] array_vector;
	}
	temp[get_size_array() - 1] = _value;
	array_vector = temp;
}

void vector::add(size_t index, int _value)
{
	size_t i;
	size_array++;
	int *temp = new int[get_size_array()];
	if (array_vector != nullptr)
	{
		for (i = 0; i < index; i++)
		{
			temp[i] = array_vector[i];
		}
		temp[index] = _value;
		for (i = index + 1; i < get_size_array(); i++)
		{
			temp[i] = array_vector[i - 1];
		}
		delete[] array_vector;
	}
	array_vector = temp;
}

void vector::delete_value_by_index(size_t index)
{
	size_t i;
	size_array--;
	int *temp = new int[get_size_array()];
	if (array_vector != nullptr)
	{
		for (i = 0; i < index; i++)
		{
			temp[i] = array_vector[i];
		}
		for (i = index; i < get_size_array(); i++)
		{
			temp[i] = array_vector[i + 1];
		}
		delete[] array_vector;
	}
	array_vector = temp;
}

void vector::copy_to(int *_array) const
{
	if (_array != nullptr)
		delete[] _array;
	
	_array = new int[get_size_array()];
	for (size_t i = 0; i < get_size_array(); i++)
	{
		_array[i] = get(i);
	}
}

void vector::copy_from(int *_array, size_t _size)
{
	if(array_vector != nullptr)
		delete[] array_vector;
	size_array = _size;
	array_vector = new int[size_array];
	for (size_t i = 0; i < get_size_array(); i++)
	{
		change_one_value(i, _array[i]);
	}
}

// методы перегрузки операторов-------------------------------------------------

vector &vector::operator=(const vector &_first)
{
	if (array_vector != nullptr)
		delete[] array_vector;
	size_array = _first.get_size_array();
	array_vector = new int[size_array];
	for (size_t i = 0; i < get_size_array(); i++)
	{
		get(i) = _first.get(i);
	}
	return *this;
}

vector &vector::operator-()
{
	for (size_t i = 0; i < get_size_array(); i++)
	{
		get(i) = (get(i) * -1);
	}
	return *this;
}

/*vector operator-(int &_second) const         // работает
{
	vector _temp;

	return _temp;
}*/

vector vector::operator+(int &_second) const
{
	vector _temp;
	_temp.set_arrays(get_size_array() + 1);
	for (size_t i = 0; i < get_size_array(); i++)
	{
		_temp.get(i) = get(i);
	}
	_temp.get(get_size_array()) = _second;
	return _temp;
}

vector &vector::operator+=(const vector &_second)
{
	vector _temp(*this);
	size_t i;
	if (_temp.get_size_array() != 0 && _second.get_size_array() != 0)
	{
		if (_temp.get_size_array() >= _second.get_size_array())
		{
			set_arrays(_temp.get_size_array());
			for (i = 0; i < _second.get_size_array(); i++)
			{
				get(i) = _temp.get(i) + _second.get(i);
			}
			for (i = _second.get_size_array(); i < _temp.get_size_array(); i++)
			{
				get(i) = _temp.get(i);
			}
		}
		else
		{
			set_arrays(_second.get_size_array());
			for (i = 0; i < _temp.get_size_array(); i++)
			{
				get(i) = _temp.get(i) + _second.get(i);
			}
			for (i = _temp.get_size_array(); i < _second.get_size_array(); i++)
			{
				get(i) = _second.get(i);
			}
		}
	}
	else
	{
		if (!_temp.get_size_array())
		{
			set_arrays(_second.get_size_array());
			for (i = 0; i < get_size_array(); i++)
			{
				get(i) = _second.get(i);
			}
		}
	}
	return *this;
}

vector &vector::operator+=(int &_second)
{
	vector _temp(*this);
	set_arrays(_temp.get_size_array() + 1);
	for (size_t i = 0; i < _temp.get_size_array(); i++)
		get(i) = _temp.get(i);
	get(_temp.get_size_array()) = _second;
	return *this;
}

const int &vector::operator[](size_t index) const
{
	return get(index);
}

int &vector::operator[](size_t index)
{
	//cout << "input new value in this vector";
	return get(index);
}

vector &vector::operator()(size_t _size)
{
	set_arrays(_size);
	return *this;
}



void cansol_nemager_vector::print_vector(const vector &_vector)
{
	if (_vector.get_size_array() > 0)
	{
		for (size_t i = 0; i < _vector.get_size_array(); i++)
			cout << "array vector [ " << i << " ] = " << _vector.get(i) << endl;
		cout << endl;
	}
	else
		cout << "wector is nullptr" << endl;
}

int cansol_nemager_vector::input_element()
{
	int element;
	cout << "write new element :";
	cin >> element;
	return element;
}

size_t cansol_nemager_vector::input_size_array()
{
	size_t _size_array;
	cout << "write new array size : ";
	cin >> _size_array;
	return _size_array;
}

vector operator+(const vector &_first, const vector &_second)
{
	vector _temp;
	size_t i;
	if (_first.get_size_array() >= _second.get_size_array())
	{
		_temp.set_arrays(_first.get_size_array());
		for (i = 0; i < _second.get_size_array(); i++)
		{
			_temp.get(i) = _first.get(i) + _second.get(i);
		}
		for (i = _second.get_size_array(); i < _first.get_size_array(); i++)
		{
			_temp.get(i) = _first.get(i);
		}
		//cansol_nemager_vector::print_vector(_temp);
		return _temp;
	}
	else
	{
		_temp.set_arrays(_second.get_size_array());
		for (i = 0; i < _first.get_size_array(); i++)
		{
			_temp.get(i) = _first.get(i) + _second.get(i);
		}
		for (i = _first.get_size_array(); i < _second.get_size_array(); i++)
		{
			_temp.get(i) = _second.get(i);
		}
		return _temp;
	}
}

vector operator+(int &_first, const vector &_second)
{
	vector _temp;
	_temp.set_arrays(_second.get_size_array() + 1);
	for (size_t i = 0; i < _second.get_size_array(); i++)
	{
		_temp.get(i) = _second.get(i);
	}
	_temp.get(_second.get_size_array()) = _first;
	return _temp;
}

ostream &operator<<(ostream &os, const vector &_second)
{
	for (size_t i = 0; i < _second.get_size_array(); i++)
	{
		os << "vector array [ " << i << " ] = " << _second.get(i) << endl;
	}
	return os;
}
istream &operator>>(istream &is, vector &_second)
{
	size_t size;
	int _value;
	cout << "write size : ";
	is >> size;
	_second.set_arrays(size);
	for (size_t i = 0; i < _second.get_size_array(); i++)
	{
		cout << "write value vector [ " << i << " ] : ";
		is >> _value;
		_second.get(i) = _value;
	}
	return is;
}
