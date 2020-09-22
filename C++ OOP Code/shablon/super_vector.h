#pragma once
#include <iostream>
using namespace std;

template <typename T>
class vector
{
private:
	size_t size_array;
	T *array_vector;
public:
	//constructor-------------------------------------------------
	vector()
	{
		size_array = 0;
		array_vector = nullptr;
	}
	vector(size_t _size_array)
	{
		size_array = _size_array;
		array_vector = size_array > 0 ? new T[size_array] : nullptr;
	}
	vector(vector &v)
	{
		size_array = v.size_array;
		if (array_vector != nullptr)
			delete[] array_vector;
		array_vector = new T[size_array];
		for (size_t i = 0; i < size_array; i++)
		{
			array_vector[i] = v.array_vector[i];
		}
	}
	~vector()
	{
		delete[] array_vector;
	}
	//geters------------------------------------------------------
	size_t get_size_array() const { return size_array; }
	T &get(size_t index) { return array_vector[index]; }
	T &get(size_t index) const { return array_vector[index]; }
	//seters---------------------------------------------------------
	void set_array_input(size_t _size_array)
	{
		size_array = _size_array;
		T temp;
		if (array_vector != nullptr)
			delete[] array_vector;
		array_vector = new T[size_array];
		for (size_t i = 0; i < size_array; i++)  // ýòî íå îáÿçÿòåëüíî ýòî ÿ ñàì äîáàâèë 
		{
			cin >> temp;
			get(i) = temp;
		}
	}
	void set_array_input()
	{
		size_t _size_array;
		cout << "write new array size : ";
		cin >> _size_array;
		size_array = _size_array;
		array_vector = new T[size_array];
		for (size_t i = 0; i < size_array; i++)
		{
			array_vector[i] = input_element();
		}
	}
	void set_arrays(size_t _size_array)
	{
		size_array = _size_array;
		if (array_vector != nullptr)
			delete[] array_vector;
		array_vector = new T[size_array];
		for (size_t i = 0; i < size_array; i++)
		{
			array_vector[i] = 0;
		}
	}

	// методы для работы с вектором
	void sort(bool up_or_down)
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
							T temp = get(j - 1);
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
							T temp = get(j - 1);
							get(j - 1) = get(j);
							get(j) = temp;
						}
					}
				}
			}
		}
	}
	int search(T _value) const
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
	size_t count_value(T _value) const
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
	void add(T _value)
	{
		size_array++;
		T *temp = new T[get_size_array()];
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
	void add(size_t index, T _value)
	{
		size_t i;
		size_array++;
		T *temp = new T[get_size_array()];
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
	void delete_value_by_index(size_t index)
	{
		size_t i;
		size_array--;
		T *temp = new T[get_size_array()];
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
	void copy_to(T *_array) const
	{
		if (_array != nullptr)
			delete[] _array;

		_array = new T[get_size_array()];
		for (size_t i = 0; i < get_size_array(); i++)
		{
			_array[i] = get(i);
		}
	}
	void copy_from(T *_array, size_t _size)
	{
		if (array_vector != nullptr)
			delete[] array_vector;
		size_array = _size;
		array_vector = new T[size_array];
		for (size_t i = 0; i < get_size_array(); i++)
		{
			change_one_value(i, _array[i]);
		}
	}
	void change_one_value(size_t _index, T _value) { get(_index) = _value; }
	void print_vector()
	{
		if (get_size_array() > 0)
		{
			for (size_t i = 0; i < get_size_array(); i++)
				cout << "array vector [ " << i << " ] = " << get(i) << endl;
			cout << endl;
		}
		else
			cout << "wector is nullptr" << endl;
	}
	T input_element()
	{
		T element;
		cout << "write new element :";
		cin >> element;
		return element;
	}
	size_t input_size_array()
	{
		size_t _size_array;
		cout << "write new array size : ";
		cin >> _size_array;
		return _size_array;
	}
	// методы перегрузки операторов
	vector &operator=(const vector &_first) //работает
	{
		if (array_vector != nullptr)
			delete[] array_vector;
		size_array = _first.get_size_array();
		array_vector = new T[size_array];
		for (size_t i = 0; i < get_size_array(); i++)
		{
			get(i) = _first.get(i);
		}
		return *this;
	}
	vector &operator-()                    //работает
	{
		for (size_t i = 0; i < get_size_array(); i++)
		{
			get(i) = (get(i) * -1);
		}
		return *this;
	}
	vector operator+(int &_second) const           // работает
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
	vector &operator+=(const vector &_second)//работает
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
	vector &operator+=(int &_second)         //работает
	{
		vector _temp(*this);
		set_arrays(_temp.get_size_array() + 1);
		for (size_t i = 0; i < _temp.get_size_array(); i++)
			get(i) = _temp.get(i);
		get(_temp.get_size_array()) = _second;
		return *this;
	}

	const T &operator[](size_t index) const
	{
		return get(index);
	}
	T &operator[](size_t index)  //спрасить почему 
	{
		return get(index);
	}							 //вызывает всегда только этот
	vector &operator()(size_t _size)
	{
		set_arrays(_size);
		return *this;
	}
};



//vector operator+(const vector &_first, const vector  &_second);  // работает
//vector operator+(int &_first, const vector &_second);

//ostream &operator<<(ostream &os, const vector<int>::vector &_second);
//istream &operator>>(istream &is, vector &_second);

template <typename T> ostream &operator<<(ostream &os, const vector <T> &_second)
{
	for (size_t i = 0; i < _second.get_size_array(); i++)
	{
		os << "vector array [ " << i << " ] = " << _second.get(i) << endl;
	}
	return os;
}
template <typename T> istream &operator>>(istream &is, vector <T> &_second)
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


	

