#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include "str.h"
using namespace std;

/*m_srting::m_srting() 
{
	size_str = 80;
	array_chars = new char[size_str];
}*/


m_srting::m_srting(size_t _size_str)
{
	creat_object++;
	size_str = _size_str;
	array_chars = new char[size_str];
}

m_srting::m_srting(m_srting &_str)
{
	creat_object++;
	size_str = _str.size_str;
	array_chars = new char[size_str];
	strcpy(array_chars, _str.array_chars);
}

m_srting::~m_srting()
{
	cout << "delete posmotret\n";
	delete[] array_chars;
}

char *m_srting::get_array_chars(char *new_str) const
{
	strcpy(new_str, array_chars);
	return new_str;
}
//сетеры-----------------------------------------------------------------------------------
void m_srting::set_array_chars(const char *_array_chars)
{
	size_str = strlen(_array_chars) + 1;
	if (array_chars != nullptr)
		delete[] array_chars;
	array_chars = new char[size_str];
	strcpy(array_chars, _array_chars);
}

void m_srting::set(size_t _size_str)
{
	if (array_chars != nullptr)
		delete[] array_chars;
	size_str = _size_str;
	array_chars = new char[size_str];
	get(size_str - 1) = '\0';
}

// всякие класные методы-------------------------------------------------------------------
char *m_srting::search(char symbol) const
{
	if (array_chars != nullptr)
		return strchr(array_chars, symbol);
	else
		return nullptr;
}

int m_srting::search_get_index(char symbol) const
{
	size_t i;
	for (i = 0; i < get_size_str(); i++)
	{
		if (get(i) == symbol)
			return (int)i;
	}
	if (i == get_size_str())
		return -1;
}

size_t m_srting::count_symbol(char symbol) const
{
	size_t count = 0;
	for (size_t i = 0; i < get_size_str(); i++)
	{
		if (get(i) == symbol)
			count++;
	}
	return count;
}

void m_srting::add_symbol(size_t index, char symbol)
{
	if (array_chars != nullptr)
	{
		size_t new_size = get_size_str() + 1;
		char *new_array = new char[new_size];
		for (size_t i = 0; i < index; i++)
		{
			new_array[i] = get(i);
		}
		new_array[index] = symbol;
		for (size_t i = index; i < new_size; i++)
		{
			new_array[i + 1] = get(i);
		}
		delete[] array_chars;
		size_str = new_size;
		array_chars = new_array;
	}
	else
	{
		if (!index)
		{
			size_str = 2;
			array_chars = new char[size_str];
			get(0) = symbol;
			get(1) = '\0';
		}
	}
}

char *m_srting::delete_symbol(size_t index)
{
	if (array_chars != nullptr)
	{
		size_t i;
		char *new_array = new char[get_size_str() - 1];
		for (i = 0; i < index; i++)
		{
			new_array[i] = get(i);
		}
		for (i = index; i < get_size_str() - 1; i++)
		{
			new_array[i] = get(i + 1);
		}
		delete[] array_chars;
		size_str--;
		return array_chars = new_array;
	}
	else
		return array_chars;
}

void m_srting::concotnation(size_t index, char *_string)
{
	size_t new_size = index + get_size_str() - 1;
	char *new_array = new char[new_size];
	strncpy(new_array, array_chars, get_size_str() - 1);
	new_array[get_size_str()] = '\0';
	strcat(new_array, _string);
	new_array[new_size - 1] = '\0';
	delete[] array_chars;
	size_str = new_size;
	array_chars = new_array;
}

char *m_srting::copy_to(char *_array) const
{
	if (array_chars != nullptr)
	{
		if (_array != nullptr)
			delete[] _array;
		_array = new char[get_size_str()];
		return strcpy(_array, array_chars);
	}
	else
	{
		return _array = nullptr;
	}
}

void m_srting::copy_from(char *_array, size_t _size)
{
	if (_array != nullptr)
	{
		if (array_chars != nullptr)
			delete[] array_chars;
		array_chars = new char[_size];
		strcpy(array_chars, _array);
	}
	else
	{
		size_str = 0;
		array_chars = nullptr;
	}
}

/*bool m_srting::equal_string(const char *_array) const
{
	return strcmp(array_chars, _array);
}*/

char *m_srting::operator+(char *_array)
{
	size_t index = strlen(_array);
	size_t new_size = index + get_size_str() - 1;
	char *new_array = new char[new_size];
	strncpy(new_array, array_chars, get_size_str() - 1);
	new_array[get_size_str()] = '\0';
	strcat(new_array, _array);
	new_array[new_size - 1] = '\0';
	delete[] array_chars;
	size_str = new_size;
	array_chars = new_array;
	return array_chars;
}

m_srting &m_srting::operator=(const m_srting &_str_first)
{
	if (this == &_str_first)
		return *this;
	char *tmp = new char[_str_first.get_size_str()];
	set_array_chars(_str_first.get_array_chars(tmp));
	delete[] tmp;
	return *this;
}

char &m_srting::operator[](const size_t index)
{
	return get(index);
}

m_srting &m_srting::operator()(size_t _size_str)
{
	set(_size_str);
	return *this;
}

m_srting &m_srting::operator()(const char *_str)
{
	set_array_chars(_str);
	return *this;
}

void string_consol_manager::print() const
{
    cout << "size of string = " << _str.get_size_str() << endl;
    for (size_t i = 0; i < _str.get_size_str(); i++)
    {
    	if (!i)
    		cout << "string :: ";
    	cout << _str.get(i);
    }
    cout << endl;
}

void string_consol_manager::input()
{
	size_t temp_size_str = 80;
	char *temp = new char[temp_size_str];
	cout << "write new string :";
	//cin.ignore();
	cin.getline(temp, 80);
	_str.set_array_chars(temp);
	delete[] temp;
}

bool operator==(const m_srting &_str_first, const m_srting &_str_second)
{
	bool temp = true;	
	if (_str_first.get_size_str() == _str_second.get_size_str())
	{
		for (size_t i = 0; i < _str_first.get_size_str(); i++)
		{
			if (_str_first.get(i) != _str_second.get(i))
			{
				temp = false;
				break;
			}
		}
	}
	else
	{
		temp = false;
	}
	return temp;
}
bool operator!=(const m_srting &_str_first, const m_srting &_str_second)
{
	if (!(_str_first == _str_second))
		return true;
	else
		return false;
}
bool operator>=(const m_srting &_str_first, const m_srting &_str_second)
{
	bool bigest;
	char *_first = new char[_str_first.get_size_str() + 1];
	char *_second = new char[_str_second.get_size_str() + 1];
	_str_first.get_array_chars(_first);
	_str_second.get_array_chars(_second);
	strcoll(_first, _second) >= 0 ? bigest = true : bigest = false;
	delete[] _first, _second;
	return bigest;
}
bool operator<=(const m_srting &_str_first, const m_srting &_str_second)
{
	bool bigest;
	char *_first = new char[_str_first.get_size_str() + 1];
	char *_second = new char[_str_second.get_size_str() + 1];
	_str_first.get_array_chars(_first);
	_str_second.get_array_chars(_second);
	strcoll(_first, _second) <= 0 ? bigest = true : bigest = false;
	delete[] _first, _second;
	return bigest;
}
bool operator>(const m_srting &_str_first, const m_srting &_str_second)
{
	bool bigest;
	char *_first = new char[_str_first.get_size_str() + 1];
	char *_second = new char[_str_second.get_size_str() + 1];
	_str_first.get_array_chars(_first);
	_str_second.get_array_chars(_second);
	strcoll(_first, _second) > 0 ? bigest = true : bigest = false;
	delete[] _first, _second;
	return bigest;
}
bool operator<(const m_srting &_str_first, const m_srting &_str_second)
{
	if (_str_first > _str_second)
		return false;
	else
		return true;
}

ostream &operator<<(ostream &os, const m_srting &_str)
{
	if (_str.get_size_str())
	{
		cout << "size of string = " << _str.get_size_str() << endl;
		for (size_t i = 0; i < _str.get_size_str(); i++)
		{
			if (!i)
				os << "string :: ";
			os << _str.get(i);
		}
		os << endl;
	}
	else
	{
		cout << "string = nullptr";
	}
	return os;
}
istream &operator>>(istream &is, m_srting &_str)
{
	size_t temp_size_str = 80;
	char *temp = new char[temp_size_str];
	cout << "write new string :";
	//cin.ignore();
	cin.getline(temp, 80);
	_str.set_array_chars(temp);
	delete[] temp;
	return is;
}