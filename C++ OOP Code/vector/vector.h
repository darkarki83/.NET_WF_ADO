#pragma once
#include <iostream>
using namespace std;

class vector
{
private:
	size_t size_array;
	int *array_vector;
public:
	vector();
	vector(size_t _size_array);
	vector(vector &v);
	~vector();
	//ãåòåðû
	size_t get_size_array() const { return size_array; }
	//int *get_array_vector() { return array_vector; }// î÷åíü ïëîõî
	int &get(size_t index) {return array_vector[index];}
	int &get(size_t index) const { return array_vector[index]; }


	//ñåòåðû
	//void set_size_array(size_t _size_array) { size_array = _size_array; }
	void set_array_input(size_t _size_array);
	void set_arrays(size_t _size_array);
	void set_array_input();


	// методы для работы с вектором   (завтра разкидать по подкласам)
	void sort(bool up_or_down); 
	int search(int _value) const;
	size_t count_value(int _value) const;
	void add(int _value);
	void add(size_t index, int _value);
	void delete_value_by_index(size_t index);
	void copy_to(int *_array) const;
	void copy_from(int *_array, size_t _size);
	void change_one_value(size_t _index, int _value) { get(_index) = _value; }
	// методы перегрузки операторов
	vector &operator=(const vector &_first); //работает
	vector &operator-();                     //работает

	//vector operator-(int &_second) const;           // работает
	vector operator+(int &_second) const;           // работает
	vector &operator+=(const vector &_second);//работает
	vector &operator+=(int &_second);         //работает

	const int &operator[](size_t index) const;
	int &operator[](size_t index);  //спрасить почему 
	                                 //вызывает всегда только этот
	vector &operator()(size_t size);
};

class cansol_nemager_vector
{
public:
	static void print_vector(const vector &_vector);
	static int input_element();
	static size_t input_size_array();
};

vector operator+(const vector &_first, const vector &_second);  // работает
vector operator+(int &_first, const vector &_second);

ostream &operator<<(ostream &os, const vector &_second);
istream &operator>>(istream &is, vector &_second);



