#include "studentlist.h"

#include <iterator>
#include <algorithm>
#include <numeric>
#include <vector>

std::ostream& lab3::operator<< (std::ostream& out, const lab3::student& s)
    {
    return out << s.first_name << " " << s.last_name << " " << s.album_no;
    }

std::ostream& lab3::operator<< (std::ostream& out, const lab3::students_list& l)
    {
    auto it = std::ostream_iterator<student>(out, "\n");
    std::copy(l.students.begin(), l.students.end(), it);
    return out;
    }


void lab3::students_list::add_student(const student& s)
    {
    students.push_back(s);
    }

static const std::vector<std::string> first_names({"Juliusz", "Oktawian", "Marek", "Neron"});
static const std::vector<std::string> last_names({"Cezar", "August", "Antoniusz"});


lab3::student::student(unsigned int random_number)
    : first_name(first_names[random_number%first_names.size()]),
      last_name(last_names[random_number%last_names.size()]), album_no(random_number)
    {}

bool lab3::students_list::if_all_fnames_contain(const char letter) const {
	int firstNamesMissing = std::accumulate(this->students.begin(), this->students.end(), 0,
		[letter](int sum, const lab3::student& student) -> int {
			return sum + (student.first_name.find(letter, 0) == -1);
	});

	return firstNamesMissing == 0;
}

void lab3::students_list::remove_lnames_of_length(int length) {
	std::list<lab3::student> nowa;
	std::copy_if(this->students.begin(), this->students.end(), std::back_inserter(nowa),
		[length](const lab3::student& student) -> bool {
			return student.last_name.length() != length;
	});

	this->students = nowa;
}

void lab3::students_list::substitute_lnames_of_length(int length, const lab3::student& student) {
	std::list<lab3::student> nowa;
	std::transform(this->students.begin(), this->students.end(), std::back_inserter(nowa),
		[length, &student](const lab3::student& aktualnyStudent) -> lab3::student {
		if (aktualnyStudent.last_name.length() == length)
			return student;
		else
			return aktualnyStudent;
	});
	
	this->students = nowa;
}

