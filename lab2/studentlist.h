#ifndef STUDENTLIST_H
#define STUDENTLIST_H

#include <ostream>
#include <string>
#include <list>

namespace lab3
{

class student
    {
    public:
        std::string first_name;
        std::string last_name;
        int album_no;
        inline student(const std::string& first_name, const std::string& last_name, int album_no)
            : first_name(first_name), last_name(last_name), album_no(album_no) {}
        student(unsigned int random_number);
    };

std::ostream& operator<<(std::ostream& out, const student& st);

class students_list
    {
    public:
        std::list<student> students;

        void add_student(const student& s);

        //Dodać metody
		bool if_all_fnames_contain(const char letter) const;
		void remove_lnames_of_length(int length);
		void substitute_lnames_of_length(int length, const student& student);
    };

std::ostream& operator<<(std::ostream& out, const students_list& list);
}

#endif /* STUDENTLIST_H */


