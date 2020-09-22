#pragma once
#include <iostream>
using namespace std;
class m_srting
{
private:
	size_t size_str;
	char *array_chars;
	static int creat_object;
public:
	
	m_srting() : m_srting(80) {};   // �������������
	m_srting(size_t _size_str);
	m_srting(m_srting &str);

	~m_srting();
	// гетеры
	size_t get_size_str() const { return size_str; }
	char *get_array_chars(char *new_str) const;
	char &get(size_t index) { return array_chars[index]; }
	char &get(size_t index) const { return array_chars[index]; }
	static int get_creat_object() { return creat_object; }
	//сетеры
	void set_array_chars(const char *_array_chars);
	void set(size_t _size_str);


	char *search(char symbol) const;
	int search_get_index(char symbol) const;
	size_t count_symbol(char symbol) const;
	void add_symbol(size_t index, char symbol);
	char *delete_symbol(size_t index);
	void concotnation(size_t index, char *_string);
	char *copy_to(char *_array) const;
	void copy_from(char *_array, size_t _size);
	//bool equal_string(const char *_array) const; теперь перегрузка
	//void save_str_in_file();

	char *operator+(char *_array);

	m_srting &operator=(const m_srting &_str_first);
	char &operator[](const size_t index);
	m_srting &operator()(size_t _size_str);
	m_srting &operator()(const char *_str);
};

class string_consol_manager
{
private:
	m_srting &_str;
public:
	string_consol_manager(m_srting &str) : _str(str) {}
	void print() const;
	void input();
};


bool operator==(const m_srting &_str_first, const m_srting &_str_second);
bool operator!=(const m_srting &_str_first, const m_srting &_str_second);
bool operator>=(const m_srting &_str_first, const m_srting &_str_second);
bool operator<=(const m_srting &_str_first, const m_srting &_str_second);
bool operator>(const m_srting &_str_first, const m_srting &_str_second);
bool operator<(const m_srting &_str_first, const m_srting &_str_second);

ostream &operator<<(ostream &os,const m_srting &_str);
istream &operator>>(istream &is, m_srting &_str);
