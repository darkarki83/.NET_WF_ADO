#pragma once
#include<iostream>
using namespace std;



class Date
{
	int year;
	int month;
	int day;

public:
	Date();
	Date(int y, int m, int d);

     //гетеры ------------------------------------------------------------

	int get_day() const { return day; } 
	int get_month() const { return month; }
	int get_year() const { return year; }
	//сетеры -------------------------------------------------------------
	int &set_day(int _day) { day = _day; return day; }
	int &set_month(int _month) { month = _month; return month; }
	int &set_year(int _year) { year = _year; return year; }
	Date &sat_date(Date _my);
	Date &sat_date(int _day, int _month, int _year);

	// разные методы------------------------------------------------------
	char *dey_of_week() const;
	int all_in_days(int year, int month, int day) const;
	int which_month_in_day(int month) const;
	Date days_in_date(int _days) const;
     
	// перегрузка---------------------------------------------------------
	Date operator-(const Date &d) const;
	Date operator+(const Date &d) const;
	Date &operator-=(const Date &d);
	Date &operator+=(const Date &d);

	Date &operator++();
	Date &operator--();
	const Date operator++(int);  // спросить почему константый
	const Date operator--(int);

	bool operator==(const Date& d);
	bool operator > (const Date& d);
	bool operator < (const Date& d);
	bool operator !=(const Date& d);
	
	Date &operator()(int _year, int _month, int _day);

	void PrintDate();
};

ostream &operator<<(ostream &os, const Date &d);
istream &operator>>(istream &is,Date &d);

