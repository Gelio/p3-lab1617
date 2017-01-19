#include <iostream>
#include <algorithm>
#include <iterator>

#include "studentlist.h"

using lab3::student;
using lab3::students_list;

using std::cout;
using std::endl;


int main(int argc, char** argv)
    {
    students_list list;

    list.add_student(student("Konrad", "Wallenrod", 13));
    list.add_student(student("Tadeusz", "Soplica", 8001));
    list.add_student(student("Ksiadz", "Robak", 2));
    list.add_student(student("Jacek", "Soplica", 2));
    list.add_student(student("Adam", "Mickiewicz", 44));


    //Etap 1
     cout << "Etap 1" << endl;
     cout << "if_all_fnames_contain(a) " << list.if_all_fnames_contain('a') << endl;
     cout << "if_all_fnames_contain(d) " << list.if_all_fnames_contain('d') << endl;
     cout << endl;

    //Etap 2
     cout << "Etap 2" << endl;
     auto list2 = list;
     auto list3 = list;
     auto list4 = list;
     auto list5 = list;

     list2.remove_lnames_of_length(7);
     list3.remove_lnames_of_length(2);
     list4.substitute_lnames_of_length(7, student("Juliusz", "Slowacki", -1));
     list5.substitute_lnames_of_length(24, student("Juliusz", "Slowacki", -1));

     cout << "remove_lnames_of_length 7 " << endl << list2 << endl;
     cout << "remove_lnames_of_length 2 " << endl << list3 << endl;
     cout << "substitute_lnames_of_length 7 " << endl << list4 << endl;
     cout << "substitute_lnames_of_length 24 " << endl << list5 << endl;
     cout << endl;

    //Etap 3

     cout << "Etap 3" << endl;
     students_list random1;
     students_list random2;
     students_list random3;

     unsigned int num=7;
	 auto every_second_number = [](unsigned int startingNumber) {
		 unsigned int add = 0;

		 return [startingNumber, &add]() -> unsigned int {
			 add += 2;
			 return startingNumber + add;
		 };
	 }(num);

	 const int N = 8;
	 std::generate_n(std::back_inserter(random1.students), N, [&every_second_number]() {
		 return student(every_second_number());
	 });
	 std::generate_n(std::back_inserter(random2.students), N, [&every_second_number]() {
		 return student(every_second_number());
	 });
	 std::generate_n(std::back_inserter(random3.students), N, [&every_second_number]() {
		 return student(every_second_number());
	 });

     cout << "random1: " << endl << random1 << endl;
     cout << "random2: " << endl << random2 << endl;
     cout << "random3: " << endl << random3 << endl;
     cout << endl;

    //Etap 4

    // cout << "Etap 4" << endl;
    // const student* s1 = list.find_by_first_name("Adam");
    // const student* s2 = list.find_by_first_name("Fryderyk");

    // cout << "Find by name Adam: ";
    // if(s1!=nullptr) {
    //   cout << *s1;
    // } else {
    //   cout << "nullptr";
    // }
    // cout << endl;

    // cout << "Find by name Fryderyk: ";
    // if(s2!=nullptr) {
    //   cout << *s2;
    // } else {
    //   cout << "nullptr";
    // }
    // cout << endl;
    // cout << endl;

    //Etap 5
    // cout << "Etap 5" << endl;

    // cout << "sort_by_album_no porownan: " << list.sort_by_album_no() << endl;
    // cout << list;

    // cout << "sort_by_last_name_album_no porownan: " << list.sort_by_last_name_album_no() << endl;
    // cout << list;

    return 0;
    }


