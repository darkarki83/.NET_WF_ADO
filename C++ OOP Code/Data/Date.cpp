#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <string.h>
#include<iostream>
#include"Date.h"

using namespace std;

Date::Date()
{
	year = 0;
	month = 0;
	day = 0;
}

Date::Date(int d, int m, int y)
{
	year = y;
	month = m;
	day = d;

}
//сетеры -------------------------------------------------------------
Date &Date::sat_date(Date _my)
{
	set_day(_my.get_day());
	set_month(_my.get_month());
	set_year(_my.get_year());
	return *this;
}

Date &Date::sat_date(int _day, int _month, int _year)
{
	set_day(_day);
	set_month(_month);
	set_year(_year);
	return *this;
}

// разные методы------------------------------------------------------
char *Date::dey_of_week() const
{
	const int size = 11;
	char temp[size];

	int d = all_in_days(get_year(), get_month(), get_day());
	switch (d % 7)
	{
	case 1:
		strcpy(temp, "monday\0");
		break;
	case 2:
		strcpy(temp, "tuesday\0");
		break;
	case 3:
		strcpy(temp, "wednesday\0");
		break;
	case 4:
		strcpy(temp, "thursday\0");
		break;
	case 5:
		strcpy(temp, "friday\0");
		break;
	case 6:
		strcpy(temp, "saturday\0");
		break;
	case 7:
		strcpy(temp, "sunday\0");
		break;
	}
	return temp;
}

int Date::all_in_days(int y, int m, int d) const
{
	int all_days = 0;
	all_days = (y * 365) + (y / 4) + (which_month_in_day(m)) + d;
	return all_days;
}

int Date::which_month_in_day(int month) const
{
	int days_in_month = 0;
	switch (month)
	{
	case 2:
		days_in_month += 31;
		break;
	case 3:
		days_in_month = 31 + 28;
		break;
	case 4:
		days_in_month = 31 + 28 + 31;
		break;
	case 5:
		days_in_month = 31 + 28 + 31 + 30;
		break;
	case 6:
		days_in_month = 31 + 28 + 31 + 30 + 31;
		break;
	case 7:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30;
		break;
	case 8:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30 + 31;
		break;
	case 9:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31;
		break;
	case 10:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30;
		break;
	case 11:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31;
	case 12:
		days_in_month = 31 + 28 + 31 + 30 + 31 + 30 + 31 + 31 + 30 + 31 + 30;
		break;
	}
	return days_in_month;
}

Date Date::days_in_date(int _days) const
{
	Date temp;
	temp.set_year(_days / 365);
	

	while ((temp.get_year() * 365) + (temp.get_year() / 4) > _days)
	{
		temp.set_year(temp.get_year() - 1);
	}
	_days = _days - (temp.get_year() * 365) - (temp.get_year() / 4);
	if (_days <= 31)
	{
		temp.set_month(1);
	}
	if (_days > 31 && _days <= 59)
	{
		temp.set_month(2);
		_days -= 31;
	}
	if (_days > 59 && _days <= 90)
	{
		_days -= 59;
		temp.set_month(3);

	}
	if (_days > 90 && _days <= 120)
	{
		_days -= 90;
		temp.set_month(4);
	}
	if (_days > 120 && _days <= 151)
	{
		_days -= 120;
		temp.set_month(5);
	}
	if (_days > 151 && _days <= 181)
	{
		_days -= 151;
		temp.set_month(6);
	}
	if (_days > 181 && _days <= 212)
	{
		_days -= 181;
		temp.set_month(7);
	}
	if (_days > 212 && _days <= 243)
	{
		_days -= 212;
		temp.set_month(8);
	}
	if (_days > 243 && _days <= 273)
	{
		_days -= 243;
		temp.set_month(9);
	}
	if (_days > 273 && _days <= 304)
	{
		_days -= 273;
		temp.set_month(10);
	}
	if (_days > 304 && _days <= 334)
	{
		_days -= 304;
		temp.set_month(11);
	}
	if (_days > 334 && _days <= 365)
	{
		_days -= 334;
		temp.set_month(12);
	}
	temp.set_day(_days);
	return temp;
}

// перегрузка---------------------------------------------------------
Date Date::operator-(const Date &d) const
{
	int _days;
	_days = all_in_days(get_year(), get_month(), get_day())
		- all_in_days(d.get_year(), d.get_month(), d.get_day());
	if (_days > 0)
	{
		return days_in_date(_days);
	}
	else
	{
		cout << "secund date big first date !!!" << endl;
		return days_in_date(-_days);
	}
}

Date Date::operator+(const Date &d) const
{
	return days_in_date(all_in_days(get_year(), get_month(), get_day())
		+ all_in_days(d.get_year(), d.get_month(), d.get_day()));
}

Date &Date::operator-=(const Date &d)
{
	int _days = all_in_days(get_year(), get_month(), get_day())
		- all_in_days(d.get_year(), d.get_month(), d.get_day());
	if (_days > 0)
		sat_date(days_in_date(_days));
	else
	{
		cout << "secund date big first date !!!" << endl;
		sat_date(days_in_date(-_days));
	}
	return *this;
}

Date &Date::operator+=(const Date &d)
{
	sat_date(days_in_date(all_in_days(get_year(), get_month(), get_day())
		+ all_in_days(d.get_year(), d.get_month(), d.get_day())));
	return *this;
}

Date &Date::operator++()
{
	set_day(get_day() + 1);
	return *this;
}

Date &Date::operator--()
{
	set_day(get_day() - 1);
	return *this;
}

const Date Date::operator++(int)
{
	Date temp = *this;
	set_day(temp.get_day() + 1);
	return temp;
}

const Date Date::operator--(int)
{
	Date temp = *this;
	set_day(temp.get_day() - 1);
	return temp;
}

bool Date::operator==(const Date & d)
{
	return (all_in_days(get_year(), get_month(), get_day())
		- all_in_days(d.get_year(), d.get_month(), d.get_day()) == 0);
}

bool Date::operator>(const Date & d)
{
	return (all_in_days(get_year(), get_month(), get_day())
		    > all_in_days(d.get_year(), d.get_month(), d.get_day()));
}

bool Date::operator<(const Date & d)
{
		return(all_in_days(get_year(), get_month(), get_day())
               < all_in_days(d.get_year(), d.get_month(), d.get_day()));
}

bool Date::operator!=(const Date & d)
{
	return (all_in_days(get_year(), get_month(), get_day())
		- all_in_days(d.get_year(), d.get_month(), d.get_day()) != 0);
}

Date &Date::operator()(int _day, int _month, int _year)
{
	sat_date(_day, _month, _year);
	return *this;
}


void Date::PrintDate()
{
	cout << "day: " << day << " " << "month: " << month << ' ' << "year: " << year << endl;
}

ostream& operator<<(ostream &os, const Date &d)
{
	os << "day: " << d.get_day() << ' ' << "month: " << d.get_month() << ' '
		<< "year: " << d.get_year() << endl;
	return os;
}

istream& operator>>(istream &is,Date &d)
{
	int _day, _month, _year;
	cout << "enter day:";
	is >> _day;
	cout << "enter month:";
	is >> _month;
	cout << "enter year:";
	is >> _year;
	cout << endl;
	d.sat_date(Date(_day, _month, _year));
	return is;
}

